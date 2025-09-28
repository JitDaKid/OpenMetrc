using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.Harvests.Requests;

public partial record Ingredients
{
    [JsonPropertyName("HarvestId")]
    public object? HarvestId { get; init; }

    [JsonPropertyName("HarvestName")]
    public string? HarvestName { get; init; }

    [JsonPropertyName("Weight")]
    public double? Weight { get; init; }

    [JsonPropertyName("UnitOfWeight")]
    public string? UnitOfWeight { get; init; }

    [JsonPropertyName("Package")]
    public string? Package { get; init; }

    [JsonPropertyName("Quantity")]
    public double? Quantity { get; init; }

    [JsonPropertyName("UnitOfMeasure")]
    public string? UnitOfMeasure { get; init; }

}
