using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.ProcessingJob.Requests;

public partial record ProcessingJobTypeRequest
{
    [JsonPropertyName("Name")]
    public string? Name { get; init; }

    [JsonPropertyName("Description")]
    public string? Description { get; init; }

    [JsonPropertyName("Category")]
    public string? Category { get; init; }

    [JsonPropertyName("ProcessingSteps")]
    public string? ProcessingSteps { get; init; }

    [JsonPropertyName("Attributes")]
    public ICollection<string>? Attributes { get; init; }

    [JsonPropertyName("Id")]
    public long? Id { get; init; }

    [JsonPropertyName("CategoryName")]
    public string? CategoryName { get; init; }

}
