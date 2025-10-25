using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.Requests;

public class PostPlantAdditiveByLocationUsingtemplateRequest
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
    [JsonPropertyName("LocationName")]
    public string LocationName { get; set; } = null!;

    [JsonPropertyName("SublocationName")]
    public string? SublocationName { get; set; }

    [Required]
    [JsonPropertyName("ActualDate")]
    public DateOnly ActualDate { get; set; }
}