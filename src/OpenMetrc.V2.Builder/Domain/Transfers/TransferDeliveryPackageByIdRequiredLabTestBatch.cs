using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.Transfers;

public partial record TransferDeliveryPackageByIdRequiredLabTestBatch
{
    [JsonPropertyName("PackageId")]
    public long? PackageId { get; init; }

    [JsonPropertyName("LabTestBatchId")]
    public long? LabTestBatchId { get; init; }

    [JsonPropertyName("LabTestBatchName")]
    public string? LabTestBatchName { get; init; }

}
