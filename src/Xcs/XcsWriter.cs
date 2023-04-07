using System.Text.Json;
using xToolMerge.Xcs.Models;

namespace xToolMerge.Xcs;

public interface IXcsWriter
{
    Task WriteAsync(XcsModel model, string outputFilePath);
}

public class XcsWriter : IXcsWriter
{
    public async Task WriteAsync(XcsModel model, string outputFilePath)
    {
        var result = JsonSerializer.Serialize(model);
        
        await File.WriteAllTextAsync(outputFilePath, result);
    }
}