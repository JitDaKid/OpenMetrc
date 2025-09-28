using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.RetailId;

public partial record RetailidPackageInfo
{
    [JsonPropertyName("Packages")]
    public ICollection<object>? Packages { get; init; }

}
