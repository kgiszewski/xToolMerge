using System.Text.Json.Serialization;

namespace xToolMerge.Xcs;

public class DeviceModel
{
    [JsonPropertyName("data")]
    public DeviceDataModel Data { get; set; }
}