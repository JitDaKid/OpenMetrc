using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.Plants;

public partial record PlantSplit
{
    [JsonPropertyName("Ids")]
    public ICollection<long>? Ids { get; init; }

}
