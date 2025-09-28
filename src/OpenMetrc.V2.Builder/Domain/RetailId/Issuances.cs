using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.RetailId;

public partial record Issuances
{
    [JsonPropertyName("LabelSet")]
    public long? LabelSet { get; init; }

    [JsonPropertyName("LabelQuantity")]
    public long? LabelQuantity { get; init; }

    [JsonPropertyName("CreatedAt")]
    public DateTimeOffset? CreatedAt { get; init; }

}
