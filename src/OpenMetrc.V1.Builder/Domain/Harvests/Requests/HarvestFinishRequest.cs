using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.Harvests.Requests;

public partial record HarvestFinishRequest
{
    [JsonPropertyName("Id")]
    public long? Id { get; init; }

    [JsonPropertyName("ActualDate")]
    public DateOnly? ActualDate { get; init; }

}
