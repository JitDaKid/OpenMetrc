using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.Locations;

public partial record Location
{
    [JsonPropertyName("Ids")]
    public ICollection<long>? Ids { get; init; }

}
