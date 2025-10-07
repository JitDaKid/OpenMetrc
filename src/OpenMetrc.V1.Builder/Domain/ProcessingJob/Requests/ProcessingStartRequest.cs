using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.ProcessingJob.Requests;

public partial record ProcessingStartRequest
{
    [JsonPropertyName("JobName")]
    public string? JobName { get; init; }

    [JsonPropertyName("JobType")]
    public string? JobType { get; init; }

    [JsonPropertyName("CountUnitOfMeasure")]
    public string? CountUnitOfMeasure { get; init; }

    [JsonPropertyName("VolumeUnitOfMeasure")]
    public string? VolumeUnitOfMeasure { get; init; }

    [JsonPropertyName("WeightUnitOfMeasure")]
    public string? WeightUnitOfMeasure { get; init; }

    [JsonPropertyName("Packages")]
    public ICollection<Packages>? Packages { get; init; }

    [JsonPropertyName("StartDate")]
    public DateOnly? StartDate { get; init; }

}
