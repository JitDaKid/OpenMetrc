using System.Text;
using NJsonSchema;
using NJsonSchema.CodeGeneration;

namespace OpenMetrc.Scraper.Application;

/// <summary>
/// Cleans and formats property names from a JSON schema to be valid and conventional C# property names.
/// </summary>
internal class CustomPropertyNameGenerator : IPropertyNameGenerator
{
    /// <summary>
    /// Generates a C# property name from a JsonSchemaProperty.
    /// </summary>
    /// <param name="property">The schema property.</param>
    /// <returns>A formatted, PascalCase property name.</returns>
    public virtual string Generate(JsonSchemaProperty property)
    {
        var builder = new StringBuilder(property.Name);

        builder.Replace("$", "Dollar")
            .Replace("%", "Perc")
            .Replace("+", "Plus")
            .Replace("*", "Star");

        builder.Replace("(", "_")
            .Replace(".", "_")
            .Replace("=", "_")
            .Replace(":", "_")
            .Replace("-", "_")
            .Replace("#", "_");

        builder.Replace("\"", string.Empty)
            .Replace("@", string.Empty)
            .Replace("?", string.Empty)
            .Replace("[", string.Empty)
            .Replace("]", string.Empty)
            .Replace(")", string.Empty);

        return ConversionUtilities.ConvertToUpperCamelCase(builder.ToString(), true);
    }
}