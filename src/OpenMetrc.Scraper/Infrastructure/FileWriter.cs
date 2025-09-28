using Newtonsoft.Json;
using NSwag;
using OpenMetrc.Scraper.Application;
using OpenMetrc.Scraper.Application.Contracts;

namespace OpenMetrc.Scraper.Infrastructure;

public class FileWriter : IFileWriter
{
    public Task WriteOpenApiDocumentAsync(OpenApiDocument document)
    {
        var path = $"../../../OpenApi/metrc-swagger-{document.Info.Version}.yaml";
        var yamlContent = document.ToYaml();
        return File.WriteAllTextAsync(path, yamlContent);
    }

    public async Task WriteSchemasAsync(string version, string basePath, SchemaGenerationService schemaService)
    {
        if (!schemaService.ModelSchemas.Any())
        {
            Console.WriteLine("[SchemaWriter] No model schemas found to write.");
            return;
        }

        var schemasWritten = 0;
        var schemaBasePath = Path.Combine(basePath, $"OpenMetrc.{version}.Builder/Domain/Schemas");

        foreach (var (modelName, modelInfo) in schemaService.ModelSchemas.OrderBy(kv => kv.Key))
        {
            var directoryPath = Path.Combine(schemaBasePath, modelInfo.SubFolder);
            Directory.CreateDirectory(directoryPath);

            var filePath = Path.Combine(directoryPath, $"{modelName}.json");
            var jsonContent = modelInfo.Schema.ToJson(Formatting.Indented);

            await File.WriteAllTextAsync(filePath, jsonContent);
            schemasWritten++;
        }

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"{schemasWritten} JSON schema files have been written.");
        Console.ResetColor();
    }
}