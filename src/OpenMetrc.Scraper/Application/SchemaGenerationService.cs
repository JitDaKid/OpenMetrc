using System.Text.Json.Nodes;
using NJsonSchema;

namespace OpenMetrc.Scraper.Application;

public class SchemaGenerationService
{
    public readonly Dictionary<string, JsonSchema> ModelSchemas = new();

    public void DiscoverSchemas(string? jsonContent, string modelName)
    {
        if (string.IsNullOrWhiteSpace(jsonContent)) return;

        try
        {
            var rootNode = JsonNode.Parse(jsonContent);
            if (rootNode == null) return;

            var schema = GenerateSchema(rootNode, modelName, new HashSet<string>());
            if (!ModelSchemas.ContainsKey(modelName))
            {
                ModelSchemas[modelName] = schema;
            }
            else
            {
                MergeSchemas(ModelSchemas[modelName], schema);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[ERROR] Failed to generate schema for {modelName}: {ex.Message}");
        }
    }

    public JsonSchema BuildRootSchema()
    {
        var root = new JsonSchema
        {
            Title = "OpenMetrcSchemaCollection",
            Type = JsonObjectType.Object
        };

        foreach (var kvp in ModelSchemas)
            root.Definitions[kvp.Key] = kvp.Value;

        return root;
    }

    private JsonSchema GenerateSchema(JsonNode node, string modelName, HashSet<string> processedModels)
    {
        if (processedModels.Contains(modelName))
            return new JsonSchema { Reference = ModelSchemas[modelName] };

        processedModels.Add(modelName);

        var schema = new JsonSchema
        {
            Title = modelName,
            Type = JsonObjectType.Object
        };

        if (node is JsonObject obj)
        {
            foreach (var kvp in obj)
            {
                string propName = kvp.Key;
                var valueNode = kvp.Value;

                if (valueNode == null)
                {
                    schema.Properties[propName] = new JsonSchemaProperty { Type = JsonObjectType.String, IsNullableRaw = true };
                    continue;
                }

                switch (valueNode)
                {
                    case JsonValue jv:
                        schema.Properties[propName] = new JsonSchemaProperty { Type = GetPrimitiveType(jv) };
                        break;

                    case JsonObject nestedObj:
                        string nestedName = $"{modelName}_properties_{propName}";
                        var nestedSchema = GenerateSchema(nestedObj, nestedName, processedModels);
                        schema.Properties[propName] = new JsonSchemaProperty { Reference = nestedSchema };
                        break;

                    case JsonArray arr:
                        if (arr.Count > 0 && arr[0] is JsonObject firstObj)
                        {
                            string itemName = $"{modelName}_properties_{propName}_items";
                            var itemSchema = GenerateSchema(firstObj, itemName, processedModels);
                            // Proper $ref for array items
                            var arraySchema = new JsonSchema
                            {
                                Title = itemName,
                                Type = JsonObjectType.Array,
                                Item = new JsonSchema { Reference = itemSchema }
                            };
                            schema.Properties[propName] = new JsonSchemaProperty { Reference = arraySchema };
                        }
                        else
                        {
                            schema.Properties[propName] = new JsonSchemaProperty { Type = JsonObjectType.Array };
                        }
                        break;
                }
            }
        }

        ModelSchemas[modelName] = schema;
        return schema;
    }

    private void MergeSchemas(JsonSchema target, JsonSchema incoming)
    {
        foreach (var kvp in incoming.Properties)
        {
            if (target.Properties.ContainsKey(kvp.Key))
            {
                var existingProp = target.Properties[kvp.Key];
                var newProp = kvp.Value;

                if (existingProp.Reference != null && newProp.Reference != null)
                {
                    // Recursively merge referenced schemas
                    MergeSchemas(existingProp.Reference, newProp.Reference);
                }
                else if (existingProp.Type == JsonObjectType.Object && newProp.Type == JsonObjectType.Object)
                {
                    MergeSchemas(existingProp, newProp);
                }
                else
                {
                    // Prefer the "broader" type (e.g., object overrides string if needed)
                    existingProp.Type = existingProp.Type | newProp.Type;
                }
            }
            else
            {
                // Add new property
                target.Properties[kvp.Key] = kvp.Value;
            }
        }
    }

    private static JsonObjectType GetPrimitiveType(JsonValue value)
    {
        if (value.TryGetValue(out string? _)) return JsonObjectType.String;
        if (value.TryGetValue(out bool _)) return JsonObjectType.Boolean;
        if (value.TryGetValue(out long _) || value.TryGetValue(out double _)) return JsonObjectType.Number;
        return JsonObjectType.String;
    }
}
