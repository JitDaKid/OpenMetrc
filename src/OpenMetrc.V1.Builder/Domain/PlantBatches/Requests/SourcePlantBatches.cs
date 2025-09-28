using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.PlantBatches.Requests;

public partial record SourcePlantBatches
{
    [JsonPropertyName("PlantBatchName")]
    public string? PlantBatchName { get; init; }

}
