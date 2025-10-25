using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.Requests;

public class PostRetailidGenerateRequest
{
    [Required]
    [JsonPropertyName("PackageLabel")]
    public string PackageLabel { get; set; } = null!;

    [Required]
    [JsonPropertyName("Quantity")]
    public int Quantity { get; set; }
}