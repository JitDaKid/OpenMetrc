using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.Plants.Requests;

public partial record PlantSplitRequest
{
    [JsonPropertyName("SplitDate")]
    public DateOnly? SplitDate { get; init; }

    [JsonPropertyName("SourcePlantLabel")]
    public string? SourcePlantLabel { get; init; }

    [JsonPropertyName("PlantCount")]
    public long? PlantCount { get; init; }

    [JsonPropertyName("TagLabel")]
    public string? TagLabel { get; init; }

    [JsonPropertyName("StrainLabel")]
    public string? StrainLabel { get; init; }

}
