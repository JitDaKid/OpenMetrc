using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.Plants.Requests;

public partial record PlantLocationRequest
{
    [JsonPropertyName("Label")]
    public string? Label { get; init; }

    [JsonPropertyName("Location")]
    public string? Location { get; init; }

    [JsonPropertyName("Sublocation")]
    public string? Sublocation { get; init; }

    [JsonPropertyName("ActualDate")]
    public DateOnly? ActualDate { get; init; }

    [JsonPropertyName("Id")]
    public long? Id { get; init; }

}
