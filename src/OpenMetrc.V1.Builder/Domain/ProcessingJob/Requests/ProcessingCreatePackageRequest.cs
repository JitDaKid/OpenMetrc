using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.ProcessingJob.Requests;

public partial record ProcessingCreatePackageRequest
{
    [JsonPropertyName("JobName")]
    public string? JobName { get; init; }

    [JsonPropertyName("Tag")]
    public string? Tag { get; init; }

    [JsonPropertyName("Quantity")]
    public double? Quantity { get; init; }

    [JsonPropertyName("UnitOfMeasure")]
    public string? UnitOfMeasure { get; init; }

    [JsonPropertyName("FinishProcessingJob")]
    public bool? FinishProcessingJob { get; init; }

}
