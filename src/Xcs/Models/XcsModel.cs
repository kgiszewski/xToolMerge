using System.Text.Json;
using System.Text.Json.Serialization;

namespace xToolMerge.Xcs.Models;

public class XcsModel
{
    [JsonPropertyName("canvasId")]
    public Guid CanvasId { get; set; }
    
    [JsonPropertyName("canvas")]
    public IEnumerable<CanvasModel> Canvas { get; set; }
    
    [JsonPropertyName("device")]
    public DeviceModel Device { get; set; }
    
    [JsonPropertyName("extId")]
    public string ExtId { get; set; }
    
    [JsonPropertyName("version")]
    public string Version { get; set; }
    
    [JsonPropertyName("created")]
    public long Created { get; set; }
    
    [JsonPropertyName("modify")]
    public long Modify { get; set; }
    
    [JsonPropertyName("ua")]
    public string Ua { get; set; }
    
    [JsonPropertyName("meta")]
    public IEnumerable<JsonElement> Meta { get; set; }
}