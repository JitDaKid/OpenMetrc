using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.RetailId;

public partial record RetailidGenerate
{
    [JsonPropertyName("IssuanceId")]
    public string? IssuanceId { get; init; }

}
