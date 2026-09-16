namespace TradingEngine.Logger;

public record LogInformation(
    LogLevel Level,
    string Module,
    string Message,
    DateTime Now,
    int ThreadId,
    string ThreadName)
{
    public string FormattedMessage()
    {
        return $"[{Now:yyy-MM-dd HH-mm-ss.ffffff}] [{ThreadName,-30}:{ThreadId:0000}] {Level} - {Message}";
    }
}