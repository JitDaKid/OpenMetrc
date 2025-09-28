using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.Transfers;

public partial record TransferHub
{
    [JsonPropertyName("Id")]
    public long? Id { get; init; }

    [JsonPropertyName("ManifestNumber")]
    public string? ManifestNumber { get; init; }

    [JsonPropertyName("ShipperFacilityLicenseNumber")]
    public string? ShipperFacilityLicenseNumber { get; init; }

    [JsonPropertyName("ShipperFacilityName")]
    public string? ShipperFacilityName { get; init; }

    [JsonPropertyName("DeliveryCount")]
    public long? DeliveryCount { get; init; }

    [JsonPropertyName("ReceivedDeliveryCount")]
    public long? ReceivedDeliveryCount { get; init; }

    [JsonPropertyName("PackageCount")]
    public long? PackageCount { get; init; }

    [JsonPropertyName("ReceivedPackageCount")]
    public long? ReceivedPackageCount { get; init; }

    [JsonPropertyName("IsVoided")]
    public bool? IsVoided { get; init; }

    [JsonPropertyName("CreatedDateTime")]
    public DateTimeOffset? CreatedDateTime { get; init; }

    [JsonPropertyName("LastModified")]
    public DateOnly? LastModified { get; init; }

    [JsonPropertyName("DeliveryId")]
    public long? DeliveryId { get; init; }

    [JsonPropertyName("ShipmentTransactionType")]
    public long? ShipmentTransactionType { get; init; }

    [JsonPropertyName("EstimatedDepartureDateTime")]
    public DateOnly? EstimatedDepartureDateTime { get; init; }

    [JsonPropertyName("EstimatedArrivalDateTime")]
    public DateOnly? EstimatedArrivalDateTime { get; init; }

    [JsonPropertyName("DeliveryPackageCount")]
    public long? DeliveryPackageCount { get; init; }

    [JsonPropertyName("DeliveryReceivedPackageCount")]
    public long? DeliveryReceivedPackageCount { get; init; }

    [JsonPropertyName("RejectedPackagesReturned")]
    public bool? RejectedPackagesReturned { get; init; }

    [JsonPropertyName("TransporterFacilityLicenseNumber")]
    public string? TransporterFacilityLicenseNumber { get; init; }

    [JsonPropertyName("TransporterFacilityName")]
    public string? TransporterFacilityName { get; init; }

    [JsonPropertyName("DriverName")]
    public string? DriverName { get; init; }

    [JsonPropertyName("DriverOccupationalLicenseNumber")]
    public string? DriverOccupationalLicenseNumber { get; init; }

    [JsonPropertyName("DriverVehicleLicenseNumber")]
    public string? DriverVehicleLicenseNumber { get; init; }

    [JsonPropertyName("VehicleMake")]
    public string? VehicleMake { get; init; }

    [JsonPropertyName("VehicleModel")]
    public string? VehicleModel { get; init; }

    [JsonPropertyName("VehicleLicensePlateNumber")]
    public string? VehicleLicensePlateNumber { get; init; }

    [JsonPropertyName("IsLayover")]
    public bool? IsLayover { get; init; }

}
