using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.Transfers;

public partial record TransferIncoming
{
    [JsonPropertyName("Id")]
    public long? Id { get; init; }

    [JsonPropertyName("ManifestNumber")]
    public string? ManifestNumber { get; init; }

    [JsonPropertyName("ShipmentLicenseType")]
    public long? ShipmentLicenseType { get; init; }

    [JsonPropertyName("ShipperFacilityLicenseNumber")]
    public string? ShipperFacilityLicenseNumber { get; init; }

    [JsonPropertyName("ShipperFacilityName")]
    public string? ShipperFacilityName { get; init; }

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

    [JsonPropertyName("DeliveryCount")]
    public long? DeliveryCount { get; init; }

    [JsonPropertyName("ReceivedDeliveryCount")]
    public long? ReceivedDeliveryCount { get; init; }

    [JsonPropertyName("PackageCount")]
    public long? PackageCount { get; init; }

    [JsonPropertyName("ReceivedPackageCount")]
    public long? ReceivedPackageCount { get; init; }

    [JsonPropertyName("ContainsPlantPackage")]
    public bool? ContainsPlantPackage { get; init; }

    [JsonPropertyName("ContainsProductPackage")]
    public bool? ContainsProductPackage { get; init; }

    [JsonPropertyName("ContainsTradeSample")]
    public bool? ContainsTradeSample { get; init; }

    [JsonPropertyName("ContainsDonation")]
    public bool? ContainsDonation { get; init; }

    [JsonPropertyName("ContainsTestingSample")]
    public bool? ContainsTestingSample { get; init; }

    [JsonPropertyName("ContainsProductRequiresRemediation")]
    public bool? ContainsProductRequiresRemediation { get; init; }

    [JsonPropertyName("ContainsRemediatedProductPackage")]
    public bool? ContainsRemediatedProductPackage { get; init; }

    [JsonPropertyName("IsVoided")]
    public bool? IsVoided { get; init; }

    [JsonPropertyName("CreatedDateTime")]
    public DateTimeOffset? CreatedDateTime { get; init; }

    [JsonPropertyName("LastModified")]
    public DateOnly? LastModified { get; init; }

    [JsonPropertyName("DeliveryId")]
    public long? DeliveryId { get; init; }

    [JsonPropertyName("RecipientFacilityLicenseNumber")]
    public string? RecipientFacilityLicenseNumber { get; init; }

    [JsonPropertyName("RecipientFacilityName")]
    public string? RecipientFacilityName { get; init; }

    [JsonPropertyName("ShipmentTypeName")]
    public string? ShipmentTypeName { get; init; }

    [JsonPropertyName("ShipmentTransactionType")]
    public string? ShipmentTransactionType { get; init; }

    [JsonPropertyName("EstimatedDepartureDateTime")]
    public DateTimeOffset? EstimatedDepartureDateTime { get; init; }

    [JsonPropertyName("EstimatedArrivalDateTime")]
    public DateTimeOffset? EstimatedArrivalDateTime { get; init; }

    [JsonPropertyName("DeliveryPackageCount")]
    public long? DeliveryPackageCount { get; init; }

    [JsonPropertyName("DeliveryReceivedPackageCount")]
    public long? DeliveryReceivedPackageCount { get; init; }

    [JsonPropertyName("ReceivedDateTime")]
    public DateTimeOffset? ReceivedDateTime { get; init; }

}
