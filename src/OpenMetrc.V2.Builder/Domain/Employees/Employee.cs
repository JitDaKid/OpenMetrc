using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.Employees;

public partial record Employee
{
    [JsonPropertyName("FullName")]
    public string? FullName { get; init; }

    [JsonPropertyName("License")]
    public License? License { get; init; }

    [JsonPropertyName("IsIndustryAdmin")]
    public bool? IsIndustryAdmin { get; init; }

    [JsonPropertyName("IsOwner")]
    public bool? IsOwner { get; init; }

    [JsonPropertyName("IsManager")]
    public bool? IsManager { get; init; }

}
