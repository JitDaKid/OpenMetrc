using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.RetailId.Requests;

public partial record RetailidGenerateRequest
{
    [JsonPropertyName("PackageLabel")]
    public string? PackageLabel { get; init; }

    [JsonPropertyName("Quantity")]
    public long? Quantity { get; init; }

}
