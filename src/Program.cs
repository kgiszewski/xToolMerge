using System.Text.Json;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using xToolMerge.Xcs;

public class Program
{
    static async Task Main(string[] args)
    {
        var host = CreateHostBuilder(args).Build();

        Console.WriteLine(JsonSerializer.Serialize(args));

        var context = ParseCommandLine(args);
        
        Console.WriteLine(JsonSerializer.Serialize(context));

        var parser = host.Services.GetRequiredService<IXcsParser>();
        
        await parser.LoadFileAsync(context.SourceFilePath1);
        
        //TODO: validate context

        Console.ReadKey();
    }
    
    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)

        .ConfigureServices((_, services) =>
            {
                services.AddSingleton<IXcsParser, XcsParser>();
            });
    
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
