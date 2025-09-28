using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.LabTests.Requests;

public partial record LabTestRecordRequest
{
    [JsonPropertyName("Label")]
    public string? Label { get; init; }

    [JsonPropertyName("ResultDate")]
    public DateOnly? ResultDate { get; init; }

    [JsonPropertyName("DocumentFileName")]
    public string? DocumentFileName { get; init; }

    [JsonPropertyName("DocumentFileBase64")]
    public string? DocumentFileBase64 { get; init; }

    [JsonPropertyName("Results")]
    public ICollection<Results>? Results { get; init; }

}
