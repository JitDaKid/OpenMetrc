using Humanizer;
using NJsonSchema;
using OpenMetrc.Scraper.Models;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace OpenMetrc.Scraper.Application;

public class SchemaGenerationService
{
    public record ModelSchemaInfo(JsonSchema Schema, string Section, bool IsRequest, bool IsTopLevel)
    {
        public string SubFolder => IsRequest ? Path.Combine(Section, "Requests") : Section;
        public string TargetNamespace => $"OpenMetrc.Builder.Domain.{Section}{(IsRequest ? ".Requests" : "")}";
    }

    private readonly Dictionary<string, ModelSchemaInfo> _modelSchemas = new();
    public IReadOnlyDictionary<string, ModelSchemaInfo> ModelSchemas => _modelSchemas;

    public void DiscoverSchemasFromEndpoint(EndpointInfo endpointInfo)
    {
        var processedInstances = new HashSet<JsonSchema>();
        DiscoverRawSchemas(endpointInfo.ExampleResponse, endpointInfo.OperationId.Singularize(false), endpointInfo.Section, false, processedInstances);
        if (endpointInfo.HttpMethod is "POST" or "PUT")
            DiscoverRawSchemas(endpointInfo.ExampleRequest, endpointInfo.OperationId.Singularize(false), endpointInfo.Section, true, processedInstances);
    }

    public void LinkDiscoveredSchemas()
    {
        foreach (var modelInfo in _modelSchemas.Values)
            LinkChildSchemas(modelInfo.Schema);
    }

    private void LinkChildSchemas(JsonSchema schema)
    {
        if (schema.Type != JsonObjectType.Object) return;

        foreach (var (propertyName, propertyValue) in schema.Properties)
        {
            var propertySchema = propertyValue;
            var itemSchema = propertySchema.Item;

            var nestedModelName = propertyName.Singularize(inputIsKnownToBePlural: false);

            if (propertySchema.Type == JsonObjectType.Object)
            {
                if (_modelSchemas.ContainsKey(nestedModelName))
                    propertyValue.Reference = _modelSchemas[nestedModelName].Schema;
            }
            else if (propertySchema.Type == JsonObjectType.Array && itemSchema?.Type == JsonObjectType.Object)
            {
                if (_modelSchemas.ContainsKey(nestedModelName))
                    itemSchema.Reference = _modelSchemas[nestedModelName].Schema;
            }
        }
    }

    private void DiscoverAndRegister(JsonSchema schema, string modelName, string section, bool isRequest, bool isTopLevel, HashSet<JsonSchema> processedInstances)
    {
        if (!processedInstances.Add(schema) || schema.Type != JsonObjectType.Object) return;

        
        if (modelName == "Attribute") modelName = "AttributeModel";

        if (_modelSchemas.TryGetValue(modelName, out var existingInfo))
        {
            MergeSchemas(existingInfo.Schema, schema);
            if (isTopLevel && !existingInfo.IsTopLevel)
                _modelSchemas[modelName] = existingInfo with { Section = section, IsTopLevel = true };
        }
        else
        {
            schema.Title = modelName;
            _modelSchemas.Add(modelName, new ModelSchemaInfo(schema, section, isRequest, isTopLevel));
        }
        try
        {
            foreach (var (propertyName, propertyValue) in schema.Properties.ToList())
            {
                var propertySchema = propertyValue.ActualSchema;
                var itemSchema = propertySchema.Item?.ActualSchema;

                if (propertySchema.Reference != null || 
                    propertySchema.Type.HasFlag(JsonObjectType.Object))
                {
                    var nestedModelName = propertyName;

                    Console.WriteLine($"[DEBUG] In '{modelName}', found nested object: '{propertyName}' -> '{nestedModelName}'");

                    var targetSchema = propertySchema.Reference ?? propertySchema;

                    DiscoverAndRegister(targetSchema, nestedModelName, section, isRequest, false, processedInstances);

                    propertyValue.Reference = propertySchema;
                    propertyValue.Properties.Clear();
                }
                else if (propertySchema.Type.HasFlag(JsonObjectType.Array) &&
                         itemSchema != null &&
                         (itemSchema.Type.HasFlag(JsonObjectType.Object) || itemSchema.Reference != null))
                {
                    var nestedModelName = propertyName.Singularize(false);

                    Console.WriteLine($"[DEBUG] In '{modelName}', found nested array: '{propertyName}' -> '{nestedModelName}'");

                    var targetSchema = itemSchema.Reference ?? itemSchema;

                    DiscoverAndRegister(targetSchema, propertyName, section, isRequest, false, processedInstances);

                    propertySchema.Item = new JsonSchema
                    {
                        Reference = targetSchema,
                        Title = propertyName
                    };
                }
            }

        }
        catch (InvalidOperationException) { }
    }

