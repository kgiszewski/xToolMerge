namespace xToolMerge;

public interface ICommandContext
{
    string SourceFilePath1 { get; }
    string SourceFilePath2 { get;  }
    string OutputFilename { get; }
}

internal class CommandContext : ICommandContext
{
    public string SourceFilePath1 { get; private set; }
    public string SourceFilePath2 { get; private set; }
    public string OutputFilename { get; private set; }
    
    public static ICommandContext ParseCommandLine(string[] args)
    {
        var context = new CommandContext();
        
        for (var i = 0; i < args.Length; i++)
        {
            switch (args[i])
            {
                case "--sourceFile1":
                    i++;
                    context.SourceFilePath1 = args[i];
                    break;
                case "--sourceFile2":
                    i++;
                    context.SourceFilePath2 = args[i];
                    break;
                case "--outputFilename":
                    i++;
                    context.OutputFilename = args[i];
                    break;
                default:
                    throw new Exception($"Unknown command => {args[i]}");
                
            }
        }

        //TODO: validate context
        return context;
    }
}