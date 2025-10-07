using HtmlAgilityPack;
using NJsonSchema;
using System.Text.Json;

namespace OpenMetrc.Scraper.Application;

public class HtmlSchemaExtractor
{
    /// <summary>
    /// Parses the provided HTML and generates an OpenAPI-compatible JSON Schema
    /// from the Example Response section.
    /// </summary>
    /// <param name="htmlContent">Full HTML string of an endpoint page.</param>
    /// <returns>A JsonSchema instance representing the Example Response, or null if not found.</returns>
    public JsonSchema? GenerateSchemaFromHtml(string htmlContent)
    {
        // 1️⃣ Load HTML
        HtmlDocument htmlDoc = new();
        htmlDoc.LoadHtml(htmlContent);

        // 2️⃣ Extract Example Response JSON
        HtmlNode? codeNode = htmlDoc.DocumentNode
            .SelectSingleNode("//h4[contains(text(), 'Example Response')]/following-sibling::pre[1]/code");

        if (codeNode == null)
            return null;

        string? jsonText = codeNode.InnerText.Trim();
        if (string.IsNullOrWhiteSpace(jsonText))
            return null;

        // 3️⃣ Parse JSON
        using JsonDocument jsonDoc = JsonDocument.Parse(jsonText);

        // 4️⃣ Generate schema from the parsed object
        object jsonData = JsonElementToObject(jsonDoc.RootElement);

        // 5️⃣ Use NJsonSchema to generate OpenAPI-compatible schema
        var schema = JsonSchema.FromSampleJson(JsonSerializer.Serialize(jsonData));

        return schema;
    }

    /// <summary>
    /// Converts a JsonElement into a plain .NET object (dictionary, list, etc.)
    /// </summary>
    private static object? JsonElementToObject(JsonElement element)
    {
        return element.ValueKind switch
        {
            JsonValueKind.Object => element.EnumerateObject()
                .ToDictionary(p => p.Name, p => JsonElementToObject(p.Value)),
            JsonValueKind.Array => element.EnumerateArray()
                .Select(JsonElementToObject).ToList(),
            JsonValueKind.String => element.GetString(),
            JsonValueKind.Number => element.TryGetInt64(out var l) ? l : element.GetDouble(),
            JsonValueKind.True => true,
            JsonValueKind.False => false,
            _ => null
        };
    }
}
