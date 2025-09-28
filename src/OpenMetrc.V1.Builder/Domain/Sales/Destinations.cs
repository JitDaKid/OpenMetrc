using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.Sales;

public partial record Destinations
{
    [JsonPropertyName("Id")]
    public long? Id { get; init; }

    [JsonPropertyName("DeliveryNumber")]
    public object? DeliveryNumber { get; init; }

    [JsonPropertyName("FacilityLicenseNumber")]
    public object? FacilityLicenseNumber { get; init; }

    [JsonPropertyName("FacilityName")]
    public object? FacilityName { get; init; }

    [JsonPropertyName("ShipperFacilityLicenseNumber")]
    public object? ShipperFacilityLicenseNumber { get; init; }

    [JsonPropertyName("TransporterFacilityId")]
    public object? TransporterFacilityId { get; init; }

    [JsonPropertyName("TransporterFacilityLicenseNumber")]
    public object? TransporterFacilityLicenseNumber { get; init; }

    [JsonPropertyName("TransporterFacilityName")]
    public object? TransporterFacilityName { get; init; }

    [JsonPropertyName("SalesDateTime")]
    public DateTimeOffset? SalesDateTime { get; init; }

    [JsonPropertyName("SalesCustomerType")]
    public string? SalesCustomerType { get; init; }

    [JsonPropertyName("PatientLicenseNumber")]
    public object? PatientLicenseNumber { get; init; }

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

    [JsonPropertyName("RecipientName")]
    public object? RecipientName { get; init; }

    [JsonPropertyName("RecipientAddressStreet1")]
    public string? RecipientAddressStreet1 { get; init; }

    [JsonPropertyName("RecipientAddressStreet2")]
    public string? RecipientAddressStreet2 { get; init; }

    [JsonPropertyName("RecipientAddressCity")]
    public string? RecipientAddressCity { get; init; }

    [JsonPropertyName("RecipientDeliveryZoneId")]
    public object? RecipientDeliveryZoneId { get; init; }

    [JsonPropertyName("RecipientZoneId")]
    public object? RecipientZoneId { get; init; }

    [JsonPropertyName("RecipientDeliveryZoneName")]
    public object? RecipientDeliveryZoneName { get; init; }

    [JsonPropertyName("RecipientAddressCounty")]
    public object? RecipientAddressCounty { get; init; }

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

    [JsonPropertyName("ActualDepartureDateTime")]
    public object? ActualDepartureDateTime { get; init; }

    [JsonPropertyName("EstimatedArrivalDateTime")]
    public DateTimeOffset? EstimatedArrivalDateTime { get; init; }

    [JsonPropertyName("ActualArrivalDateTime")]
    public object? ActualArrivalDateTime { get; init; }

    [JsonPropertyName("EstimatedReturnDepartureDateTime")]
    public object? EstimatedReturnDepartureDateTime { get; init; }

    [JsonPropertyName("ActualReturnDepartureDateTime")]
    public object? ActualReturnDepartureDateTime { get; init; }

    [JsonPropertyName("EstimatedReturnArrivalDateTime")]
    public object? EstimatedReturnArrivalDateTime { get; init; }

    [JsonPropertyName("ActualReturnArrivalDateTime")]
    public object? ActualReturnArrivalDateTime { get; init; }

    [JsonPropertyName("TotalPackages")]
    public long? TotalPackages { get; init; }

    [JsonPropertyName("TotalPrice")]
    public double? TotalPrice { get; init; }

    [JsonPropertyName("AcceptedDateTime")]
    public object? AcceptedDateTime { get; init; }

    [JsonPropertyName("Transactions")]
    public ICollection<object>? Transactions { get; init; }

    [JsonPropertyName("CompletedDateTime")]
    public object? CompletedDateTime { get; init; }

    [JsonPropertyName("SalesDeliveryState")]
    public string? SalesDeliveryState { get; init; }

    [JsonPropertyName("VoidedDate")]
    public object? VoidedDate { get; init; }

    [JsonPropertyName("RecordedDateTime")]
    public DateOnly? RecordedDateTime { get; init; }

    [JsonPropertyName("RecordedByUserName")]
    public object? RecordedByUserName { get; init; }

    [JsonPropertyName("LastModified")]
    public DateOnly? LastModified { get; init; }

    [JsonPropertyName("PhoneNumberForQuestions")]
    public object? PhoneNumberForQuestions { get; init; }

    [JsonPropertyName("RecipientLicenseNumber")]
    public string? RecipientLicenseNumber { get; init; }

    [JsonPropertyName("InvoiceNumber")]
    public string? InvoiceNumber { get; init; }

    [JsonPropertyName("TransferTypeName")]
    public string? TransferTypeName { get; init; }

    [JsonPropertyName("GrossWeight")]
    public object? GrossWeight { get; init; }

    [JsonPropertyName("GrossUnitOfWeightId")]
    public object? GrossUnitOfWeightId { get; init; }

    [JsonPropertyName("Transporters")]
    public ICollection<Transporters>? Transporters { get; init; }

    [JsonPropertyName("Packages")]
    public ICollection<object>? Packages { get; init; }

    [JsonPropertyName("TransferDestinationId")]
    public object? TransferDestinationId { get; init; }

}
