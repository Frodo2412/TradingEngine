namespace TradingEngine.Logger;

public abstract class AbstractLogger : ILogger
{
    protected abstract void Log(LogLevel level, string module, string message);

    public void Debug(string module, string message) => Log(LogLevel.Debug, module, message);
    public void Debug(string module, Exception ex) => Log(LogLevel.Debug, module, ex.ToString());
    public void Warning(string module, string message) => Log(LogLevel.Warning, module, message);
    public void Warning(string module, Exception ex) => Log(LogLevel.Warning, module, ex.ToString());
    public void Info(string module, string message) => Log(LogLevel.Info, module, message);
    public void Info(string module, Exception ex) => Log(LogLevel.Info, module, ex.ToString());
    public void Error(string module, string message) => Log(LogLevel.Error, module, message);
    public void Error(string module, Exception ex) => Log(LogLevel.Error, module, ex.ToString());
}