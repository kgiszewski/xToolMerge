using System.Text.Json;

public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine(JsonSerializer.Serialize(args));

        var context = ParseCommandLine(args);
        
        Console.WriteLine(JsonSerializer.Serialize(context));

        Console.ReadKey();
    }
    
    private static CommandContext ParseCommandLine(string[] args)
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
                case "--OutputFilename":
                    i++;
                    context.SourceFilePath2 = args[i];
                    break;
                default:
                    throw new Exception($"Unknown command => {args[i]}");
                
            }
        }

        return context;
    }

    public class CommandContext
    {
        public string SourceFilePath1 { get; set; }
        public string SourceFilePath2 { get; set; }
        public string OutputFilename { get; set; }
    }
}
