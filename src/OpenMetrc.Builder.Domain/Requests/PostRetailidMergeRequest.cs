using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.Requests;

public class PostRetailidMergeRequest
{
    [Required]
    [JsonPropertyName("packageLabels")]
    public List<string> PackageLabels { get; set; } = new();
}