using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.PlantBatches.Requests;

public partial record PlantBatchStrainRequest
{
    [JsonPropertyName("Id")]
    public long? Id { get; init; }

    [JsonPropertyName("StrainId")]
    public long? StrainId { get; init; }

}
