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
}