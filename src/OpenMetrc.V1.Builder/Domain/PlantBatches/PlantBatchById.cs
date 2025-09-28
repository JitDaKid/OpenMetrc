using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.PlantBatches;

public partial record PlantBatchById
{
    [JsonPropertyName("Id")]
    public long? Id { get; init; }

    [JsonPropertyName("Name")]
    public string? Name { get; init; }

    [JsonPropertyName("PlantBatchTypeId")]
    public long? PlantBatchTypeId { get; init; }

    [JsonPropertyName("PlantBatchTypeName")]
    public string? PlantBatchTypeName { get; init; }

    [JsonPropertyName("StrainId")]
    public long? StrainId { get; init; }

    [JsonPropertyName("StrainName")]
    public string? StrainName { get; init; }

    [JsonPropertyName("UntrackedCount")]
    public long? UntrackedCount { get; init; }

    [JsonPropertyName("TrackedCount")]
    public long? TrackedCount { get; init; }

    [JsonPropertyName("PackagedCount")]
    public long? PackagedCount { get; init; }

    [JsonPropertyName("DestroyedCount")]
    public long? DestroyedCount { get; init; }

    [JsonPropertyName("SourcePlantBatchIds")]
    public ICollection<object>? SourcePlantBatchIds { get; init; }

    [JsonPropertyName("MultiPlantBatch")]
    public bool? MultiPlantBatch { get; init; }

    [JsonPropertyName("PlantedDate")]
    public DateOnly? PlantedDate { get; init; }

    [JsonPropertyName("LastModified")]
    public DateOnly? LastModified { get; init; }

    [JsonPropertyName("IsOnHold")]
    public bool? IsOnHold { get; init; }

}
