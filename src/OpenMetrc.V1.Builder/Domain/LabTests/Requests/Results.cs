using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.LabTests.Requests;

public partial record Results
{
    [JsonPropertyName("LabTestTypeName")]
    public string? LabTestTypeName { get; init; }

    [JsonPropertyName("Quantity")]
    public double? Quantity { get; init; }

    [JsonPropertyName("Passed")]
    public bool? Passed { get; init; }

    [JsonPropertyName("Notes")]
    public string? Notes { get; init; }

}
