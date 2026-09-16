using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TradingEngine.Core.Configuration;

namespace TradingEngine.Core;

public static class TradingServerHostBuilder
{
    public static IHost BuildTradingServer() =>
        Host.CreateDefaultBuilder().ConfigureServices
        ((context, services) =>
        {
            Configure(services, context);
            services.AddSingleton<ITradingServer, TradingServer>();
            services.AddHostedService<TradingServer>();
        }).Build();

    private static void Configure(IServiceCollection services, HostBuilderContext context)
    {
        services.AddOptions();
        services.Configure<TradingServerConfiguration>(
            context.Configuration.GetSection(nameof(TradingServerConfiguration)));
    }
}