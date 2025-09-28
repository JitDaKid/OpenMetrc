using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.LabTests;

public partial record ItemCategories
{
    [JsonPropertyName("ProductCategoryId")]
    public string? ProductCategoryId { get; init; }

    [JsonPropertyName("ProductCategory")]
    public ProductCategory? ProductCategory { get; init; }

    [JsonPropertyName("RequireLabTestBatch")]
    public bool? RequireLabTestBatch { get; init; }

}
