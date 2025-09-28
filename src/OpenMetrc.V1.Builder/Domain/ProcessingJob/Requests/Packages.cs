using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.ProcessingJob.Requests;

public partial record Packages
{
    [JsonPropertyName("Label")]
    public string? Label { get; init; }

    [JsonPropertyName("Quantity")]
    public double? Quantity { get; init; }

    [JsonPropertyName("UnitOfMeasure")]
    public string? UnitOfMeasure { get; init; }

    [JsonPropertyName("PackageId")]
    public long? PackageId { get; init; }

    [JsonPropertyName("PackageLabel")]
    public string? PackageLabel { get; init; }

    [JsonPropertyName("ProductName")]
    public object? ProductName { get; init; }

    [JsonPropertyName("ProductCategoryName")]
    public object? ProductCategoryName { get; init; }

    [JsonPropertyName("ItemStrainName")]
    public object? ItemStrainName { get; init; }

    [JsonPropertyName("ItemUnitCbdPercent")]
    public object? ItemUnitCbdPercent { get; init; }

    [JsonPropertyName("ItemUnitCbdContent")]
    public object? ItemUnitCbdContent { get; init; }

    [JsonPropertyName("ItemUnitCbdContentUnitOfMeasureName")]
    public object? ItemUnitCbdContentUnitOfMeasureName { get; init; }

    [JsonPropertyName("ItemUnitCbdContentDose")]
    public object? ItemUnitCbdContentDose { get; init; }

    [JsonPropertyName("ItemUnitCbdContentDoseUnitOfMeasureName")]
    public object? ItemUnitCbdContentDoseUnitOfMeasureName { get; init; }

    [JsonPropertyName("ItemUnitThcPercent")]
    public object? ItemUnitThcPercent { get; init; }

    [JsonPropertyName("ItemUnitThcContent")]
    public object? ItemUnitThcContent { get; init; }

    [JsonPropertyName("ItemUnitThcContentUnitOfMeasureName")]
    public object? ItemUnitThcContentUnitOfMeasureName { get; init; }

    [JsonPropertyName("ItemUnitThcContentDose")]
    public object? ItemUnitThcContentDose { get; init; }

    [JsonPropertyName("ItemUnitThcContentDoseUnitOfMeasureName")]
    public object? ItemUnitThcContentDoseUnitOfMeasureName { get; init; }

    [JsonPropertyName("ItemUnitVolume")]
    public object? ItemUnitVolume { get; init; }

    [JsonPropertyName("ItemUnitVolumeUnitOfMeasureName")]
    public object? ItemUnitVolumeUnitOfMeasureName { get; init; }

    [JsonPropertyName("ItemUnitWeight")]
    public object? ItemUnitWeight { get; init; }

    [JsonPropertyName("ItemUnitWeightUnitOfMeasureName")]
    public object? ItemUnitWeightUnitOfMeasureName { get; init; }

    [JsonPropertyName("ItemServingSize")]
    public object? ItemServingSize { get; init; }

    [JsonPropertyName("ItemSupplyDurationDays")]
    public object? ItemSupplyDurationDays { get; init; }

    [JsonPropertyName("ItemUnitQuantity")]
    public object? ItemUnitQuantity { get; init; }

    [JsonPropertyName("ItemUnitQuantityUnitOfMeasureName")]
    public object? ItemUnitQuantityUnitOfMeasureName { get; init; }

    [JsonPropertyName("UnitOfMeasureName")]
    public string? UnitOfMeasureName { get; init; }

    [JsonPropertyName("UnitOfMeasureAbbreviation")]
    public object? UnitOfMeasureAbbreviation { get; init; }

    [JsonPropertyName("TotalPrice")]
    public double? TotalPrice { get; init; }

    [JsonPropertyName("RetailerDeliveryState")]
    public object? RetailerDeliveryState { get; init; }

    [JsonPropertyName("ArchivedDate")]
    public object? ArchivedDate { get; init; }

    [JsonPropertyName("RecordedDateTime")]
    public DateOnly? RecordedDateTime { get; init; }

    [JsonPropertyName("RecordedByUserName")]
    public object? RecordedByUserName { get; init; }

    [JsonPropertyName("CompletedDateTime")]
    public object? CompletedDateTime { get; init; }

    [JsonPropertyName("LastModified")]
    public DateOnly? LastModified { get; init; }

    [JsonPropertyName("IsOnRecall")]
    public object? IsOnRecall { get; init; }

    [JsonPropertyName("DateTime")]
    public DateOnly? DateTime { get; init; }

    [JsonPropertyName("EndQuantity")]
    public double? EndQuantity { get; init; }

    [JsonPropertyName("EndUnitOfMeasure")]
    public string? EndUnitOfMeasure { get; init; }

    [JsonPropertyName("RemoveCurrentPackage")]
    public bool? RemoveCurrentPackage { get; init; }

    [JsonPropertyName("ItemName")]
    public string? ItemName { get; init; }

    [JsonPropertyName("PackagedDate")]
    public DateOnly? PackagedDate { get; init; }

    [JsonPropertyName("ExpirationDate")]
    public object? ExpirationDate { get; init; }

    [JsonPropertyName("SellByDate")]
    public object? SellByDate { get; init; }

    [JsonPropertyName("UseByDate")]
    public object? UseByDate { get; init; }

    [JsonPropertyName("GrossWeight")]
    public double? GrossWeight { get; init; }

    [JsonPropertyName("GrossUnitOfWeightName")]
    public string? GrossUnitOfWeightName { get; init; }

    [JsonPropertyName("WholesalePrice")]
    public object? WholesalePrice { get; init; }

    [JsonPropertyName("ExternalId")]
    public string? ExternalId { get; init; }

}
