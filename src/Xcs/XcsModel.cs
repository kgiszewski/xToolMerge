using System.Text.Json.Serialization;

namespace xToolMerge.Xcs;

public class XcsModel
{
    [JsonPropertyName("canvasId")]
    public string CanvasId { get; set; }
}