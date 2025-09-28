using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.PlantBatches.Requests;

public partial record PlantBatchPlantingRequest
{
    [JsonPropertyName("Name")]
    public string? Name { get; init; }

    [JsonPropertyName("Type")]
    public string? Type { get; init; }

    [JsonPropertyName("Count")]
    public long? Count { get; init; }

    [JsonPropertyName("Strain")]
    public string? Strain { get; init; }

    [JsonPropertyName("PatientLicenseNumber")]
    public string? PatientLicenseNumber { get; init; }

    [JsonPropertyName("ActualDate")]
    public DateOnly? ActualDate { get; init; }

    [JsonPropertyName("SourcePlantBatches")]
    public ICollection<SourcePlantBatches>? SourcePlantBatches { get; init; }

}
