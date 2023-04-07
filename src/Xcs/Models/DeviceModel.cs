using System.Text.Json;
using System.Text.Json.Serialization;

namespace xToolMerge.Xcs.Models;

public class DeviceModel
{
    [JsonPropertyName("id")]
    public string Id { get; set; }
    
    [JsonPropertyName("power")]
    public int Power { get; set; }
    
    [JsonPropertyName("data")]
    public DeviceDataModel Data { get; set; }
    
    [JsonPropertyName("materialList")]
    public IEnumerable<JsonElement> MaterialList { get; set; }
}