using xToolMerge.Xcs;
using xToolMerge.Xcs.Models;

namespace xToolMerge;

public interface IOrchestrator
{
    Task<XcsModel> ExecuteAsync(ICommandContext context);
}

internal class Orchestrator : IOrchestrator
{
    private readonly IXcsReader _xcsReader;
    private readonly IXcsMergeService _xcsMergeService;
    private readonly IXcsWriter _xcsWriter;

    public Orchestrator(
        IXcsReader xcsReader, 
        IXcsMergeService xcsMergeService, 
        IXcsWriter xcsWriter
    )
    {
        _xcsReader = xcsReader;
        _xcsMergeService = xcsMergeService;
        _xcsWriter = xcsWriter;
    }
    
    public async Task<XcsModel> ExecuteAsync(ICommandContext context)
    {
        var xcsFile1 = await _xcsReader.LoadFileAsync(context.SourceFilePath1);
        var xcsFile2 = await _xcsReader.LoadFileAsync(context.SourceFilePath2);
        var (file2Elements, file2DeviceElements) = GetElementsFromFile(xcsFile2, context.SourceFilePath2);
        
        //merge file2 to file 1 as a new file
        await _xcsMergeService.MergeAsync(xcsFile1, file2Elements, file2DeviceElements);
        await _xcsWriter.WriteAsync(xcsFile1, context.OutputFilename);

        return xcsFile1;
    }
    
    private static (IReadOnlyCollection<DisplayModel>, IReadOnlyCollection<DataTypeValueDisplaysValueModel>) GetElementsFromFile(XcsModel model, string filename)
    {
        var elementsToCopy = model.Canvas.First().Displays?.ToList() ?? new List<DisplayModel>();

        Console.WriteLine($"Found {elementsToCopy.Count} elements in {filename}");
        
        foreach (var element in elementsToCopy)
        {
            Console.WriteLine($"{element.Id}");
        }
        
        var deviceDataDisplays = model.Device.Data.Values
            .Select(z => z.Displays)
            .SelectMany(t => t.Values)
            .Where(x => elementsToCopy.Select(y => y.Id).Contains(x.Id))
            .ToList();

        if (deviceDataDisplays.Count != elementsToCopy.Count)
        {
            throw new Exception("Elements to copy do not match count.");
        }

        return (elementsToCopy, deviceDataDisplays);
    }
}