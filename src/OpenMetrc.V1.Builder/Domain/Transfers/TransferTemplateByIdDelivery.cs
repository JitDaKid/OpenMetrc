using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.Transfers;

public partial record TransferTemplateByIdDelivery
{
    [JsonPropertyName("Id")]
    public long? Id { get; init; }

    [JsonPropertyName("DeliveryNumber")]
    public long? DeliveryNumber { get; init; }

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

    [JsonPropertyName("PlannedRoute")]
    public string? PlannedRoute { get; init; }

    [JsonPropertyName("DeliveryPackageCount")]
    public long? DeliveryPackageCount { get; init; }

    [JsonPropertyName("DeliveryReceivedPackageCount")]
    public long? DeliveryReceivedPackageCount { get; init; }

    [JsonPropertyName("ReceivedDateTime")]
    public DateTimeOffset? ReceivedDateTime { get; init; }

    [JsonPropertyName("RejectedPackagesReturned")]
    public bool? RejectedPackagesReturned { get; init; }

}
