using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.PlantBatches;

public partial record PlantBatchType
{
    [JsonPropertyName("Id")]
    public long? Id { get; init; }

    [JsonPropertyName("Name")]
    public string? Name { get; init; }

    [JsonPropertyName("CanBeCloned")]
    public bool? CanBeCloned { get; init; }

    [JsonPropertyName("LastModified")]
    public DateTimeOffset? LastModified { get; init; }

}
