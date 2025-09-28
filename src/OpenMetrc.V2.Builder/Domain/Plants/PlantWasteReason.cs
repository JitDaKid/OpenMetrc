using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.Plants;

public partial record PlantWasteReason
{
    [JsonPropertyName("Name")]
    public string? Name { get; init; }

    [JsonPropertyName("RequiresNote")]
    public bool? RequiresNote { get; init; }

    [JsonPropertyName("RequiresWasteWeight")]
    public bool? RequiresWasteWeight { get; init; }

    [JsonPropertyName("RequiresImmatureWasteWeight")]
    public bool? RequiresImmatureWasteWeight { get; init; }

    [JsonPropertyName("RequiresMatureWasteWeight")]
    public bool? RequiresMatureWasteWeight { get; init; }

}
