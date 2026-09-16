namespace TradingEngine.Core.Configuration;

public class TradingServerConfiguration
{
    public TradingServerSettings TradingServerSettings { get; set; }
}

public class TradingServerSettings
{
    public int port { get; set; }
}