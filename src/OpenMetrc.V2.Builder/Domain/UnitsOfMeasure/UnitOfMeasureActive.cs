using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.UnitsOfMeasure;

public partial record UnitOfMeasureActive
{
    [JsonPropertyName("QuantityType")]
    public string? QuantityType { get; init; }

    [JsonPropertyName("Name")]
    public string? Name { get; init; }

    [JsonPropertyName("Abbreviation")]
    public string? Abbreviation { get; init; }

}
