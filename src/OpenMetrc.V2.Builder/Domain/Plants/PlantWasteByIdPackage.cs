using System.Text.Json.Serialization;
using OpenMetrc.Builder.Domain.Items;
using OpenMetrc.Builder.Domain.Packages;

namespace OpenMetrc.Builder.Domain.Plants;

public partial record PlantWasteByIdPackage
{
    [JsonPropertyName("Id")]
    public long? Id { get; init; }

    [JsonPropertyName("Label")]
    public string? Label { get; init; }

    [JsonPropertyName("PackageType")]
    public string? PackageType { get; init; }

    [JsonPropertyName("SourceHarvestCount")]
    public long? SourceHarvestCount { get; init; }

    [JsonPropertyName("SourcePackageCount")]
    public long? SourcePackageCount { get; init; }

    [JsonPropertyName("SourceProcessingJobCount")]
    public long? SourceProcessingJobCount { get; init; }

    [JsonPropertyName("Quantity")]
    public double? Quantity { get; init; }

    [JsonPropertyName("OriginalPackageQuantity")]
    public double? OriginalPackageQuantity { get; init; }

    [JsonPropertyName("UnitOfMeasureName")]
    public string? UnitOfMeasureName { get; init; }

    [JsonPropertyName("UnitOfMeasureAbbreviation")]
    public string? UnitOfMeasureAbbreviation { get; init; }

    [JsonPropertyName("PackagedDate")]
    public DateOnly? PackagedDate { get; init; }

    [JsonPropertyName("InitialLabTestingState")]
    public string? InitialLabTestingState { get; init; }

    [JsonPropertyName("LabTestingState")]
    public string? LabTestingState { get; init; }

    [JsonPropertyName("LabTestingStateDate")]
    public DateOnly? LabTestingStateDate { get; init; }

    [JsonPropertyName("IsProductionBatch")]
    public bool? IsProductionBatch { get; init; }

    [JsonPropertyName("IsTradeSample")]
    public bool? IsTradeSample { get; init; }

    [JsonPropertyName("IsTradeSamplePersistent")]
    public bool? IsTradeSamplePersistent { get; init; }

    [JsonPropertyName("SourcePackageIsTradeSample")]
    public bool? SourcePackageIsTradeSample { get; init; }

    [JsonPropertyName("IsDonation")]
    public bool? IsDonation { get; init; }

    [JsonPropertyName("IsDonationPersistent")]
    public bool? IsDonationPersistent { get; init; }

    [JsonPropertyName("SourcePackageIsDonation")]
    public bool? SourcePackageIsDonation { get; init; }

    [JsonPropertyName("IsTestingSample")]
    public bool? IsTestingSample { get; init; }

    [JsonPropertyName("IsProcessValidationTestingSample")]
    public bool? IsProcessValidationTestingSample { get; init; }

    [JsonPropertyName("ProductRequiresRemediation")]
    public bool? ProductRequiresRemediation { get; init; }

    [JsonPropertyName("ContainsRemediatedProduct")]
    public bool? ContainsRemediatedProduct { get; init; }

    [JsonPropertyName("ProductRequiresDecontamination")]
    public bool? ProductRequiresDecontamination { get; init; }

    [JsonPropertyName("ContainsDecontaminatedProduct")]
    public bool? ContainsDecontaminatedProduct { get; init; }

    [JsonPropertyName("IsOnHold")]
    public bool? IsOnHold { get; init; }

    [JsonPropertyName("IsFinished")]
    public bool? IsFinished { get; init; }

    [JsonPropertyName("IsOnRetailerDelivery")]
    public bool? IsOnRetailerDelivery { get; init; }

    [JsonPropertyName("LastModified")]
    public DateTimeOffset? LastModified { get; init; }

    [JsonPropertyName("Item")]
    public Item? Item { get; init; }

    [JsonPropertyName("ProductLabel")]
    public ProductLabel? ProductLabel { get; init; }

}
