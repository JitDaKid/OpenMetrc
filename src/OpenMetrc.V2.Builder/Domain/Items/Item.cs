using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.Items;

public partial record Item
{
    [JsonPropertyName("Ids")]
    public ICollection<long>? Ids { get; init; }

    [JsonPropertyName("Id")]
    public long? Id { get; init; }

    [JsonPropertyName("Name")]
    public string? Name { get; init; }

    [JsonPropertyName("GlobalProductName")]
    public object? GlobalProductName { get; init; }

    [JsonPropertyName("GlobalProductNumber")]
    public object? GlobalProductNumber { get; init; }

    [JsonPropertyName("ProductCategoryName")]
    public string? ProductCategoryName { get; init; }

    [JsonPropertyName("ProductCategoryType")]
    public long? ProductCategoryType { get; init; }

    [JsonPropertyName("IsExpirationDateRequired")]
    public bool? IsExpirationDateRequired { get; init; }

    [JsonPropertyName("HasExpirationDate")]
    public bool? HasExpirationDate { get; init; }

    [JsonPropertyName("IsSellByDateRequired")]
    public bool? IsSellByDateRequired { get; init; }

    [JsonPropertyName("HasSellByDate")]
    public bool? HasSellByDate { get; init; }

    [JsonPropertyName("IsUseByDateRequired")]
    public bool? IsUseByDateRequired { get; init; }

    [JsonPropertyName("HasUseByDate")]
    public bool? HasUseByDate { get; init; }

    [JsonPropertyName("QuantityType")]
    public long? QuantityType { get; init; }

    [JsonPropertyName("DefaultLabTestingState")]
    public long? DefaultLabTestingState { get; init; }

    [JsonPropertyName("UnitOfMeasureName")]
    public object? UnitOfMeasureName { get; init; }

    [JsonPropertyName("ApprovalStatus")]
    public long? ApprovalStatus { get; init; }

    [JsonPropertyName("ApprovalStatusDateTime")]
    public DateOnly? ApprovalStatusDateTime { get; init; }

    [JsonPropertyName("StrainId")]
    public object? StrainId { get; init; }

    [JsonPropertyName("StrainName")]
    public object? StrainName { get; init; }

    [JsonPropertyName("ItemBrandId")]
    public long? ItemBrandId { get; init; }

    [JsonPropertyName("ItemBrandName")]
    public object? ItemBrandName { get; init; }

    [JsonPropertyName("AdministrationMethod")]
    public object? AdministrationMethod { get; init; }

    [JsonPropertyName("UnitCbdPercent")]
    public object? UnitCbdPercent { get; init; }

    [JsonPropertyName("UnitCbdContent")]
    public object? UnitCbdContent { get; init; }

    [JsonPropertyName("UnitCbdContentUnitOfMeasureName")]
    public object? UnitCbdContentUnitOfMeasureName { get; init; }

    [JsonPropertyName("UnitCbdContentDose")]
    public object? UnitCbdContentDose { get; init; }

    [JsonPropertyName("UnitCbdContentDoseUnitOfMeasureName")]
    public object? UnitCbdContentDoseUnitOfMeasureName { get; init; }

    [JsonPropertyName("UnitCbdAPercent")]
    public object? UnitCbdAPercent { get; init; }

    [JsonPropertyName("UnitCbdAContent")]
    public object? UnitCbdAContent { get; init; }

    [JsonPropertyName("UnitCbdAContentUnitOfMeasureName")]
    public object? UnitCbdAContentUnitOfMeasureName { get; init; }

    [JsonPropertyName("UnitCbdAContentDose")]
    public object? UnitCbdAContentDose { get; init; }

    [JsonPropertyName("UnitCbdAContentDoseUnitOfMeasureName")]
    public object? UnitCbdAContentDoseUnitOfMeasureName { get; init; }

    [JsonPropertyName("UnitThcAPercent")]
    public object? UnitThcAPercent { get; init; }

