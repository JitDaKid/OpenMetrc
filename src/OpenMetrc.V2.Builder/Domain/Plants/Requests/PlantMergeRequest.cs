using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.Plants.Requests;

public partial record PlantMergeRequest
{
    [JsonPropertyName("TargetPlantGroupLabel")]
    public string? TargetPlantGroupLabel { get; init; }

    [JsonPropertyName("SourcePlantGroupLabel")]
    public string? SourcePlantGroupLabel { get; init; }

    [JsonPropertyName("MergeDate")]
    public DateOnly? MergeDate { get; init; }

}
