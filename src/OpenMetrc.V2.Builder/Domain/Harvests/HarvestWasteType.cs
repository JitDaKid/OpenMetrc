using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.Harvests;

public partial record HarvestWasteType
{
    [JsonPropertyName("Name")]
    public string? Name { get; init; }

}
