using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.WasteMethods;

public partial record WasteMethod
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
