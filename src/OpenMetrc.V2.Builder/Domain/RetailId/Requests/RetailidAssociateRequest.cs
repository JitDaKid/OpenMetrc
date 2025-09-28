using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.RetailId.Requests;

public partial record RetailidAssociateRequest
{
    [JsonPropertyName("PackageLabel")]
    public string? PackageLabel { get; init; }

    [JsonPropertyName("QrUrls")]
    public ICollection<string>? QrUrls { get; init; }

}
