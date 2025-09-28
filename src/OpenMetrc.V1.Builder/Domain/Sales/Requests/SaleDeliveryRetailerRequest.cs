using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.Sales.Requests;

public partial record SaleDeliveryRetailerRequest
{
    [JsonPropertyName("DateTime")]
    public DateTimeOffset? DateTime { get; init; }

    [JsonPropertyName("DriverEmployeeId")]
    public string? DriverEmployeeId { get; init; }

    [JsonPropertyName("DriverName")]
    public string? DriverName { get; init; }

    [JsonPropertyName("DriversLicenseNumber")]
    public string? DriversLicenseNumber { get; init; }

    [JsonPropertyName("PhoneNumberForQuestions")]
    public string? PhoneNumberForQuestions { get; init; }

    [JsonPropertyName("VehicleMake")]
    public string? VehicleMake { get; init; }

    [JsonPropertyName("VehicleModel")]
    public string? VehicleModel { get; init; }

    [JsonPropertyName("VehicleLicensePlateNumber")]
    public string? VehicleLicensePlateNumber { get; init; }

    [JsonPropertyName("EstimatedDepartureDateTime")]
    public DateTimeOffset? EstimatedDepartureDateTime { get; init; }

    [JsonPropertyName("Destinations")]
    public ICollection<object>? Destinations { get; init; }

    [JsonPropertyName("Packages")]
    public ICollection<object>? Packages { get; init; }

    [JsonPropertyName("Id")]
    public long? Id { get; init; }

}
