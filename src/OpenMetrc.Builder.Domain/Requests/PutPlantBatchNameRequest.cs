using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.Requests;

public class PutPlantBatchNameRequest
{
    [JsonPropertyName("Id")]
    public long? Id { get; set; }

    [JsonPropertyName("Group")]
    public string? Group { get; set; }

    [Required]
    [JsonPropertyName("NewGroup")]
    public string NewGroup { get; set; } = null!;
}