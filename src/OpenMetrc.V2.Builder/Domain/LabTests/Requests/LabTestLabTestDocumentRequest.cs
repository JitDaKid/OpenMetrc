using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.LabTests.Requests;

public partial record LabTestLabTestDocumentRequest
{
    [JsonPropertyName("LabTestResultId")]
    public long? LabTestResultId { get; init; }

    [JsonPropertyName("DocumentFileName")]
    public string? DocumentFileName { get; init; }

    [JsonPropertyName("DocumentFileBase64")]
    public string? DocumentFileBase64 { get; init; }

}
