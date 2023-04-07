using System.Text.Json.Serialization;

namespace xToolMerge.Xcs.Models;

public class DeviceModel
{
    [JsonPropertyName("data")]
    public DeviceDataModel Data { get; set; }
}