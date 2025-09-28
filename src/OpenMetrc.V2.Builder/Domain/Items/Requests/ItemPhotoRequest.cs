using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.Items.Requests;

public partial record ItemPhotoRequest
{
    [JsonPropertyName("FileName")]
    public string? FileName { get; init; }

    [JsonPropertyName("EncodedImageBase64")]
    public string? EncodedImageBase64 { get; init; }

}
