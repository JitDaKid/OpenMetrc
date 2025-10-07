using Newtonsoft.Json;
using NJsonSchema;
using NSwag;
using OpenMetrc.Scraper.Application;
using OpenMetrc.Scraper.Core.Services;

namespace OpenMetrc.Scraper.Infrastructure;

public class FileWriter : IFileWriter
{
    public Task WriteOpenApiDocumentAsync(OpenApiDocument document)
    {
        string path = $"../../../OpenApi/metrc-swagger-{document.Info.Version}.yaml";
        string yamlContent = document.ToYaml();
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
        var schemaBasePath = Path.Combine(basePath, $"OpenMetrc.{version}.Builder/Reference/Schemas");

        //foreach (var (modelName, modelInfo) in schemaService.ModelSchemas.OrderBy(kv => kv.Key))
        //{
        //    try
        //    {
        //        var directoryPath = Path.Combine(schemaBasePath, modelInfo.SubFolder);
        //        Console.WriteLine($"[SchemaWriter][Debug] Creating directory: {directoryPath}");
        //        Directory.CreateDirectory(directoryPath);

        //        var filePath = Path.Combine(directoryPath, $"{modelName}.json");
        //        Console.WriteLine($"[SchemaWriter][Debug] Target file path: {filePath}");

        //        // FIX: Replace the invalid method call with UpdateSchemaReferencePaths
        //        var schemaJson = modelInfo.Schema.ToJson();
        //        Console.WriteLine($"[SchemaWriter][Debug] Schema JSON for {modelName}: {schemaJson.Substring(0, Math.Min(500, schemaJson.Length))}...");
        //        var schemaToSerialize = await JsonSchema.FromJsonAsync(schemaJson);
        //        JsonSchemaReferenceUtilities.UpdateSchemaReferencePaths(schemaToSerialize);

        //        var jsonContent = schemaToSerialize.ToJson(Formatting.Indented);
        //        Console.WriteLine($"[SchemaWriter][Debug] Writing JSON content to file: {filePath}");

        //        await File.WriteAllTextAsync(filePath, jsonContent);
        //        Console.WriteLine($"[SchemaWriter][Debug] Successfully wrote schema for {modelName}");
        //        schemasWritten++;
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.ForegroundColor = ConsoleColor.Red;
        //        Console.WriteLine($"[SchemaWriter] Error writing schema for {modelName}: {ex.Message}");
        //        Console.ResetColor();
        //        // Continue to the next schema to avoid blocking the whole process
        //        continue;
        //    }
        //}

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"{schemasWritten} JSON schema files have been written.");
        Console.ResetColor();
    }
}