using System.Text.Json.Serialization;

namespace xToolMerge.Xcs;

public class CanvasModel
{
    [JsonPropertyName("displays")]
    public IEnumerable<DisplayModel> Displays { get; set; }
}