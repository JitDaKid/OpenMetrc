using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.Transfers;

public partial record TransferDeliveryByIdPackage
{
    [JsonPropertyName("PackageId")]
    public long? PackageId { get; init; }

    [JsonPropertyName("PackageLabel")]
    public string? PackageLabel { get; init; }

    [JsonPropertyName("PackageType")]
    public string? PackageType { get; init; }

    [JsonPropertyName("ItemId")]
    public long? ItemId { get; init; }

    [JsonPropertyName("ItemName")]
    public string? ItemName { get; init; }

    [JsonPropertyName("ItemCategoryName")]
    public string? ItemCategoryName { get; init; }

    [JsonPropertyName("LabTestingState")]
    public string? LabTestingState { get; init; }

    [JsonPropertyName("IsTradeSample")]
    public bool? IsTradeSample { get; init; }

    [JsonPropertyName("IsTradeSamplePersistent")]
    public bool? IsTradeSamplePersistent { get; init; }

    [JsonPropertyName("SourcePackageIsTradeSample")]
    public bool? SourcePackageIsTradeSample { get; init; }

    [JsonPropertyName("IsDonation")]
    public bool? IsDonation { get; init; }

    [JsonPropertyName("SourcePackageIsDonation")]
    public bool? SourcePackageIsDonation { get; init; }

    [JsonPropertyName("IsTestingSample")]
    public bool? IsTestingSample { get; init; }

    [JsonPropertyName("ProductRequiresRemediation")]
    public bool? ProductRequiresRemediation { get; init; }

    [JsonPropertyName("ContainsRemediatedProduct")]
    public bool? ContainsRemediatedProduct { get; init; }

    [JsonPropertyName("ShipmentPackageState")]
    public string? ShipmentPackageState { get; init; }

    [JsonPropertyName("ShippedQuantity")]
    public double? ShippedQuantity { get; init; }

    [JsonPropertyName("ShippedUnitOfMeasureName")]
    public string? ShippedUnitOfMeasureName { get; init; }

    [JsonPropertyName("ReceivedQuantity")]
    public double? ReceivedQuantity { get; init; }

    [JsonPropertyName("ReceivedUnitOfMeasureName")]
    public string? ReceivedUnitOfMeasureName { get; init; }

    [JsonPropertyName("ProductLabel")]
    public object? ProductLabel { get; init; }

}
