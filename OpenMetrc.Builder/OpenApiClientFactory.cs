using NSwag;
using NSwag.CodeGeneration.CSharp;
using Microsoft.Extensions.DependencyInjection;

namespace OpenMetrc.Builder;

public static class OpenApiClientFactory
{
    public static async Task<IServiceCollection> AddMetrcClientsAsync(
        this IServiceCollection services,
        string yamlSpecPath,
        string baseUrl)
    {
        if (!File.Exists(yamlSpecPath))
            throw new FileNotFoundException("OpenAPI spec not found", yamlSpecPath);

        // Load YAML spec
        var document = await OpenApiYamlDocument.FromFileAsync(yamlSpecPath);

        // Configure client generator
        var settings = new CSharpClientGeneratorSettings
        {
            ClassName = "{controller}Client",
            CSharpGeneratorSettings =
            {
                Namespace = "OpenMetrc.ApiClient",
                GenerateNullableReferenceTypes = true,
                GenerateOptionalPropertiesAsNullable = true
            }
        };

        // Generate strongly typed client code
        var generator = new CSharpClientGenerator(document, settings);
        string code = generator.GenerateFile();

        // Output generated code for inspection or inclusion in your build
        var outputPath = Path.Combine(AppContext.BaseDirectory, "GeneratedClients.cs");
        await File.WriteAllTextAsync(outputPath, code);
        Console.WriteLine($"✅ OpenAPI clients generated: {outputPath}");

        // Register a shared HttpClient (no rate limiting)
        services.AddHttpClient("MetrcClient", client =>
        {
            client.BaseAddress = new Uri(baseUrl);
        });

        return services;
    }
}
