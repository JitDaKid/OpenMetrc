using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.Requests;

public class PostSublocationsRequest
{
    [Required]
    [JsonPropertyName("Name")]
    public string Name { get; set; } = null!;
}