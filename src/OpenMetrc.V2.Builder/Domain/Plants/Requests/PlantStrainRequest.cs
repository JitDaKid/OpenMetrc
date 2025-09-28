using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.Plants.Requests;

public partial record PlantStrainRequest
{
    [JsonPropertyName("Id")]
    public long? Id { get; init; }

    [JsonPropertyName("StrainId")]
    public long? StrainId { get; init; }

}
