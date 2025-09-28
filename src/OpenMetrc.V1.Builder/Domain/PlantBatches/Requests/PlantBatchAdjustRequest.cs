using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.PlantBatches.Requests;

public partial record PlantBatchAdjustRequest
{
    [JsonPropertyName("PlantBatchName")]
    public string? PlantBatchName { get; init; }

    [JsonPropertyName("Quantity")]
    public long? Quantity { get; init; }

    [JsonPropertyName("AdjustmentReason")]
    public string? AdjustmentReason { get; init; }

    [JsonPropertyName("AdjustmentDate")]
    public DateOnly? AdjustmentDate { get; init; }

    [JsonPropertyName("ReasonNote")]
    public string? ReasonNote { get; init; }

}
