using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.Harvests.Requests;

public partial record HarvestCreatePackageTestingRequest
{
    [JsonPropertyName("Tag")]
    public string? Tag { get; init; }

    [JsonPropertyName("Item")]
    public string? Item { get; init; }

    [JsonPropertyName("UnitOfWeight")]
    public string? UnitOfWeight { get; init; }

    [JsonPropertyName("PatientLicenseNumber")]
    public string? PatientLicenseNumber { get; init; }

    [JsonPropertyName("Note")]
    public string? Note { get; init; }

    [JsonPropertyName("IsProductionBatch")]
    public bool? IsProductionBatch { get; init; }

    [JsonPropertyName("IsTradeSample")]
    public bool? IsTradeSample { get; init; }

    [JsonPropertyName("IsDonation")]
    public bool? IsDonation { get; init; }

    [JsonPropertyName("ProductRequiresRemediation")]
    public bool? ProductRequiresRemediation { get; init; }

    [JsonPropertyName("RemediateProduct")]
    public bool? RemediateProduct { get; init; }

    [JsonPropertyName("ProductRequiresDecontamination")]
    public bool? ProductRequiresDecontamination { get; init; }

    [JsonPropertyName("DecontaminateProduct")]
    public bool? DecontaminateProduct { get; init; }

    [JsonPropertyName("ActualDate")]
    public DateOnly? ActualDate { get; init; }

    [JsonPropertyName("Ingredients")]
    public ICollection<Ingredients>? Ingredients { get; init; }

    [JsonPropertyName("ProcessingJobTypeId")]
    public long? ProcessingJobTypeId { get; init; }

    [JsonPropertyName("LabTestStageId")]
    public long? LabTestStageId { get; init; }

    [JsonPropertyName("RequiredLabTestBatches")]
    public ICollection<object>? RequiredLabTestBatches { get; init; }

    [JsonPropertyName("ProductionBatchNumber")]
    public string? ProductionBatchNumber { get; init; }

}
