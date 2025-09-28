using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.Tags;

public partial record TagPlantAvailable
{
    [JsonPropertyName("Id")]
    public long? Id { get; init; }

    [JsonPropertyName("TagInventoryTypeName")]
    public string? TagInventoryTypeName { get; init; }

    [JsonPropertyName("MaxGroupSize")]
    public long? MaxGroupSize { get; init; }

    [JsonPropertyName("FacilityId")]
    public long? FacilityId { get; init; }

    [JsonPropertyName("Label")]
    public string? Label { get; init; }

}
