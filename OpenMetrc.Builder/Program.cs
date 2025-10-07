using System.Reflection;
using System.Text.Json;
using System.Text.RegularExpressions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi;
using Microsoft.OpenApi.Extensions;
using OpenMetrc.Builder;
using Postman.Collection.Models;
using YamlDotNet.RepresentationModel;

namespace Metrc.Api.Generator
{
    /// <summary>
    /// Main application class to drive the OpenAPI and client generation process.
    /// </summary>
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            try
            {
                var generator = new ApiClientGenerator();
                await generator.GenerateAsync();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"❌ An unexpected error occurred: {ex.Message}");
                Console.ResetColor();
            }
        }
    }

    /// <summary>
    /// Handles the process of generating an OpenAPI specification and client from a Postman collection.
    /// </summary>
    public class ApiClientGenerator
    {
        private const string PostmanCollectionResourceName = "Metrc-Postman-collection.json";
        private const string OutputYamlFileName = "MetrcGenerated.yaml";
        private const string MetrcApiBaseUrl = "https://api.metrc.com/";

        /// <summary>
        /// Executes the end-to-end generation process.
        /// </summary>
        public async Task GenerateAsync()
        {
            var collection = await LoadAndDeserializePostmanCollectionAsync();
            if (collection == null) return;

            PrintCollectionStructure(collection);

            var yamlSpecPath = await GenerateOpenApiSpecAsync(collection);
            if (string.IsNullOrEmpty(yamlSpecPath)) return;

            await GenerateClientCodeAsync(yamlSpecPath);

            Console.WriteLine("✅ Client generation complete.");
        }

        /// <summary>
        /// Loads the embedded Postman collection JSON file and deserializes it into a model.
        /// </summary>
        private async Task<PostmanCollection?> LoadAndDeserializePostmanCollectionAsync()
        {
            try
            {
                var assembly = Assembly.GetExecutingAssembly();
                var resourceName = assembly.GetManifestResourceNames()
                    .FirstOrDefault(n => n.EndsWith(PostmanCollectionResourceName));

                if (string.IsNullOrEmpty(resourceName))
                    throw new FileNotFoundException($"Embedded resource '{PostmanCollectionResourceName}' not found.");

                await using var stream = assembly.GetManifestResourceStream(resourceName);
                if (stream == null)
                    throw new InvalidOperationException("Failed to load the embedded resource stream.");

                using var reader = new StreamReader(stream);
                var postmanJson = await reader.ReadToEndAsync();

                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var collection = JsonSerializer.Deserialize<PostmanCollection>(postmanJson, options);

                if (collection == null)
                    throw new JsonException("Deserialization of Postman collection resulted in a null object.");

                Console.WriteLine($"✅ Loaded Postman collection: {collection.Info?.Name ?? "Unnamed"}");
                return collection;
            }
            catch (Exception ex) when (ex is FileNotFoundException or JsonException or InvalidOperationException)
            {
                Console.WriteLine($"❌ Error loading collection: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Prints the hierarchical structure of the Postman collection to the console for debugging.
        /// </summary>
        private void PrintCollectionStructure(PostmanCollection collection)
        {
            if (collection.Item?.Any() != true)
            {
                Console.WriteLine("⚠️ No items found in the collection.");
                return;
            }

            Console.WriteLine("🔎 Collection structure:");
            PrintItemsRecursive(collection.Item);
        }

        private void PrintItemsRecursive(IEnumerable<Item> items, string indent = "")
        {
            foreach (var item in items)
            {
                if (item.Request != null)
                {
                    var method = item.Request.Method;
                    var path = string.Join("/", item.Request.Url?.Path ?? Enumerable.Empty<string>());
                    Console.WriteLine($"{indent}- {item.Name}: {method} /{path}");
                }

                if (item.Items != null && item.Items.Any())
                {
                    Console.WriteLine($"{indent}{item.Name ?? "Unnamed folder"}:");
                    PrintItemsRecursive(item.Items, indent + "  ");
                }
            }
        }

        /// <summary>
        /// Generates the OpenAPI YAML from the collection and writes it to a file.
        /// </summary>
        /// <returns>The full path to the generated YAML file.</returns>
        private async Task<string?> GenerateOpenApiSpecAsync(PostmanCollection collection)
        {
            try
            {
                Console.WriteLine("⏳ Generating OpenAPI specification...");
                var openApiDoc = OpenApiFromPostmanBuilder.Build(collection);

                var projectRoot = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", ".."));
                var referenceDir = Path.Combine(projectRoot, "Reference");
                Directory.CreateDirectory(referenceDir);


                var yamlSpecPath = Path.Combine(referenceDir, OutputYamlFileName);
                var yaml = openApiDoc.Serialize(OpenApiSpecVersion.OpenApi3_0, OpenApiFormat.Yaml);

                var singleQuotedPattern = new Regex(@"^(\s*)'(/[^']*?\{[^']*?\})':", RegexOptions.Multiline);
                yaml = singleQuotedPattern.Replace(yaml, m => $"{m.Groups[1].Value}{m.Groups[2].Value}:");

                var yamlStream = new YamlStream();
                yamlStream.Load(new StringReader(yaml));
                var root = (YamlMappingNode)yamlStream.Documents[0].RootNode;

                // Track unique tag lists
                var tagSets = new Dictionary<string, string>(); // key: joined tags, value: ref name
                int refCounter = 0;

                if (root.Children.TryGetValue("paths", out var pathsNode))
                {
                    var paths = (YamlMappingNode)pathsNode;

                    foreach (var pathEntry in paths.Children)
                    {
                        var pathValue = (YamlMappingNode)pathEntry.Value;

                        foreach (var methodEntry in pathValue.Children)
                        {
                            if (methodEntry.Value is YamlMappingNode methodNode &&
                                methodNode.Children.TryGetValue("tags", out var tagsNode))
                            {
                                if (tagsNode is YamlSequenceNode tagArray)
                                {
                                    var tags = tagArray.Children.OfType<YamlScalarNode>().Select(t => t.Value).ToList();
                                    var key = string.Join("/", tags);

                                    if (!tagSets.TryGetValue(key, out var anchorName))
                                    {
                                        anchorName = $"ref_{refCounter++}";
                                        tagSets[key] = anchorName;

                                        // Add YAML anchor
                                        tagArray.Anchor = anchorName;
                                    }
                                    else
                                    {
                                        // Replace this node with alias reference (*ref_n)
                                        methodNode.Children["tags"] = new YamlScalarNode($"*{anchorName}");
                                    }
                                }
                            }
                        }
                    }
                }
                using var writer = new StringWriter();
                yamlStream.Save(writer, assignAnchors: false);
                var finalYaml = writer.ToString();

                finalYaml = Regex.Replace(finalYaml, @"tags:\s+'(\*ref_\d+)'", "tags: $1");

                await File.WriteAllTextAsync(yamlSpecPath, finalYaml);

                Console.WriteLine($"🧩 Generated OpenAPI YAML: {yamlSpecPath}");
                return yamlSpecPath;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Failed to generate OpenAPI YAML: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Invokes the NSwag client generation logic using the created YAML file.
        /// </summary>
        private async Task GenerateClientCodeAsync(string yamlSpecPath)
        {
            Console.WriteLine("⏳ Generating client code...");
            var services = new ServiceCollection();
            await services.AddMetrcClientsAsync(yamlSpecPath, MetrcApiBaseUrl);
        }
    }

    /// <summary>
    /// Placeholder for NSwag client generation extensions.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        public static Task AddMetrcClientsAsync(this IServiceCollection services, string specPath, string baseUrl)
        {
            // This is where you would add your NSwag or other client generation logic.
            Console.WriteLine($"---> Client generation logic would run here for spec '{Path.GetFileName(specPath)}' and base URL '{baseUrl}'");
            return Task.CompletedTask;
        }
    }
}