using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.PlantBatches.Requests;

public partial record PlantBatchSplitRequest
{
    [JsonPropertyName("PlantBatch")]
    public string? PlantBatch { get; init; }

    [JsonPropertyName("GroupName")]
    public string? GroupName { get; init; }

    [JsonPropertyName("Count")]
    public long? Count { get; init; }

    [JsonPropertyName("Location")]
    public string? Location { get; init; }

    [JsonPropertyName("Sublocation")]
    public string? Sublocation { get; init; }

    [JsonPropertyName("Strain")]
    public string? Strain { get; init; }

    [JsonPropertyName("PatientLicenseNumber")]
    public string? PatientLicenseNumber { get; init; }

    [JsonPropertyName("ActualDate")]
    public DateOnly? ActualDate { get; init; }

}
