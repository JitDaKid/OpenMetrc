using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.Plants.Requests;

public partial record PlantAdjustRequest
{
    [JsonPropertyName("Id")]
    public long? Id { get; init; }

    [JsonPropertyName("AdjustCount")]
    public long? AdjustCount { get; init; }

    [JsonPropertyName("AdjustReason")]
    public string? AdjustReason { get; init; }

    [JsonPropertyName("ReasonNote")]
    public string? ReasonNote { get; init; }

    [JsonPropertyName("AdjustmentDate")]
    public DateOnly? AdjustmentDate { get; init; }

    [JsonPropertyName("Label")]
    public string? Label { get; init; }

}
