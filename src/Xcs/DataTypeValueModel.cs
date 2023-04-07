using System.Text.Json.Serialization;

namespace xToolMerge.Xcs;

public class DataTypeValueModel
{
    [JsonIgnore]
    public Guid Id { get; set; }
    
    [JsonPropertyName("displays")]
    public DataDisplaysModel Displays { get; set; }
}