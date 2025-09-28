using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.Patients;

public partial record PatientActive
{
    [JsonPropertyName("PatientId")]
    public long? PatientId { get; init; }

    [JsonPropertyName("LicenseNumber")]
    public string? LicenseNumber { get; init; }

    [JsonPropertyName("RegistrationDate")]
    public DateOnly? RegistrationDate { get; init; }

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

    [JsonPropertyName("OtherFacilitiesCount")]
    public long? OtherFacilitiesCount { get; init; }

}
