using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.Sublocations;

public partial record SublocationActive
{
    [JsonPropertyName("Id")]
    public long? Id { get; init; }

    [JsonPropertyName("Name")]
    public string? Name { get; init; }

}
