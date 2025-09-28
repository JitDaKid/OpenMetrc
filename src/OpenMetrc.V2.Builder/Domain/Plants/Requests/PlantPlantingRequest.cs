using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.Plants.Requests;

public partial record PlantPlantingRequest
{
    [JsonPropertyName("PlantLabel")]
    public string? PlantLabel { get; init; }

    [JsonPropertyName("PlantBatchName")]
    public string? PlantBatchName { get; init; }

    [JsonPropertyName("PlantBatchType")]
    public string? PlantBatchType { get; init; }

    [JsonPropertyName("PlantCount")]
    public long? PlantCount { get; init; }

    [JsonPropertyName("LocationName")]
    public string? LocationName { get; init; }

    [JsonPropertyName("SublocationName")]
    public string? SublocationName { get; init; }

    [JsonPropertyName("StrainName")]
    public string? StrainName { get; init; }

    [JsonPropertyName("PatientLicenseNumber")]
    public string? PatientLicenseNumber { get; init; }

    [JsonPropertyName("ActualDate")]
    public DateTimeOffset? ActualDate { get; init; }

}
