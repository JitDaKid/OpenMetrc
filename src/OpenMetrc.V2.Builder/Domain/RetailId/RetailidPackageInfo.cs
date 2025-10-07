using System.Text.Json.Serialization;
using OpenMetrc.Builder.Domain.ProcessingJob.Requests;

namespace OpenMetrc.Builder.Domain.RetailId;

public partial record RetailidPackageInfo
{
    [JsonPropertyName("Packages")]
    public ICollection<Packages>? Packages { get; init; }

}
