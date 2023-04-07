using System.Text.Json;

namespace xToolMerge.Xcs;

public interface IXcsParser
{
    Task LoadFileAsync(string filepath);
}

public class XcsParser : IXcsParser
{
    public async Task LoadFileAsync(string filepath)
    {
        var fileContents = await File.ReadAllTextAsync(filepath);
        var xcsModel = JsonSerializer.Deserialize<XcsModel>(fileContents);

        if (xcsModel == null)
        {
            throw new Exception("XCS model null");
        }

        var deviceValues = xcsModel.Device?.Data?.Value?.ToList() ?? new List<JsonElement>();
        var element = deviceValues.FirstOrDefault();
        var dataTypeValueModelListDeserialized = element.Deserialize<IEnumerable<JsonElement>>() ?? new List<JsonElement>();
        var dataTypeValueModelList = new List<DataTypeValueModel>();
        
        Guid dataTypeValueModelId = default;
        
        foreach (var item in dataTypeValueModelListDeserialized)
        {
            if (item.ValueKind == JsonValueKind.String)
            {
                dataTypeValueModelId = item.Deserialize<Guid>();
            }
            
            if (item.ValueKind == JsonValueKind.Object)
            {
                var newDataTypeValueModel = item.Deserialize<DataTypeValueModel>();

                newDataTypeValueModel.Id = dataTypeValueModelId;
                
                dataTypeValueModelList.Add(newDataTypeValueModel);
            }
        }
        
        if (xcsModel.Device == null || xcsModel.Device.Data == null)
        {
            throw new Exception("XCS device data model null");
        }

        xcsModel.Device.Data.Values = dataTypeValueModelList;

        var deviceDisplayValues = xcsModel.Device?.Data?.Values.First().Displays.Value?.ToList() ?? new List<JsonElement>();
        
        var dataTypeValueDisplaysValueModelList = new List<DataTypeValueDisplaysValueModel>();

        foreach (var item in deviceDisplayValues)
        {
            var dataTypeValueDisplaysValueModelListDeserialized = item.Deserialize<IEnumerable<JsonElement>>() ?? new List<JsonElement>();
            
            Guid dataTypeValueDisplaysValueModelId = default;
            
            foreach (var innerItem in dataTypeValueDisplaysValueModelListDeserialized)
            {
                if (innerItem.ValueKind == JsonValueKind.String)
                {
                    dataTypeValueDisplaysValueModelId = innerItem.Deserialize<Guid>();
                }
            
                if (innerItem.ValueKind == JsonValueKind.Object)
                {
                    var newDataTypeValueModel = innerItem.Deserialize<DataTypeValueDisplaysValueModel>();

                    newDataTypeValueModel.Id = dataTypeValueDisplaysValueModelId;
                
                    dataTypeValueDisplaysValueModelList.Add(newDataTypeValueModel);
                }
            }
        }
    }
}