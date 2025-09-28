using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.Sublocations.Requests;

public partial record SublocationRequest
{
    [JsonPropertyName("Name")]
    public string? Name { get; init; }

    [JsonPropertyName("Id")]
    public long? Id { get; init; }

}
