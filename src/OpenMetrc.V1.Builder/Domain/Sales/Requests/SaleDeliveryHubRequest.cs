using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.Sales.Requests;

public partial record SaleDeliveryHubRequest
{
    [JsonPropertyName("Id")]
    public long? Id { get; init; }

    [JsonPropertyName("TransporterFacilityId")]
    public string? TransporterFacilityId { get; init; }

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

    [JsonPropertyName("PlannedRoute")]
    public string? PlannedRoute { get; init; }

    [JsonPropertyName("EstimatedDepartureDateTime")]
    public DateTimeOffset? EstimatedDepartureDateTime { get; init; }

    [JsonPropertyName("EstimatedArrivalDateTime")]
    public DateTimeOffset? EstimatedArrivalDateTime { get; init; }

}
