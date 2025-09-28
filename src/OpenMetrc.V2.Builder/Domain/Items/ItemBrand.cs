using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.Items;

public partial record ItemBrand
{
    [JsonPropertyName("Id")]
    public long? Id { get; init; }

    [JsonPropertyName("Name")]
    public string? Name { get; init; }

    [JsonPropertyName("Status")]
    public string? Status { get; init; }

    [JsonPropertyName("Ids")]
    public ICollection<long>? Ids { get; init; }

}
