using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.PlantBatches.Requests;

public partial record PlantBatchGrowthPhaseRequest
{
    [JsonPropertyName("Name")]
    public string? Name { get; init; }

    [JsonPropertyName("Count")]
    public long? Count { get; init; }

    [JsonPropertyName("StartingTag")]
    public string? StartingTag { get; init; }

    [JsonPropertyName("GrowthPhase")]
    public string? GrowthPhase { get; init; }

    [JsonPropertyName("NewLocation")]
    public string? NewLocation { get; init; }

    [JsonPropertyName("NewSublocation")]
    public string? NewSublocation { get; init; }

    [JsonPropertyName("GrowthDate")]
    public DateOnly? GrowthDate { get; init; }

    [JsonPropertyName("PatientLicenseNumber")]
    public string? PatientLicenseNumber { get; init; }

}
