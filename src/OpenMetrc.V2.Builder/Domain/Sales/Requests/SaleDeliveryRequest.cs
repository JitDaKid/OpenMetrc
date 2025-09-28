using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.Sales.Requests;

public partial record SaleDeliveryRequest
{
    [JsonPropertyName("TransporterFacilityLicenseNumber")]
    public string? TransporterFacilityLicenseNumber { get; init; }

    [JsonPropertyName("SalesDateTime")]
    public DateTimeOffset? SalesDateTime { get; init; }

    [JsonPropertyName("SalesCustomerType")]
    public string? SalesCustomerType { get; init; }

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

    [JsonPropertyName("RecipientAddressStreet1")]
    public string? RecipientAddressStreet1 { get; init; }

    [JsonPropertyName("RecipientAddressStreet2")]
    public string? RecipientAddressStreet2 { get; init; }

    [JsonPropertyName("RecipientAddressCity")]
    public string? RecipientAddressCity { get; init; }

    [JsonPropertyName("RecipientAddressState")]
    public string? RecipientAddressState { get; init; }

    [JsonPropertyName("RecipientAddressPostalCode")]
    public string? RecipientAddressPostalCode { get; init; }

    [JsonPropertyName("PlannedRoute")]
    public string? PlannedRoute { get; init; }

    [JsonPropertyName("EstimatedDepartureDateTime")]
    public DateTimeOffset? EstimatedDepartureDateTime { get; init; }

    [JsonPropertyName("EstimatedArrivalDateTime")]
    public DateTimeOffset? EstimatedArrivalDateTime { get; init; }

    [JsonPropertyName("Transactions")]
    public ICollection<Transactions>? Transactions { get; init; }

    [JsonPropertyName("Id")]
    public long? Id { get; init; }

    [JsonPropertyName("RecipientZoneId")]
    public string? RecipientZoneId { get; init; }

}
