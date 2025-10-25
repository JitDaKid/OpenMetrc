using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.Requests;

public class PutSublocationsRequest
{
    [Required]
    [JsonPropertyName("Id")]
    public long Id { get; set; }

    [Required]
    [JsonPropertyName("Name")]
    public string Name { get; set; } = null!;
}