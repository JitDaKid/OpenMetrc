using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.Plants;

public partial record PlantWasteMethodAll
{
    [JsonPropertyName("Name")]
    public string? Name { get; init; }

    [JsonPropertyName("ForPlants")]
    public bool? ForPlants { get; init; }

    [JsonPropertyName("ForProductDestruction")]
    public bool? ForProductDestruction { get; init; }

    [JsonPropertyName("LastModified")]
    public DateOnly? LastModified { get; init; }

}
