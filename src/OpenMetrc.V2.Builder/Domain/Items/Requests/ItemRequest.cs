using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.Items.Requests;

public partial record ItemRequest
{
    [JsonPropertyName("ItemCategory")]
    public string? ItemCategory { get; init; }

    [JsonPropertyName("Name")]
    public string? Name { get; init; }

    [JsonPropertyName("UnitOfMeasure")]
    public string? UnitOfMeasure { get; init; }

    [JsonPropertyName("Strain")]
    public string? Strain { get; init; }

    [JsonPropertyName("ProcessingJobTypeName")]
    public string? ProcessingJobTypeName { get; init; }

    [JsonPropertyName("UnitThcContent")]
    public double? UnitThcContent { get; init; }

    [JsonPropertyName("UnitThcContentUnitOfMeasure")]
    public string? UnitThcContentUnitOfMeasure { get; init; }

    [JsonPropertyName("UnitWeight")]
    public double? UnitWeight { get; init; }

    [JsonPropertyName("UnitWeightUnitOfMeasure")]
    public string? UnitWeightUnitOfMeasure { get; init; }

    [JsonPropertyName("Allergens")]
    public string? Allergens { get; init; }

    [JsonPropertyName("ProductImageFileSystemIds")]
    public ICollection<long>? ProductImageFileSystemIds { get; init; }

    [JsonPropertyName("ProductPhotoDescription")]
    public string? ProductPhotoDescription { get; init; }

    [JsonPropertyName("LabelImageFileSystemIds")]
    public ICollection<long>? LabelImageFileSystemIds { get; init; }

    [JsonPropertyName("LabelPhotoDescription")]
    public string? LabelPhotoDescription { get; init; }

    [JsonPropertyName("PackagingImageFileSystemIds")]
    public ICollection<long>? PackagingImageFileSystemIds { get; init; }

    [JsonPropertyName("PackagingPhotoDescription")]
    public string? PackagingPhotoDescription { get; init; }

    [JsonPropertyName("ProductPDFFileSystemIds")]
    public ICollection<long>? ProductPDFFileSystemIds { get; init; }

    [JsonPropertyName("UnitThcContentDose")]
    public double? UnitThcContentDose { get; init; }

    [JsonPropertyName("UnitThcContentDoseUnitOfMeasure")]
    public string? UnitThcContentDoseUnitOfMeasure { get; init; }

    [JsonPropertyName("UnitVolume")]
    public double? UnitVolume { get; init; }

    [JsonPropertyName("UnitVolumeUnitOfMeasure")]
    public string? UnitVolumeUnitOfMeasure { get; init; }

    [JsonPropertyName("NumberOfDoses")]
    public double? NumberOfDoses { get; init; }

    [JsonPropertyName("ProcessingJobCategoryName")]
    public string? ProcessingJobCategoryName { get; init; }

    [JsonPropertyName("Id")]
    public long? Id { get; init; }

}
