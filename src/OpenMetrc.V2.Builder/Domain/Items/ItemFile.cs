using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.Items;

public partial record ItemFile
{
    [JsonPropertyName("Ids")]
    public ICollection<long>? Ids { get; init; }

}
