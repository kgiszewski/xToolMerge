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
    }
}