using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.Locations;

public partial record LocationInactive
{
    [JsonPropertyName("Id")]
    public long? Id { get; init; }

    [JsonPropertyName("Name")]
    public string? Name { get; init; }

    [JsonPropertyName("LocationTypeId")]
    public long? LocationTypeId { get; init; }

    [JsonPropertyName("LocationTypeName")]
    public string? LocationTypeName { get; init; }

    [JsonPropertyName("ForPlantBatches")]
    public bool? ForPlantBatches { get; init; }

    [JsonPropertyName("ForPlants")]
    public bool? ForPlants { get; init; }

    [JsonPropertyName("ForHarvests")]
    public bool? ForHarvests { get; init; }

    [JsonPropertyName("ForPackages")]
    public bool? ForPackages { get; init; }

}
