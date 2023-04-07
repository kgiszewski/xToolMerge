using System.Text.Json;
using System.Text.Json.Serialization;

namespace xToolMerge.Xcs;

public class DataTypeValueDisplaysValueModel
{
    [JsonIgnore]
    public Guid Id { get; set; }
    
    [JsonPropertyName("processingType")]
    public string ProcessingType { get; set; }
    
    [JsonPropertyName("type")]
    public string Type { get; set; }
    
    [JsonPropertyName("isFill")]
    public bool IsFill { get; set; }
    
    [JsonPropertyName("data")]
    public JsonElement Data { get; set; }
}