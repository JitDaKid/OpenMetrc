using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.PlantBatches;

public partial record PlantBatchWaste
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

    [JsonPropertyName("PlantBatchId")]
    public long? PlantBatchId { get; init; }

    [JsonPropertyName("PlantBatchName")]
    public string? PlantBatchName { get; init; }

    [JsonPropertyName("PlantCount")]
    public long? PlantCount { get; init; }

    [JsonPropertyName("WasteDate")]
    public DateOnly? WasteDate { get; init; }

    [JsonPropertyName("Ids")]
    public ICollection<long>? Ids { get; init; }

}
