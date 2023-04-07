using System.Text.Json;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using xToolMerge;
using xToolMerge.Xcs;

public class Program
{
    static async Task Main(string[] args)
    {
        var host = CreateHostBuilder(args).Build();

        Console.WriteLine(JsonSerializer.Serialize(args));

        var context = CommandContext.ParseCommandLine(args);
        
        Console.WriteLine(JsonSerializer.Serialize(context));

        var orchestrator = host.Services.GetRequiredService<IOrchestrator>();

        var xcsModel = await orchestrator.ExecuteAsync(context);

        Console.WriteLine(xcsModel.Canvas.First().Displays.Count());
        
        Console.ReadKey();
    }
    
    private static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureServices((_, services) =>
            {
                services.AddSingleton<IXcsReader, XcsReader>();
                services.AddSingleton<IOrchestrator, Orchestrator>();
                services.AddSingleton<IXcsWriter, XcsWriter>();
                services.AddSingleton<IXcsMergeService, XcsMergeService>();
            });
}
