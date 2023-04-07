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
        //TODO: validate context
        
        Console.WriteLine(JsonSerializer.Serialize(context));

        var parser = host.Services.GetRequiredService<IXcsParser>();
        var xcsFile1 = await parser.LoadFileAsync(context.SourceFilePath1);
        var file1Elements = GetElementsFromFile(xcsFile1, context.SourceFilePath1);
        var xcsFile2 = await parser.LoadFileAsync(context.SourceFilePath2);
        var file2Elements = GetElementsFromFile(xcsFile2, context.SourceFilePath2);
        
        Console.ReadKey();
    }

    public static (IReadOnlyCollection<DisplayModel>, IReadOnlyCollection<DataTypeValueDisplaysValueModel>) GetElementsFromFile(XcsModel model, string filename)
    {
        var elementsToCopy = model.Canvas.First().Displays?.ToList() ?? new List<DisplayModel>();

        Console.WriteLine($"Found {elementsToCopy.Count} elements in {filename}");
        
        foreach (var element in elementsToCopy)
        {
            Console.WriteLine($"{element.Id}");
        }

        var deviceDataDisplays = model.Device.Data.Values.First().Displays.Values
            .Where(x => elementsToCopy.Select(y => y.Id).Contains(x.Id)).ToList();

        if (deviceDataDisplays.Count != elementsToCopy.Count)
        {
            throw new Exception("Elements to copy do not match count.");
        }

        return (elementsToCopy, deviceDataDisplays);
    }

    private static IHostBuilder CreateHostBuilder(string[] args) =>
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
                    context.OutputFilename = args[i];
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
