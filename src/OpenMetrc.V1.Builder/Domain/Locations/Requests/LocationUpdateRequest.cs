using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.Locations.Requests;

public partial record LocationUpdateRequest
{
    [JsonPropertyName("Id")]
    public long? Id { get; init; }

    [JsonPropertyName("Name")]
    public string? Name { get; init; }

    [JsonPropertyName("LocationTypeName")]
    public string? LocationTypeName { get; init; }

}
