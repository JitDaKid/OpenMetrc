using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.Items;

public partial record ItemCategory
{
    [JsonPropertyName("Name")]
    public string? Name { get; init; }

    [JsonPropertyName("ProductCategoryType")]
    public string? ProductCategoryType { get; init; }

    [JsonPropertyName("QuantityType")]
    public string? QuantityType { get; init; }

    [JsonPropertyName("RequiresStrain")]
    public bool? RequiresStrain { get; init; }

    [JsonPropertyName("RequiresItemBrand")]
    public bool? RequiresItemBrand { get; init; }

    [JsonPropertyName("RequiresAdministrationMethod")]
    public bool? RequiresAdministrationMethod { get; init; }

    [JsonPropertyName("RequiresUnitCbdPercent")]
    public bool? RequiresUnitCbdPercent { get; init; }

    [JsonPropertyName("RequiresUnitCbdContent")]
    public bool? RequiresUnitCbdContent { get; init; }

    [JsonPropertyName("RequiresUnitCbdContentDose")]
    public bool? RequiresUnitCbdContentDose { get; init; }

    [JsonPropertyName("RequiresUnitCbdAPercent")]
    public bool? RequiresUnitCbdAPercent { get; init; }

    [JsonPropertyName("RequiresUnitCbdAContent")]
    public bool? RequiresUnitCbdAContent { get; init; }

    [JsonPropertyName("RequiresUnitCbdAContentDose")]
    public bool? RequiresUnitCbdAContentDose { get; init; }

    [JsonPropertyName("RequiresUnitThcPercent")]
    public bool? RequiresUnitThcPercent { get; init; }

    [JsonPropertyName("RequiresUnitThcContent")]
    public bool? RequiresUnitThcContent { get; init; }

    [JsonPropertyName("RequiresUnitThcContentDose")]
    public bool? RequiresUnitThcContentDose { get; init; }

    [JsonPropertyName("RequiresUnitThcAPercent")]
    public bool? RequiresUnitThcAPercent { get; init; }

    [JsonPropertyName("RequiresUnitThcAContent")]
    public bool? RequiresUnitThcAContent { get; init; }

    [JsonPropertyName("RequiresUnitThcAContentDose")]
    public bool? RequiresUnitThcAContentDose { get; init; }

    [JsonPropertyName("RequiresUnitVolume")]
    public bool? RequiresUnitVolume { get; init; }

    [JsonPropertyName("RequiresUnitWeight")]
    public bool? RequiresUnitWeight { get; init; }

    [JsonPropertyName("RequiresServingSize")]
    public bool? RequiresServingSize { get; init; }

    [JsonPropertyName("RequiresSupplyDurationDays")]
    public bool? RequiresSupplyDurationDays { get; init; }

    [JsonPropertyName("RequiresNumberOfDoses")]
    public bool? RequiresNumberOfDoses { get; init; }

    [JsonPropertyName("RequiresPublicIngredients")]
    public bool? RequiresPublicIngredients { get; init; }

    [JsonPropertyName("RequiresDescription")]
    public bool? RequiresDescription { get; init; }

    [JsonPropertyName("RequiresAllergens")]
    public bool? RequiresAllergens { get; init; }

    [JsonPropertyName("RequiresProductPhotos")]
    public long? RequiresProductPhotos { get; init; }

    [JsonPropertyName("RequiresProductPhotoDescription")]
    public bool? RequiresProductPhotoDescription { get; init; }

    [JsonPropertyName("RequiresLabelPhotos")]
    public long? RequiresLabelPhotos { get; init; }

    [JsonPropertyName("RequiresLabelPhotoDescription")]
    public bool? RequiresLabelPhotoDescription { get; init; }

    [JsonPropertyName("RequiresPackagingPhotos")]
    public long? RequiresPackagingPhotos { get; init; }

    [JsonPropertyName("RequiresPackagingPhotoDescription")]
    public bool? RequiresPackagingPhotoDescription { get; init; }

    [JsonPropertyName("CanContainSeeds")]
    public bool? CanContainSeeds { get; init; }

    [JsonPropertyName("CanBeRemediated")]
    public bool? CanBeRemediated { get; init; }

    [JsonPropertyName("CanBeDecontaminated")]
    public bool? CanBeDecontaminated { get; init; }

    [JsonPropertyName("CanBeDestroyed")]
    public bool? CanBeDestroyed { get; init; }

    [JsonPropertyName("RequiresProductPDFDocuments")]
    public long? RequiresProductPDFDocuments { get; init; }

    [JsonPropertyName("LabTestBatchNames")]
    public ICollection<object>? LabTestBatchNames { get; init; }

}
