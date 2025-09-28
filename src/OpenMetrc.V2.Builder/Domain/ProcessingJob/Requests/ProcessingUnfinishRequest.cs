using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.ProcessingJob.Requests;

public partial record ProcessingUnfinishRequest
{
    [JsonPropertyName("Id")]
    public long? Id { get; init; }

}