    private void DiscoverRawSchemas(string? jsonContent, string operationId, string section, bool isRequest, HashSet<JsonSchema> processedInstances)
    {
        if (string.IsNullOrWhiteSpace(jsonContent)) return;
        try
        {
            var rootSchema = GenerateSchemaFromMergedSamples(jsonContent);

            var topLevelModelName = NamingService.GetModelName(operationId, isRequest);

            var itemSchema = rootSchema;
            if (rootSchema.Type == JsonObjectType.Array && rootSchema.Item != null)
            {
                itemSchema = rootSchema.Item.ActualSchema;
            }
            else if (rootSchema.Properties.TryGetValue("Data", out var dataProperty) &&
                     dataProperty.ActualSchema?.Item?.ActualSchema != null)
            {
                itemSchema = dataProperty.ActualSchema.Item.ActualSchema;
            }

            DiscoverAndRegister(itemSchema, topLevelModelName, section, isRequest, true, processedInstances);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[ERROR] Failed to process schema for {operationId}: {ex.Message}");
        }
    }

    private JsonSchema GenerateSchemaFromMergedSamples(string jsonContent)
    {
        var rootNode = JsonNode.Parse(jsonContent);
        if (rootNode == null) return new JsonSchema();

        var examples = new List<JsonObject>();

        if (rootNode is JsonArray rootArray)
        {
            examples.AddRange(rootArray.OfType<JsonObject>());
        }
        else if (rootNode is JsonObject rootObject && rootObject["Data"] is JsonArray dataArray)
        {
            examples.AddRange(dataArray.OfType<JsonObject>());
        }
        else if (rootNode is JsonObject singleObj)
        {
            examples.Add(singleObj);
        }

        if (!examples.Any())
            return JsonSchema.FromSampleJson(jsonContent);

        var compositeObject = new JsonObject();
        var nullableProperties = new HashSet<string>();

        foreach (var example in examples)
        {
            foreach (var kvp in example)
            {
                var propertyName = kvp.Key;
                var propertyNode = kvp.Value;

                if (propertyNode is null)
                {
                    nullableProperties.Add(propertyName);
                    continue;
                }

                if (propertyNode is JsonValue jv)
                {
                    if (jv.TryGetValue<JsonElement>(out var elem) && elem.ValueKind == JsonValueKind.Null)
                    {
                        nullableProperties.Add(propertyName);
                        continue;
                    }
                }
                compositeObject[propertyName] = propertyNode.DeepClone();
            }
        }

        var schema = JsonSchema.FromSampleJson(compositeObject.ToJsonString());

        foreach (var (propertyName, jsonProperty) in schema.Properties)
            if (nullableProperties.Contains(propertyName))
                jsonProperty.IsNullableRaw = true;

        return schema;
    }
    private void MergeSchemas(JsonSchema target, JsonSchema source)
    {
        foreach (var (key, sourceProperty) in source.Properties)
            if (!target.Properties.ContainsKey(key))
                target.Properties.Add(key, sourceProperty);
    }
}