using System.Text.Json;

namespace xToolMerge.Xcs;

public interface IXcsReader
{
    Task<XcsModel> LoadFileAsync(string filepath);
}

public class XcsReader : IXcsReader
{
    public async Task<XcsModel> LoadFileAsync(string filepath)
    {
        var fileContents = await File.ReadAllTextAsync(filepath);
     
        //do the easy deserialize
        var xcsModel = JsonSerializer.Deserialize<XcsModel>(fileContents);

        if (xcsModel == null)
        {
            throw new Exception("XCS model null");
        }

        //device -> data -> value
        //now we have to parse the wonky format where the first element is the id and the second is the object
        var deviceValues = xcsModel.Device?.Data?.Value?.ToList() ?? new List<JsonElement>();
        var dataTypeValueModelList = new List<DataTypeValueModel>();

        foreach (var deviceValue in deviceValues)
        {
            var dataTypeValueModelListDeserialized = deviceValue.Deserialize<IEnumerable<JsonElement>>() ?? new List<JsonElement>();

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

                    if (newDataTypeValueModel == null)
                    {
                        throw new Exception("New data type model is null.");
                    }
                    
                    newDataTypeValueModel.Id = dataTypeValueModelId;

                    dataTypeValueModelList.Add(newDataTypeValueModel);
                }
            }

            if (xcsModel.Device?.Data == null)
            {
                throw new Exception("XCS device data model null");
            }
        }

        xcsModel.Device.Data.Values = dataTypeValueModelList;

        foreach (var model in xcsModel.Device?.Data?.Values)
        {
            ProcessDisplaysForDataTypeValueModel(model);
        }
        
        return xcsModel;
    }

    private static void ProcessDisplaysForDataTypeValueModel(DataTypeValueModel dataTypeValueModel)
    {
        //device -> data -> value -> displays -> value
        //now we have to parse the wonky format where the first element is the id and the second is the object
        var deviceDisplayValues = dataTypeValueModel.Displays.Value?.ToList() ?? new List<JsonElement>();
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

                    if (newDataTypeValueModel == null)
                    {
                        throw new Exception("New data type model is null.");
                    }
                    
                    newDataTypeValueModel.Id = dataTypeValueDisplaysValueModelId;
                
                    dataTypeValueDisplaysValueModelList.Add(newDataTypeValueModel);
                }
            }
            
            dataTypeValueModel.Displays.Values = dataTypeValueDisplaysValueModelList;
        }
    }
}