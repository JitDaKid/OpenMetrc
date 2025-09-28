using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.RetailId;

public partial record RetailidAssociate
{
    [JsonPropertyName("Ids")]
    public ICollection<long>? Ids { get; init; }

}
