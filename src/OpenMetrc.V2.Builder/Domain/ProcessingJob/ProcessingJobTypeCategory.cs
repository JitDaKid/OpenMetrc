using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.ProcessingJob;

public partial record ProcessingJobTypeCategory
{
    [JsonPropertyName("Id")]
    public long? Id { get; init; }

    [JsonPropertyName("Name")]
    public string? Name { get; init; }

    [JsonPropertyName("ForItems")]
    public bool? ForItems { get; init; }

    [JsonPropertyName("ForProcessingJobs")]
    public bool? ForProcessingJobs { get; init; }

    [JsonPropertyName("RequiresProcessingJobAttributes")]
    public bool? RequiresProcessingJobAttributes { get; init; }

}
