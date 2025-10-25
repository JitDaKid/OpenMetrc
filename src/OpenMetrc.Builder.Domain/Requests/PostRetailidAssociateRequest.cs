using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.Requests;

public class PostRetailidAssociateRequest
{
    [Required]
    [JsonPropertyName("PackageLabel")]
    public string PackageLabel { get; set; } = null!;

    [Required]
    [JsonPropertyName("QrUrls")]
    public List<string> QrUrls { get; set; } = new();
}