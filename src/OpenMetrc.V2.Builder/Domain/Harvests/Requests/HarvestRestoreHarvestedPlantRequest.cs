using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.Harvests.Requests;

public partial record HarvestRestoreHarvestedPlantRequest
{
    [JsonPropertyName("HarvestId")]
    public long? HarvestId { get; init; }

    [JsonPropertyName("PlantTags")]
    public ICollection<string>? PlantTags { get; init; }

}
