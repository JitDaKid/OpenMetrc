using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.Strains;

public partial record Strain
{
    [JsonPropertyName("Ids")]
    public ICollection<long>? Ids { get; init; }

}
