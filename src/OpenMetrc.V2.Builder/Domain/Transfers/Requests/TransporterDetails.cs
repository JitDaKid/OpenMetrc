using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.Transfers.Requests;

public partial record TransporterDetails
{
    [JsonPropertyName("DriverOccupationalLicenseNumber")]
    public string? DriverOccupationalLicenseNumber { get; init; }

    [JsonPropertyName("DriverName")]
    public string? DriverName { get; init; }

    [JsonPropertyName("DriverLicenseNumber")]
    public string? DriverLicenseNumber { get; init; }

    [JsonPropertyName("DriverLayoverLeg")]
    public string? DriverLayoverLeg { get; init; }

    [JsonPropertyName("VehicleMake")]
    public string? VehicleMake { get; init; }

    [JsonPropertyName("VehicleModel")]
    public string? VehicleModel { get; init; }

    [JsonPropertyName("VehicleLicensePlateNumber")]
    public string? VehicleLicensePlateNumber { get; init; }

}
