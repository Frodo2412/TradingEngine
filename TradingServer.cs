using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TradingEngine.Core.Configuration;

namespace TradingEngine.Core;

public sealed class TradingServer(ILogger<TradingServer> logger, IOptions<TradingServerConfiguration> config)
    : BackgroundService, ITradingServer
{
    private readonly ILogger<TradingServer> _logger = logger ?? throw new ArgumentNullException(nameof(logger));

    private readonly TradingServerConfiguration _config =
        config.Value ?? throw new ArgumentNullException(nameof(config));

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Starting Trading Server");
        while (!stoppingToken.IsCancellationRequested)
        {
        }

        _logger.LogInformation("TradingServer is stopping...");

        return Task.CompletedTask;
    }

    public Task Run(CancellationToken stoppingToken) => ExecuteAsync(stoppingToken);
}