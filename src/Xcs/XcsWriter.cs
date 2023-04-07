namespace xToolMerge.Xcs;

public interface IXcsWriter
{
    Task WriteAsync(XcsModel model, string outputFilePath);
}

public class XcsWriter : IXcsWriter
{
    public Task WriteAsync(XcsModel model, string outputFilePath)
    {
        throw new NotImplementedException();
    }
}