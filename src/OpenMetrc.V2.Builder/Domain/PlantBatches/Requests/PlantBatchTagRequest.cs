using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.PlantBatches.Requests;

public partial record PlantBatchTagRequest
{
    [JsonPropertyName("Group")]
    public string? Group { get; init; }

    [JsonPropertyName("NewTag")]
    public string? NewTag { get; init; }

    [JsonPropertyName("ReplaceDate")]
    public DateOnly? ReplaceDate { get; init; }

    [JsonPropertyName("Id")]
    public long? Id { get; init; }

    [JsonPropertyName("TagId")]
    public long? TagId { get; init; }

}
