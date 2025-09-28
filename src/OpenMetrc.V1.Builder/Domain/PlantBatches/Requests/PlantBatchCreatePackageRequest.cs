using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.PlantBatches.Requests;

public partial record PlantBatchCreatePackageRequest
{
    [JsonPropertyName("PlantBatch")]
    public string? PlantBatch { get; init; }

    [JsonPropertyName("Count")]
    public long? Count { get; init; }

    [JsonPropertyName("Item")]
    public string? Item { get; init; }

    [JsonPropertyName("Tag")]
    public string? Tag { get; init; }

    [JsonPropertyName("PatientLicenseNumber")]
    public string? PatientLicenseNumber { get; init; }

    [JsonPropertyName("Note")]
    public string? Note { get; init; }

    [JsonPropertyName("IsTradeSample")]
    public bool? IsTradeSample { get; init; }

    [JsonPropertyName("IsDonation")]
    public bool? IsDonation { get; init; }

    [JsonPropertyName("ActualDate")]
    public DateOnly? ActualDate { get; init; }

    [JsonPropertyName("ExpirationDate")]
    public DateOnly? ExpirationDate { get; init; }

    [JsonPropertyName("SellByDate")]
    public DateOnly? SellByDate { get; init; }

    [JsonPropertyName("UseByDate")]
    public DateOnly? UseByDate { get; init; }

    [JsonPropertyName("Id")]
    public long? Id { get; init; }

}
