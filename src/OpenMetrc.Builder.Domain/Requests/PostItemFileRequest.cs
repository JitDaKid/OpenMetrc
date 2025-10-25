using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.Requests;

public class PostItemFileRequest
{
    [Required]
    [JsonPropertyName("FileName")]
    public string FileName { get; set; } = null!;

    [Required]
    [JsonPropertyName("EncodedImageBase64")]
    public string EncodedImageBase64 { get; set; } = null!;
}