using System.Text.Json.Serialization;

namespace xToolMerge.Xcs.Models;

public class DataTypeValueModel
{
    [JsonIgnore]
    public Guid Id { get; set; }
    
    [JsonPropertyName("displays")]
    public DataDisplaysModel Displays { get; set; }
}