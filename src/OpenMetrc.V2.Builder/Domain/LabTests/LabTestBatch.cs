using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.LabTests;

public partial record LabTestBatch
{
    [JsonPropertyName("Id")]
    public long? Id { get; init; }

    [JsonPropertyName("Name")]
    public string? Name { get; init; }

    [JsonPropertyName("LabTestTypeCount")]
    public long? LabTestTypeCount { get; init; }

    [JsonPropertyName("LabTestTypes")]
    public ICollection<LabTestTypes>? LabTestTypes { get; init; }

    [JsonPropertyName("ItemCategoryCount")]
    public long? ItemCategoryCount { get; init; }

    [JsonPropertyName("ItemCategories")]
    public ICollection<ItemCategories>? ItemCategories { get; init; }

    [JsonPropertyName("RequiresAllFromLabTestBatch")]
    public bool? RequiresAllFromLabTestBatch { get; init; }

}
