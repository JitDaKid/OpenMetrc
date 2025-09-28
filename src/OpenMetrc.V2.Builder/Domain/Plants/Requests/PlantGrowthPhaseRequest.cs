using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.Plants.Requests;

public partial record PlantGrowthPhaseRequest
{
    [JsonPropertyName("Label")]
    public string? Label { get; init; }

    [JsonPropertyName("NewTag")]
    public string? NewTag { get; init; }

    [JsonPropertyName("GrowthPhase")]
    public string? GrowthPhase { get; init; }

    [JsonPropertyName("NewLocation")]
    public string? NewLocation { get; init; }

    [JsonPropertyName("GrowthDate")]
    public DateOnly? GrowthDate { get; init; }

    [JsonPropertyName("Id")]
    public long? Id { get; init; }

}
