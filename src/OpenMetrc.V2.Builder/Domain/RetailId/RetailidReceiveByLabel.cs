using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.RetailId;

public partial record RetailidReceiveByLabel
{
    [JsonPropertyName("Eaches")]
    public ICollection<string>? Eaches { get; init; }

    [JsonPropertyName("SiblingTags")]
    public ICollection<string>? SiblingTags { get; init; }

    [JsonPropertyName("RequiresVerification")]
    public bool? RequiresVerification { get; init; }

}
