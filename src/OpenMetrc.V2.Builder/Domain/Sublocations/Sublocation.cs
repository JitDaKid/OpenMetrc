using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.Sublocations;

public partial record Sublocation
{
    [JsonPropertyName("Ids")]
    public ICollection<long>? Ids { get; init; }

}
