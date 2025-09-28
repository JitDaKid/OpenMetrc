using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.PlantBatches;

public partial record PlantBatchPlanting
{
    [JsonPropertyName("Ids")]
    public ICollection<long>? Ids { get; init; }

}
