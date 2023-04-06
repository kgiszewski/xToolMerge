namespace xToolMerge.Xcs;

public interface IXcsParser
{
    void LoadFile(string filepath);
}

public class XcsParser : IXcsParser
{
    public void LoadFile(string filepath)
    {
        var fileContents = File.ReadLines(filepath);
        
        
    }
}