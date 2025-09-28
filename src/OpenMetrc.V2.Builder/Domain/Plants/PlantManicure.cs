using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.Plants;

public partial record PlantManicure
{
    [JsonPropertyName("Ids")]
    public ICollection<long>? Ids { get; init; }

}
