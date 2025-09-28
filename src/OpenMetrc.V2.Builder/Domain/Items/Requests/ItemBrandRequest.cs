using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.Items.Requests;

public partial record ItemBrandRequest
{
    [JsonPropertyName("Name")]
    public string? Name { get; init; }

    [JsonPropertyName("Id")]
    public long? Id { get; init; }

}
