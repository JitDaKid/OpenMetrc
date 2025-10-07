using Microsoft.OpenApi.Models;
using Postman.Collection.Models;
using System.Text.RegularExpressions;

namespace OpenMetrc.Builder
{
    /// <summary>
    /// A static builder class to convert a Postman Collection into an OpenAPI Document.
    /// </summary>
    public static class OpenApiFromPostmanBuilder
    {
        /// <summary>
        /// Builds an OpenApiDocument from a given PostmanCollection object.
        /// </summary>
        /// <param name="collection">The deserialized Postman collection.</param>
        /// <returns>An OpenApiDocument representing the collection.</returns>
        public static OpenApiDocument Build(PostmanCollection collection)
        {
            var doc = new OpenApiDocument
            {
                Info = new OpenApiInfo
                {
                    Title = collection.Info?.Name ?? "API",
                    Version = "1.0.0",
                    Description = "Auto-generated from Postman collection"
                },
                Paths = new OpenApiPaths(),
            };

            foreach (var (item, folderPath) in Flatten(collection.Item))
            {
                if (item.Request?.Url == null) continue;

                var request = item.Request;
                var url = request.Url;

                // Combine path segments from both "host" and "path" properties.
                var hostString = string.Join("", url.Host ?? Enumerable.Empty<string>());

                // Remove the server variable (e.g., "{{Metrc.api.server}}") to isolate the base path.
                var basePath = Regex.Replace(hostString, @"^\{\{.*?\}\}", "");

                var hostPathSegments = basePath.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
                var requestPathSegments = url.Path?.Select(p => Regex.Replace(p, @"\{\{(.*?)\}\}", "{$1}")) ?? Enumerable.Empty<string>();

                var fullPath = "/" + string.Join("/", hostPathSegments.Concat(requestPathSegments));

                if (!doc.Paths.TryGetValue(fullPath, out var pathItem))
                {
                    pathItem = new OpenApiPathItem();
                    doc.Paths.Add(fullPath, pathItem);
                }

                var operation = new OpenApiOperation
                {
                    Summary = item.Name,
                    Tags = new List<OpenApiTag> { new() { Name = folderPath } },
                    Parameters = new List<OpenApiParameter>(),
                    Responses = new OpenApiResponses
                    {
                        ["200"] = new OpenApiResponse 
                        { 
                            Description = "Success",
                            Content = new Dictionary<string, OpenApiMediaType>
                            {
                                ["application/json"] = new OpenApiMediaType
                                {
                                    Schema = new OpenApiSchema { Type = "object" }
                                }
                            }
                        }
                    }
                };

                var tagParts = folderPath.Split('/', StringSplitOptions.RemoveEmptyEntries);
                operation.Tags = tagParts.Select(t => new OpenApiTag { Name = t }).ToList();

                // Find all {variable} placeholders in the path to define them as path parameters.
                var pathParams = Regex.Matches(fullPath, @"\{([a-zA-Z0-9_]+)\}")
                    .Cast<Match>()
                    .Select(m => m.Groups[1].Value);

                foreach (var paramName in pathParams)
                {
                    operation.Parameters.Add(new OpenApiParameter
                    {
                        Name = paramName,
                        In = ParameterLocation.Path,
                        Required = true,
                        Schema = new OpenApiSchema { Type = "string" }
                    });
                }

                if (url.Query != null)
                {
                    foreach (var queryParam in url.Query)
                    {
                        // Avoid adding parameters that are already defined in the path.
                        if (operation.Parameters.All(p => p.Name != queryParam.Key))
                        {
                            operation.Parameters.Add(new OpenApiParameter
                            {
                                Name = queryParam.Key,
                                In = ParameterLocation.Query,
                                Schema = new OpenApiSchema { Type = "string" }
                            });
                        }
                    }
                }

                var operationType = MapHttpMethod(request.Method);

                // ✅ Merge instead of overwrite
                if (!pathItem.Operations.ContainsKey(operationType))
                {
                    pathItem.AddOperation(operationType, operation);
                }
                else
                {
                    Console.WriteLine($"⚠️ Duplicate operation: {operationType} {fullPath} (keeping first)");
                }
            }

            Console.WriteLine($"✅ Collected {doc.Paths.Count} paths, {doc.Paths.Sum(p => p.Value.Operations.Count)} operations.");
            return doc;
        }

        private static OperationType MapHttpMethod(string method) => method.ToUpperInvariant() switch
        {
            "GET" => OperationType.Get,
            "POST" => OperationType.Post,
            "PUT" => OperationType.Put,
            "DELETE" => OperationType.Delete,
            "PATCH" => OperationType.Patch,
            "OPTIONS" => OperationType.Options,
            "HEAD" => OperationType.Head,
            "TRACE" => OperationType.Trace,
            _ => throw new NotSupportedException($"HTTP method '{method}' is not supported.")
        };

        private static IEnumerable<(Item Item, string FolderPath)> Flatten(IEnumerable<Item>? items, string? parentFolder = null)
        {
            if (items == null) yield break;

            foreach (var item in items)
            {
                var currentFolderPath = !string.IsNullOrEmpty(parentFolder) ? $"{parentFolder}/{item.Name}" : item.Name;

                if (item.Items?.Any() == true)
                {
                    foreach (var child in Flatten(item.Items, currentFolderPath))
                        yield return child;
                }
                else if (item.Request != null)
                {
                    // Use currentFolderPath here
                    yield return (item, currentFolderPath);
                }
            }
        }

    }
}

