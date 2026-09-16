using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TradingEngine.Core.Configuration;
using TradingEngine.Logger;
using TradingEngine.Logger.Configuration;

namespace TradingEngine.Core;

public static class TradingServerHostBuilder
{
    public static IHost BuildTradingServer() =>
        Host.CreateDefaultBuilder().ConfigureServices
        ((context, services) =>
        {
            Configure(services, context);
            services.AddSingleton<ITradingServer, TradingServer>();
            services.AddSingleton<TextLogger>();
            services.AddSingleton<ITextLogger>(provider => provider.GetRequiredService<TextLogger>());
            services.AddSingleton<ILogger>(provider => provider.GetRequiredService<TextLogger>());
            services.AddHostedService<TradingServer>();
        }).Build();

    private static void Configure(IServiceCollection services, HostBuilderContext context)
    {
        services.AddOptions();
        services.Configure<TradingServerConfiguration>(
            context.Configuration.GetSection(nameof(TradingServerConfiguration)));
        services.Configure<LoggerConfiguration>(
            context.Configuration.GetSection(nameof(LoggerConfiguration)));
    }
}