using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.Requests;

public class PostPlantAdditiveUsingtemplateRequest
{
    [Required]
    [JsonPropertyName("AdditivesTemplateName")]
    public string AdditivesTemplateName { get; set; } = null!;

    [Required]
    [JsonPropertyName("Rate")]
    public string Rate { get; set; } = null!;

    [Required]
    [JsonPropertyName("Volume")]
    public string Volume { get; set; } = null!;

    [Required]
    [JsonPropertyName("TotalAmountApplied")]
    public double TotalAmountApplied { get; set; }

    [Required]
    [JsonPropertyName("TotalAmountUnitOfMeasure")]
    public string TotalAmountUnitOfMeasure { get; set; } = null!;

    [Required]
    [JsonPropertyName("PlantLabels")]
    public List<string> PlantLabels { get; set; } = new();

    [Required]
    [JsonPropertyName("ActualDate")]
    public DateOnly ActualDate { get; set; }
}