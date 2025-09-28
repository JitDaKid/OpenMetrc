using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.Transfers.Requests;

public partial record Transporters
{
    [JsonPropertyName("TransporterFacilityLicenseNumber")]
    public string? TransporterFacilityLicenseNumber { get; init; }

    [JsonPropertyName("DriverOccupationalLicenseNumber")]
    public string? DriverOccupationalLicenseNumber { get; init; }

    [JsonPropertyName("DriverName")]
    public string? DriverName { get; init; }

    [JsonPropertyName("DriverLicenseNumber")]
    public string? DriverLicenseNumber { get; init; }

    [JsonPropertyName("DriverLayoverLeg")]
    public string? DriverLayoverLeg { get; init; }

    [JsonPropertyName("PhoneNumberForQuestions")]
    public string? PhoneNumberForQuestions { get; init; }

    [JsonPropertyName("VehicleMake")]
    public string? VehicleMake { get; init; }

    [JsonPropertyName("VehicleModel")]
    public string? VehicleModel { get; init; }

    [JsonPropertyName("VehicleLicensePlateNumber")]
    public string? VehicleLicensePlateNumber { get; init; }

    [JsonPropertyName("IsLayover")]
    public bool? IsLayover { get; init; }

    [JsonPropertyName("EstimatedDepartureDateTime")]
    public DateTimeOffset? EstimatedDepartureDateTime { get; init; }

    [JsonPropertyName("EstimatedArrivalDateTime")]
    public DateTimeOffset? EstimatedArrivalDateTime { get; init; }

    [JsonPropertyName("TransporterDetails")]
    public ICollection<TransporterDetails>? TransporterDetails { get; init; }

}
