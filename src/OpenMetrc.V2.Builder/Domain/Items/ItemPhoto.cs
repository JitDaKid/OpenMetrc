using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.Items;

public partial record ItemPhoto
{
    [JsonPropertyName("Ids")]
    public ICollection<long>? Ids { get; init; }

}
