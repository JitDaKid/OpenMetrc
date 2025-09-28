using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.Items;

public partial record ItemPhotoById
{
    [JsonPropertyName("FileContents")]
    public string? FileContents { get; init; }

    [JsonPropertyName("ContentType")]
    public string? ContentType { get; init; }

    [JsonPropertyName("FileDownloadName")]
    public string? FileDownloadName { get; init; }

}
