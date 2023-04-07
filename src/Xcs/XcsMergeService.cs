using xToolMerge.Xcs.Models;

namespace xToolMerge.Xcs;

public interface IXcsMergeService
{
    Task MergeAsync(XcsModel model1, IReadOnlyCollection<DisplayModel> displayModelsToAdd, IReadOnlyCollection<DataTypeValueDisplaysValueModel> dataTypeValueDisplaysValueModelsToAdd);
}

public class XcsMergeService : IXcsMergeService
{
    public Task MergeAsync(
        XcsModel model1, 
        IReadOnlyCollection<DisplayModel> displayModelsToAdd,
        IReadOnlyCollection<DataTypeValueDisplaysValueModel> dataTypeValueDisplaysValueModelsToAdd
    )
    {
        var newDisplays = new List<DisplayModel>();
        
        newDisplays.AddRange(model1.Canvas.First().Displays);
        newDisplays.AddRange(displayModelsToAdd);

        model1.Canvas.First().Displays = newDisplays;

        var newDeviceDisplays = new List<DataTypeValueDisplaysValueModel>();
        
        newDeviceDisplays.AddRange(model1.Device.Data.Values.First().Displays.Values);
        newDeviceDisplays.AddRange(dataTypeValueDisplaysValueModelsToAdd);

        model1.Device.Data.Values.First().Displays.Values = newDeviceDisplays;

        //make groups unique
        foreach (var displayModelGroup in displayModelsToAdd.GroupBy(x => x.GroupTag))
        {
            if (string.IsNullOrEmpty(displayModelGroup.FirstOrDefault()?.GroupTag)) continue;

            var newGroupTag = $"g-{Guid.NewGuid()}";
            
            foreach(var displayModel in displayModelGroup)
            {
                displayModel.GroupTag = newGroupTag;
            }
        }
        
        return Task.CompletedTask;
    }
}