using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.Patients.Requests;

public partial record PatientUpdateRequest
{
    [JsonPropertyName("LicenseNumber")]
    public string? LicenseNumber { get; init; }

    [JsonPropertyName("LicenseEffectiveStartDate")]
    public DateOnly? LicenseEffectiveStartDate { get; init; }

    [JsonPropertyName("LicenseEffectiveEndDate")]
    public DateOnly? LicenseEffectiveEndDate { get; init; }

    [JsonPropertyName("RecommendedPlants")]
    public long? RecommendedPlants { get; init; }

    [JsonPropertyName("RecommendedSmokableQuantity")]
    public double? RecommendedSmokableQuantity { get; init; }

    [JsonPropertyName("HasSalesLimitExemption")]
    public bool? HasSalesLimitExemption { get; init; }

    [JsonPropertyName("ActualDate")]
    public DateOnly? ActualDate { get; init; }

    [JsonPropertyName("NewLicenseNumber")]
    public string? NewLicenseNumber { get; init; }

}
