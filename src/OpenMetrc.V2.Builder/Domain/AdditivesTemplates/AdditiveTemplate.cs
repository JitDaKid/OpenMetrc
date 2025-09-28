using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.AdditivesTemplates;

public partial record AdditiveTemplate
{
    [JsonPropertyName("Ids")]
    public ICollection<long>? Ids { get; init; }

}
