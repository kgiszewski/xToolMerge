using System.Text.Json.Serialization;

namespace xToolMerge.Xcs.Models;

public class CanvasModel
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }
    
    [JsonPropertyName("title")]
    public string Title { get; set; }
    
    [JsonPropertyName("displays")]
    public IEnumerable<DisplayModel> Displays { get; set; }
}