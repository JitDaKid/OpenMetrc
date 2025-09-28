using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.Items;

public partial record ItemById
{
    [JsonPropertyName("Id")]
    public long? Id { get; init; }

    [JsonPropertyName("Name")]
    public string? Name { get; init; }

    [JsonPropertyName("ProductCategoryName")]
    public string? ProductCategoryName { get; init; }

    [JsonPropertyName("ProductCategoryType")]
    public string? ProductCategoryType { get; init; }

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
    public string? QuantityType { get; init; }

    [JsonPropertyName("DefaultLabTestingState")]
    public string? DefaultLabTestingState { get; init; }

    [JsonPropertyName("UnitOfMeasureName")]
    public string? UnitOfMeasureName { get; init; }

    [JsonPropertyName("ApprovalStatus")]
    public string? ApprovalStatus { get; init; }

    [JsonPropertyName("ApprovalStatusDateTime")]
    public DateOnly? ApprovalStatusDateTime { get; init; }

    [JsonPropertyName("StrainId")]
    public long? StrainId { get; init; }

    [JsonPropertyName("StrainName")]
    public string? StrainName { get; init; }

    [JsonPropertyName("ItemBrandId")]
    public long? ItemBrandId { get; init; }

    [JsonPropertyName("ProductImages")]
    public ICollection<object>? ProductImages { get; init; }

    [JsonPropertyName("LabelImages")]
    public ICollection<object>? LabelImages { get; init; }

    [JsonPropertyName("PackagingImages")]
    public ICollection<object>? PackagingImages { get; init; }

    [JsonPropertyName("ProductPDFDocuments")]
    public ICollection<object>? ProductPDFDocuments { get; init; }

    [JsonPropertyName("IsUsed")]
    public bool? IsUsed { get; init; }

    [JsonPropertyName("LabTestBatchNames")]
    public ICollection<object>? LabTestBatchNames { get; init; }

}
