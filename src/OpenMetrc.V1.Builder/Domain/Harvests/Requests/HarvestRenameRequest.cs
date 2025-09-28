using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.Harvests.Requests;

public partial record HarvestRenameRequest
{
    [JsonPropertyName("Id")]
    public long? Id { get; init; }

    [JsonPropertyName("NewName")]
    public string? NewName { get; init; }

    [JsonPropertyName("OldName")]
    public string? OldName { get; init; }

}
