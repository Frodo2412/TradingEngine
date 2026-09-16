using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TradingEngine.Core;

using var engine = TradingServerHostBuilder.BuildTradingServer();
TradingServerServiceProvider.ServiceProvider = engine.Services;
{
    using var scope = TradingServerServiceProvider.ServiceProvider.CreateScope();
    await engine.RunAsync().ConfigureAwait(false);
}