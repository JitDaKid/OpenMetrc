using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.Strains.Requests;

public partial record StrainRequest
{
    [JsonPropertyName("Name")]
    public string? Name { get; init; }

    [JsonPropertyName("TestingStatus")]
    public string? TestingStatus { get; init; }

    [JsonPropertyName("ThcLevel")]
    public double? ThcLevel { get; init; }

    [JsonPropertyName("CbdLevel")]
    public double? CbdLevel { get; init; }

    [JsonPropertyName("IndicaPercentage")]
    public double? IndicaPercentage { get; init; }

    [JsonPropertyName("SativaPercentage")]
    public double? SativaPercentage { get; init; }

    [JsonPropertyName("Id")]
    public long? Id { get; init; }

}
