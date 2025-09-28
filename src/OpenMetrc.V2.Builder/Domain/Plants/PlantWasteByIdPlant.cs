using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.Plants;

public partial record PlantWasteByIdPlant
{
    [JsonPropertyName("PlantWasteId")]
    public long? PlantWasteId { get; init; }

    [JsonPropertyName("PlantId")]
    public long? PlantId { get; init; }

    [JsonPropertyName("Label")]
    public string? Label { get; init; }

    [JsonPropertyName("StateName")]
    public string? StateName { get; init; }

    [JsonPropertyName("GrowthPhase")]
    public long? GrowthPhase { get; init; }

    [JsonPropertyName("LocationId")]
    public long? LocationId { get; init; }

    [JsonPropertyName("LocationName")]
    public string? LocationName { get; init; }

    [JsonPropertyName("SublocationId")]
    public long? SublocationId { get; init; }

    [JsonPropertyName("WasteAmount")]
    public double? WasteAmount { get; init; }

    [JsonPropertyName("WasteUnitOfMeasureAbbreviation")]
    public string? WasteUnitOfMeasureAbbreviation { get; init; }

}
