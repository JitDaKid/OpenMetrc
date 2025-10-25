using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenMetrc.Builder.Domain;
public class ProductLabel
{
    [JsonPropertyName("PackageId")]
    public long? PackageId { get; set; }

    [JsonPropertyName("TagId")]
    public long? TagId { get; set; }

    [JsonPropertyName("QrCount")]
    public int? QrCount { get; set; }

    [JsonPropertyName("IsDiscontinued")]
    public bool IsDiscontinued { get; set; }

    [JsonPropertyName("IsChildFromParentWithLabel")]
    public bool IsChildFromParentWithLabel { get; set; }

    [JsonPropertyName("LastLabelGenerationDate")]
    public DateTimeOffset? LastLabelGenerationDate { get; set; } // Assuming DateTimeOffset, adjust if needed

    [JsonPropertyName("IsActive")]
    public bool IsActive { get; set; }
}
