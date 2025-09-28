using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.Harvests.Requests;

public partial record HarvestUnfinishRequest
{
    [JsonPropertyName("Id")]
    public long? Id { get; init; }

}
