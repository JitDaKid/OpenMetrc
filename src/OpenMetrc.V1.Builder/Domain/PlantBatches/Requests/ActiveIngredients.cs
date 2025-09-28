using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.PlantBatches.Requests;

public partial record ActiveIngredients
{
    [JsonPropertyName("Name")]
    public string? Name { get; init; }

    [JsonPropertyName("Percentage")]
    public double? Percentage { get; init; }

}
