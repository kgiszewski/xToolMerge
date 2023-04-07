using System.Text.Json;
using System.Text.Json.Serialization;

namespace xToolMerge.Xcs.Models;

public class DataDisplaysModel
{
    [JsonPropertyName("dataType")]
    public string DataType { get; set; }
    
    [JsonPropertyName("value")]
    public IEnumerable<JsonElement> Value { get; set; }
    
    [JsonIgnore]
    public IEnumerable<DataTypeValueDisplaysValueModel> Values { get; set; }
}