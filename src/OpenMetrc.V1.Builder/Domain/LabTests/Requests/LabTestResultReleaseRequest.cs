using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.LabTests.Requests;

public partial record LabTestResultReleaseRequest
{
    [JsonPropertyName("PackageLabel")]
    public string? PackageLabel { get; init; }

}
