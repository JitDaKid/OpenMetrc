using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.Harvests;

public partial record HarvestPackage
{
    [JsonPropertyName("Ids")]
    public ICollection<long>? Ids { get; init; }

}
