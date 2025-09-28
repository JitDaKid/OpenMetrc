using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.Harvests;

public partial record HarvestPackageTesting
{
    [JsonPropertyName("Ids")]
    public ICollection<long>? Ids { get; init; }

}
