using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.Harvests.Requests;

public partial record HarvestMoveRequest
{
    [JsonPropertyName("Id")]
    public long? Id { get; init; }

    [JsonPropertyName("DryingLocation")]
    public string? DryingLocation { get; init; }

    [JsonPropertyName("DryingSublocation")]
    public string? DryingSublocation { get; init; }

    [JsonPropertyName("ActualDate")]
    public DateOnly? ActualDate { get; init; }

    [JsonPropertyName("HarvestName")]
    public string? HarvestName { get; init; }

}
