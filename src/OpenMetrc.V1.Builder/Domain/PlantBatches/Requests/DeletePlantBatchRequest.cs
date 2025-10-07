using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.PlantBatches.Requests;

public partial record DeletePlantBatchRequest
{
    [JsonPropertyName("PlantBatch")]
    public string? PlantBatch { get; init; }

    [JsonPropertyName("Count")]
    public long? Count { get; init; }

    [JsonPropertyName("WasteMethodName")]
    public string? WasteMethodName { get; init; }

    [JsonPropertyName("WasteMaterialMixed")]
    public string? WasteMaterialMixed { get; init; }

    [JsonPropertyName("WasteReasonName")]
    public string? WasteReasonName { get; init; }

    [JsonPropertyName("ReasonNote")]
    public string? ReasonNote { get; init; }

    [JsonPropertyName("WasteWeight")]
    public double? WasteWeight { get; init; }

    [JsonPropertyName("WasteUnitOfMeasure")]
    public string? WasteUnitOfMeasure { get; init; }

    [JsonPropertyName("ActualDate")]
    public DateOnly? ActualDate { get; init; }

}
