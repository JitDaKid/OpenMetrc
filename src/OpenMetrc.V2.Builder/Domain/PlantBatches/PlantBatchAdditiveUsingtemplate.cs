using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.PlantBatches;

public partial record PlantBatchAdditiveUsingtemplate
{
    [JsonPropertyName("Ids")]
    public ICollection<long>? Ids { get; init; }

}
