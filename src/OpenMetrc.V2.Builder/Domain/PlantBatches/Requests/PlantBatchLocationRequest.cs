using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.PlantBatches.Requests;

public partial record PlantBatchLocationRequest
{
    [JsonPropertyName("Name")]
    public string? Name { get; init; }

    [JsonPropertyName("Location")]
    public string? Location { get; init; }

    [JsonPropertyName("Sublocation")]
    public string? Sublocation { get; init; }

    [JsonPropertyName("MoveDate")]
    public DateOnly? MoveDate { get; init; }

}
