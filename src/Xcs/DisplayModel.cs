using System.Text.Json.Serialization;

namespace xToolMerge.Xcs;

public class DisplayModel
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }
    [JsonPropertyName("type")]
    public string Type { get; set; }
    [JsonPropertyName("x")]
    public decimal X { get; set; }
    [JsonPropertyName("y")]
    public decimal Y { get; set; }
    [JsonPropertyName("angle")]
    public decimal Angle { get; set; }
    [JsonPropertyName("scale")]
    public CoordinateModel Scale { get; set; }
    [JsonPropertyName("skew")]
    public CoordinateModel Skew { get; set; }
    [JsonPropertyName("pivot")]
    public CoordinateModel Pivot { get; set; }
    [JsonPropertyName("localSkew")]
    public CoordinateModel LocalSkew { get; set; }
    [JsonPropertyName("offsetX")]
    public decimal OffsetX { get; set; }
    [JsonPropertyName("offsetY")]
    public decimal OffsetY { get; set; }
    [JsonPropertyName("lockRatio")]
    public bool LockRatio { get; set; }
    [JsonPropertyName("isClosePath")]
    public bool IsClosePath { get; set; }
    [JsonPropertyName("zOrder")]
    public int ZOrder { get; set; }
    [JsonPropertyName("width")]
    public decimal Width { get; set; }
    [JsonPropertyName("height")]
    public decimal Height { get; set; }
    [JsonPropertyName("isFill")]
    public bool IsFill { get; set; }
    [JsonPropertyName("lineColor")]
    public int LineColor { get; set; }
    [JsonPropertyName("fillColor")]
    public int FillColor { get; set; }
    [JsonPropertyName("points")]
    public IEnumerable<string> Points { get; set; }
    [JsonPropertyName("dPath")]
    public string DPath { get; set; }
}