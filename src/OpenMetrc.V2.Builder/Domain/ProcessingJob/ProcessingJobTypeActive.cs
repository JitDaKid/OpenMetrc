using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.ProcessingJob;

public partial record ProcessingJobTypeActive
{
    [JsonPropertyName("Id")]
    public long? Id { get; init; }

    [JsonPropertyName("Name")]
    public string? Name { get; init; }

    [JsonPropertyName("Description")]
    public string? Description { get; init; }

    [JsonPropertyName("CategoryName")]
    public string? CategoryName { get; init; }

    [JsonPropertyName("ForItems")]
    public bool? ForItems { get; init; }

    [JsonPropertyName("ForProcessingJobs")]
    public bool? ForProcessingJobs { get; init; }

    [JsonPropertyName("RequiresProcessingJobAttributes")]
    public bool? RequiresProcessingJobAttributes { get; init; }

    [JsonPropertyName("ProcessingSteps")]
    public string? ProcessingSteps { get; init; }

    [JsonPropertyName("Attributes")]
    public ICollection<Attributes>? Attributes { get; init; }

}
