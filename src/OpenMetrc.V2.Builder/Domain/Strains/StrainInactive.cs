using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.Strains;

public partial record StrainInactive
{
    [JsonPropertyName("Id")]
    public long? Id { get; init; }

    [JsonPropertyName("Name")]
    public string? Name { get; init; }

    [JsonPropertyName("TestingStatus")]
    public string? TestingStatus { get; init; }

    [JsonPropertyName("IndicaPercentage")]
    public double? IndicaPercentage { get; init; }

    [JsonPropertyName("SativaPercentage")]
    public double? SativaPercentage { get; init; }

    [JsonPropertyName("IsUsed")]
    public bool? IsUsed { get; init; }

    [JsonPropertyName("Genetics")]
    public string? Genetics { get; init; }

}
