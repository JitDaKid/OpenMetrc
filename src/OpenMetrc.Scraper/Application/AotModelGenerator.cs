using NJsonSchema;
using System.Text;
using static OpenMetrc.Scraper.Application.SchemaGenerationService;

namespace OpenMetrc.Scraper.Application;

public class AotModelGenerator
{
    private readonly Dictionary<JsonObjectType, string> _typeMappings = new()
    {
        { JsonObjectType.String, "string" },
        { JsonObjectType.Integer, "long" },
        { JsonObjectType.Number, "double" },
        { JsonObjectType.Boolean, "bool" },
        { JsonObjectType.Object, "object" },
    };

    public Dictionary<string, string> Generate(IReadOnlyDictionary<string, SchemaGenerationService.ModelSchemaInfo> schemas)
    {
        var generatedFiles = new Dictionary<string, string>();

        foreach (var (modelName, modelInfo) in schemas)
        {
            var code = GenerateModelCode(modelName, modelInfo, schemas);
            var filePath = Path.Combine(modelInfo.SubFolder, $"{modelName}.cs");
            generatedFiles.Add(filePath, code);
        }

        var contextCode = GenerateSerializerContext(schemas);
        generatedFiles.Add("MetrcJsonSerializerContext.cs", contextCode);

        return generatedFiles;
    }

    private string GenerateModelCode(string modelName, SchemaGenerationService.ModelSchemaInfo modelInfo, IReadOnlyDictionary<string, SchemaGenerationService.ModelSchemaInfo> allSchemas)
    {
        var builder = new StringBuilder();
        builder.AppendLine("using System.Text.Json.Serialization;");
        builder.AppendLine();
        builder.AppendLine($"namespace {modelInfo.TargetNamespace};");
        builder.AppendLine();
        builder.AppendLine($"public partial record {modelName}");
        builder.AppendLine("{");

        foreach (var (jsonName, property) in modelInfo.Schema.Properties)
        {
            string csharpType;
            try
            {
                var csharpBaseType = GetCSharpType(property.ActualSchema, allSchemas);
                csharpType = property.IsRequired ? csharpBaseType : $"{csharpBaseType}?";
            }
            catch (InvalidOperationException ex) when (ex.Message.Contains("Cyclic references detected"))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"      [FATAL] --> Cycle detected on property '{jsonName}' in model '{modelName}'. Skipping property.");
                Console.ResetColor();
                continue; // Skip this broken property and continue generating the rest of the model.
            }

            builder.AppendLine($"    [JsonPropertyName(\"{jsonName}\")]");
            builder.AppendLine($"    public {csharpType} {jsonName} {{ get; init; }}");
            builder.AppendLine();
        }

        builder.AppendLine("}");
        return builder.ToString();
    }

    private string GetCSharpType(JsonSchema schema, IReadOnlyDictionary<string, ModelSchemaInfo> allSchemas)
    {
        var resolvedSchema = schema.ActualSchema;

        if (resolvedSchema.Type.HasFlag(JsonObjectType.Array))
        {
            if (resolvedSchema.Item == null) return "ICollection<object>";
            var itemType = GetCSharpType(resolvedSchema.Item, allSchemas);
            return $"ICollection<{itemType}>";
        }

        if (!string.IsNullOrEmpty(resolvedSchema.Title))
            return resolvedSchema.Title;

        var primitiveType = resolvedSchema.Format switch
        {
            "date" => "DateOnly",
            "date-time" => "DateTimeOffset",
            _ => _typeMappings.GetValueOrDefault(resolvedSchema.Type, "object")
        };
        return primitiveType;
    }

    private string GenerateSerializerContext(IReadOnlyDictionary<string, SchemaGenerationService.ModelSchemaInfo> schemas)
    {
        var builder = new StringBuilder();
        builder.AppendLine("using System.Text.Json.Serialization;");

        var namespaces = schemas.Values.Select(s => s.TargetNamespace).Distinct();
        foreach (var ns in namespaces)
            builder.AppendLine($"using {ns};");

        builder.AppendLine();
        builder.AppendLine("namespace OpenMetrc.Builder.Domain;");
        builder.AppendLine();

        foreach (var (modelName, modelInfo) in schemas.OrderBy(kv => kv.Key))
        {
            builder.AppendLine($"[JsonSerializable(typeof({modelInfo.TargetNamespace}.{modelName}))]");
        }

        builder.AppendLine("public partial class MetrcJsonSerializerContext : JsonSerializerContext { }");

        return builder.ToString();
    }
}