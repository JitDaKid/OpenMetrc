using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain;

public class PlantWaste
{
    [Required]
    [JsonPropertyName("PlantWasteNumber")]
    public string PlantWasteNumber { get; set; } = null!;

    [Required]
    [JsonPropertyName("WasteMethodName")]
    public string WasteMethodName { get; set; } = null!;

    [Required]
    [JsonPropertyName("WasteWeight")]
    public double WasteWeight { get; set; }

    [Required]
    [JsonPropertyName("WasteUnitOfMeasureName")]
    public string WasteUnitOfMeasureName { get; set; } = null!;

    [Required]
    [JsonPropertyName("WasteReasonName")]
    public string WasteReasonName { get; set; } = null!;

    [JsonPropertyName("PlantBatchId")]
    public long? PlantBatchId { get; set; }

    [JsonPropertyName("PlantBatchName")]
    public string? PlantBatchName { get; set; }

    [Required]
    [JsonPropertyName("PlantCount")]
    public int PlantCount { get; set; }

    [Required]
    [JsonPropertyName("WasteDate")]
    public DateOnly WasteDate { get; set; }
}