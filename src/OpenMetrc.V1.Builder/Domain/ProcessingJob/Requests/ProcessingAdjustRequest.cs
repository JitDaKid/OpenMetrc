using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.ProcessingJob.Requests;

public partial record ProcessingAdjustRequest
{
    [JsonPropertyName("Id")]
    public long? Id { get; init; }

    [JsonPropertyName("AdjustmentReason")]
    public string? AdjustmentReason { get; init; }

    [JsonPropertyName("AdjustmentDate")]
    public DateOnly? AdjustmentDate { get; init; }

    [JsonPropertyName("VolumeUnitOfMeasureName")]
    public string? VolumeUnitOfMeasureName { get; init; }

    [JsonPropertyName("WeightUnitOfMeasureName")]
    public string? WeightUnitOfMeasureName { get; init; }

    [JsonPropertyName("Packages")]
    public ICollection<Packages>? Packages { get; init; }

    [JsonPropertyName("CountUnitOfMeasureName")]
    public string? CountUnitOfMeasureName { get; init; }

}
