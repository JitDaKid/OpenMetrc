using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.ProcessingJob;

public partial record ProcessingJobType
{
    [JsonPropertyName("Ids")]
    public ICollection<long>? Ids { get; init; }

}
