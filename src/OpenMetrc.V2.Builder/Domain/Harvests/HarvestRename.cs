using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.Harvests;

public partial record HarvestRename
{
    [JsonPropertyName("Ids")]
    public ICollection<long>? Ids { get; init; }

}
