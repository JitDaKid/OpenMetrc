using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.RetailId.Requests;

public partial record RetailidPackageInfoRequest
{
    [JsonPropertyName("packageLabels")]
    public ICollection<string>? packageLabels { get; init; }

}
