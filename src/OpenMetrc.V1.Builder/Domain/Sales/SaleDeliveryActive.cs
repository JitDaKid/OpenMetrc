using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.Sales;

public partial record SaleDeliveryActive
{
    [JsonPropertyName("Id")]
    public long? Id { get; init; }

    [JsonPropertyName("SalesDateTime")]
    public DateTimeOffset? SalesDateTime { get; init; }

    [JsonPropertyName("SalesCustomerType")]
    public string? SalesCustomerType { get; init; }

    [JsonPropertyName("ConsumerId")]
    public string? ConsumerId { get; init; }

    [JsonPropertyName("DriverEmployeeId")]
    public string? DriverEmployeeId { get; init; }

    [JsonPropertyName("DriverName")]
    public string? DriverName { get; init; }

    [JsonPropertyName("DriversLicenseNumber")]
    public string? DriversLicenseNumber { get; init; }

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

    [JsonPropertyName("Direction")]
    public string? Direction { get; init; }

    [JsonPropertyName("EstimatedDepartureDateTime")]
    public DateTimeOffset? EstimatedDepartureDateTime { get; init; }

    [JsonPropertyName("EstimatedArrivalDateTime")]
    public DateTimeOffset? EstimatedArrivalDateTime { get; init; }

    [JsonPropertyName("TotalPackages")]
    public long? TotalPackages { get; init; }

    [JsonPropertyName("TotalPrice")]
    public double? TotalPrice { get; init; }

    [JsonPropertyName("Transactions")]
    public ICollection<object>? Transactions { get; init; }

    [JsonPropertyName("SalesDeliveryState")]
    public string? SalesDeliveryState { get; init; }

    [JsonPropertyName("RecordedDateTime")]
    public DateOnly? RecordedDateTime { get; init; }

    [JsonPropertyName("LastModified")]
    public DateOnly? LastModified { get; init; }

}
