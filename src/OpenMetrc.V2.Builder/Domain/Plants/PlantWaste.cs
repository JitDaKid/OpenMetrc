using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.Plants;

public partial record PlantWaste
{
    [JsonPropertyName("PlantWasteNumber")]
    public string? PlantWasteNumber { get; init; }

    [JsonPropertyName("WasteMethodName")]
    public string? WasteMethodName { get; init; }

    [JsonPropertyName("WasteWeight")]
    public double? WasteWeight { get; init; }

    [JsonPropertyName("WasteUnitOfMeasureName")]
    public string? WasteUnitOfMeasureName { get; init; }

    [JsonPropertyName("WasteReasonName")]
    public string? WasteReasonName { get; init; }

    [JsonPropertyName("PlantCount")]
    public long? PlantCount { get; init; }

    [JsonPropertyName("WasteDate")]
    public DateOnly? WasteDate { get; init; }

    [JsonPropertyName("Ids")]
    public ICollection<long>? Ids { get; init; }

}
