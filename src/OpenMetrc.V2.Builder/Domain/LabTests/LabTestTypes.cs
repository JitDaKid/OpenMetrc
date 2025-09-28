using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.LabTests;

public partial record LabTestTypes
{
    [JsonPropertyName("Id")]
    public long? Id { get; init; }

    [JsonPropertyName("Name")]
    public string? Name { get; init; }

    [JsonPropertyName("RequiresTestResult")]
    public bool? RequiresTestResult { get; init; }

    [JsonPropertyName("InformationalOnly")]
    public bool? InformationalOnly { get; init; }

    [JsonPropertyName("ResearchAndDevelopment")]
    public bool? ResearchAndDevelopment { get; init; }

    [JsonPropertyName("AlwaysPasses")]
    public bool? AlwaysPasses { get; init; }

    [JsonPropertyName("MaxAllowedFailureCount")]
    public long? MaxAllowedFailureCount { get; init; }

    [JsonPropertyName("LabTestResultMode")]
    public long? LabTestResultMode { get; init; }

    [JsonPropertyName("LabTestResultMinimum")]
    public object? LabTestResultMinimum { get; init; }

    [JsonPropertyName("LabTestResultMaximum")]
    public object? LabTestResultMaximum { get; init; }

    [JsonPropertyName("LabTestResultExpirationDays")]
    public object? LabTestResultExpirationDays { get; init; }

    [JsonPropertyName("DependencyMode")]
    public long? DependencyMode { get; init; }

}
