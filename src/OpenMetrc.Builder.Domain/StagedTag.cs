using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain
{
    public class StagedTag
    {
        [Required]
        [JsonPropertyName("Id")]
        public long Id { get; set; }

        [JsonPropertyName("TagTypeName")]
        public string? TagTypeName { get; set; }

        [JsonPropertyName("TagTypeId")]
        public long? TagTypeId { get; set; }

        [Required]
        [JsonPropertyName("TagInventoryTypeName")]
        public string TagInventoryTypeName { get; set; } = null!;

        [JsonPropertyName("MaxGroupSize")]
        public int? MaxGroupSize { get; set; }

        [JsonPropertyName("FacilityId")]
        public long? FacilityId { get; set; }

        [Required]
        [JsonPropertyName("Label")]
        public string Label { get; set; } = null!;

        [JsonPropertyName("StatusName")]
        public string? StatusName { get; set; }

        [JsonPropertyName("CommissionedDateTime")]
        public DateTimeOffset? CommissionedDateTime { get; set; }

        [JsonPropertyName("IsUsed")]
        public bool IsUsed { get; set; }

        [JsonPropertyName("UsedDateTime")]
        public DateTimeOffset? UsedDateTime { get; set; }

        [JsonPropertyName("ProductLabel")]
        public ProductLabel? ProductLabel { get; set; }

        [JsonPropertyName("DetachedDateTime")]
        public DateTimeOffset? DetachedDateTime { get; set; }

        [JsonPropertyName("IsArchived")]
        public bool IsArchived { get; set; }

        [JsonPropertyName("LastModified")]
        public DateTimeOffset LastModified { get; set; }

        [JsonPropertyName("IsStaged")]
        public bool IsStaged { get; set; }

        [JsonPropertyName("QrCount")]
        public int? QrCount { get; set; }
    }
}