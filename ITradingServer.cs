namespace TradingEngine.Core;

internal interface ITradingServer
{
    Task Run(CancellationToken stoppingToken);
}