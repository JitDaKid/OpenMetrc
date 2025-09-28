using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.Plants;

public partial record PlantAdditive
{
    [JsonPropertyName("ProductTradeName")]
    public string? ProductTradeName { get; init; }

    [JsonPropertyName("ProductSupplier")]
    public string? ProductSupplier { get; init; }

    [JsonPropertyName("ApplicationDevice")]
    public string? ApplicationDevice { get; init; }

    [JsonPropertyName("AmountUnitOfMeasure")]
    public string? AmountUnitOfMeasure { get; init; }

    [JsonPropertyName("TotalAmountApplied")]
    public double? TotalAmountApplied { get; init; }

    [JsonPropertyName("PlantCount")]
    public long? PlantCount { get; init; }

    [JsonPropertyName("Ids")]
    public ICollection<long>? Ids { get; init; }

}
