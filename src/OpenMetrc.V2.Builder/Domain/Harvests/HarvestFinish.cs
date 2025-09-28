using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.Harvests;

public partial record HarvestFinish
{
    [JsonPropertyName("Ids")]
    public ICollection<long>? Ids { get; init; }

}
