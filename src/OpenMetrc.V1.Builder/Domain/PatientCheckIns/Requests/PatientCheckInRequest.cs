using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.PatientCheckIns.Requests;

public partial record PatientCheckInRequest
{
    [JsonPropertyName("PatientLicenseNumber")]
    public string? PatientLicenseNumber { get; init; }

    [JsonPropertyName("CheckInLocationId")]
    public long? CheckInLocationId { get; init; }

    [JsonPropertyName("RegistrationStartDate")]
    public DateOnly? RegistrationStartDate { get; init; }

    [JsonPropertyName("RegistrationExpiryDate")]
    public DateOnly? RegistrationExpiryDate { get; init; }

    [JsonPropertyName("CheckInDate")]
    public DateOnly? CheckInDate { get; init; }

    [JsonPropertyName("Id")]
    public long? Id { get; init; }

}
