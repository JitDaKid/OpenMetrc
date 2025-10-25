using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.Requests;

public class PutPlantAdjustRequest
{
    [JsonPropertyName("Id")]
    public long? Id { get; set; }

    [JsonPropertyName("Label")]
    public string? Label { get; set; }

    [Required]
    [JsonPropertyName("AdjustCount")]
    public int AdjustCount { get; set; }

    [Required]
    [JsonPropertyName("AdjustReason")]
    public string AdjustReason { get; set; } = null!;

    [JsonPropertyName("ReasonNote")]
    public string? ReasonNote { get; set; }

    [Required]
    [JsonPropertyName("AdjustmentDate")]
    public DateTimeOffset AdjustmentDate { get; set; }
}