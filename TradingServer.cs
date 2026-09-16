using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using TradingEngine.Core.Configuration;
using TradingEngine.Logger;

namespace TradingEngine.Core;

public sealed class TradingServer(ILogger logger, IOptions<TradingServerConfiguration> config)
    : BackgroundService, ITradingServer
{
    private readonly ILogger _logger = logger ?? throw new ArgumentNullException(nameof(logger));

    private readonly TradingServerConfiguration _config =
        config.Value ?? throw new ArgumentNullException(nameof(config));

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.Info("TradingServer", "Starting Trading Server");
        while (!stoppingToken.IsCancellationRequested)
        {
        }

        _logger.Info("TradingServer", "TradingServer is stopping...");

        return Task.CompletedTask;
    }

    public Task Run(CancellationToken stoppingToken) => ExecuteAsync(stoppingToken);
}