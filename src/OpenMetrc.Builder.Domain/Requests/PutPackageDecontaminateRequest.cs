using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.Requests;

public class PutPackageDecontaminateRequest
{
    [Required]
    [JsonPropertyName("PackageLabel")]
    public string PackageLabel { get; set; } = null!;

    [Required]
    [JsonPropertyName("DecontaminationMethodName")]
    public string DecontaminationMethodName { get; set; } = null!;

    [Required]
    [JsonPropertyName("DecontaminationDate")]
    public DateOnly DecontaminationDate { get; set; }

    [JsonPropertyName("DecontaminationSteps")]
    public string? DecontaminationSteps { get; set; }
}