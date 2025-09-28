using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.PlantBatches.Requests;

public partial record PlantBatchNameRequest
{
    [JsonPropertyName("Group")]
    public string? Group { get; init; }

    [JsonPropertyName("NewGroup")]
    public string? NewGroup { get; init; }

    [JsonPropertyName("Id")]
    public long? Id { get; init; }

}
