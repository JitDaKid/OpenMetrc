using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.Plants.Requests;

public partial record PlantTagRequest
{
    [JsonPropertyName("Label")]
    public string? Label { get; init; }

    [JsonPropertyName("NewTag")]
    public string? NewTag { get; init; }

    [JsonPropertyName("ReplaceDate")]
    public DateOnly? ReplaceDate { get; init; }

    [JsonPropertyName("Id")]
    public long? Id { get; init; }

    [JsonPropertyName("TagId")]
    public long? TagId { get; init; }

}
