using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.LabTests;

public partial record LabTestResult
{
    [JsonPropertyName("PackageId")]
    public long? PackageId { get; init; }

    [JsonPropertyName("LabTestResultId")]
    public long? LabTestResultId { get; init; }

    [JsonPropertyName("LabFacilityLicenseNumber")]
    public string? LabFacilityLicenseNumber { get; init; }

    [JsonPropertyName("LabFacilityName")]
    public string? LabFacilityName { get; init; }

    [JsonPropertyName("SourcePackageLabel")]
    public string? SourcePackageLabel { get; init; }

    [JsonPropertyName("ProductName")]
    public string? ProductName { get; init; }

    [JsonPropertyName("ProductCategoryName")]
    public string? ProductCategoryName { get; init; }

    [JsonPropertyName("TestPerformedDate")]
    public DateOnly? TestPerformedDate { get; init; }

    [JsonPropertyName("OverallPassed")]
    public bool? OverallPassed { get; init; }

    [JsonPropertyName("ResultReleased")]
    public bool? ResultReleased { get; init; }

    [JsonPropertyName("ResultReleaseDateTime")]
    public DateTimeOffset? ResultReleaseDateTime { get; init; }

    [JsonPropertyName("TestTypeName")]
    public string? TestTypeName { get; init; }

    [JsonPropertyName("TestPassed")]
    public bool? TestPassed { get; init; }

    [JsonPropertyName("TestResultLevel")]
    public double? TestResultLevel { get; init; }

    [JsonPropertyName("TestComment")]
    public string? TestComment { get; init; }

    [JsonPropertyName("TestInformationalOnly")]
    public bool? TestInformationalOnly { get; init; }

}
