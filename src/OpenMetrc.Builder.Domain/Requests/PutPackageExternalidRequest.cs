using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.Requests;

public class PutPackageExternalidRequest
{
    [Required]
    [JsonPropertyName("PackageLabel")]
    public string PackageLabel { get; set; } = null!;

    [JsonPropertyName("ExternalId")]
    public string? ExternalId { get; set; }
}