    [JsonPropertyName("UnitThcAContent")]
    public object? UnitThcAContent { get; init; }

    [JsonPropertyName("UnitThcAContentUnitOfMeasureName")]
    public object? UnitThcAContentUnitOfMeasureName { get; init; }

    [JsonPropertyName("UnitThcAContentDose")]
    public object? UnitThcAContentDose { get; init; }

    [JsonPropertyName("UnitThcAContentDoseUnitOfMeasureId")]
    public object? UnitThcAContentDoseUnitOfMeasureId { get; init; }

    [JsonPropertyName("UnitThcAContentDoseUnitOfMeasureName")]
    public object? UnitThcAContentDoseUnitOfMeasureName { get; init; }

    [JsonPropertyName("UnitThcPercent")]
    public object? UnitThcPercent { get; init; }

    [JsonPropertyName("UnitThcContent")]
    public object? UnitThcContent { get; init; }

    [JsonPropertyName("UnitThcContentUnitOfMeasureName")]
    public object? UnitThcContentUnitOfMeasureName { get; init; }

    [JsonPropertyName("UnitThcContentDose")]
    public object? UnitThcContentDose { get; init; }

    [JsonPropertyName("UnitThcContentDoseUnitOfMeasureId")]
    public object? UnitThcContentDoseUnitOfMeasureId { get; init; }

    [JsonPropertyName("UnitThcContentDoseUnitOfMeasureName")]
    public object? UnitThcContentDoseUnitOfMeasureName { get; init; }

    [JsonPropertyName("UnitVolume")]
    public object? UnitVolume { get; init; }

    [JsonPropertyName("UnitVolumeUnitOfMeasureName")]
    public object? UnitVolumeUnitOfMeasureName { get; init; }

    [JsonPropertyName("UnitWeight")]
    public object? UnitWeight { get; init; }

    [JsonPropertyName("UnitWeightUnitOfMeasureName")]
    public object? UnitWeightUnitOfMeasureName { get; init; }

    [JsonPropertyName("ServingSize")]
    public object? ServingSize { get; init; }

    [JsonPropertyName("NumberOfDoses")]
    public object? NumberOfDoses { get; init; }

    [JsonPropertyName("UnitQuantity")]
    public object? UnitQuantity { get; init; }

    [JsonPropertyName("UnitQuantityUnitOfMeasureName")]
    public object? UnitQuantityUnitOfMeasureName { get; init; }

    [JsonPropertyName("PublicIngredients")]
    public object? PublicIngredients { get; init; }

    [JsonPropertyName("Description")]
    public object? Description { get; init; }

    [JsonPropertyName("Allergens")]
    public object? Allergens { get; init; }

    [JsonPropertyName("ProductImages")]
    public ICollection<object>? ProductImages { get; init; }

    [JsonPropertyName("ProductPhotoDescription")]
    public object? ProductPhotoDescription { get; init; }

    [JsonPropertyName("LabelImages")]
    public ICollection<object>? LabelImages { get; init; }

    [JsonPropertyName("LabelPhotoDescription")]
    public object? LabelPhotoDescription { get; init; }

    [JsonPropertyName("PackagingImages")]
    public ICollection<object>? PackagingImages { get; init; }

    [JsonPropertyName("PackagingPhotoDescription")]
    public object? PackagingPhotoDescription { get; init; }

    [JsonPropertyName("ProductPDFDocuments")]
    public ICollection<object>? ProductPDFDocuments { get; init; }

    [JsonPropertyName("IsUsed")]
    public bool? IsUsed { get; init; }

    [JsonPropertyName("LabTestBatchNames")]
    public ICollection<object>? LabTestBatchNames { get; init; }

    [JsonPropertyName("ProcessingJobCategoryName")]
    public object? ProcessingJobCategoryName { get; init; }

    [JsonPropertyName("ProcessingJobTypeName")]
    public object? ProcessingJobTypeName { get; init; }

    [JsonPropertyName("ProductBrandName")]
    public object? ProductBrandName { get; init; }

}
