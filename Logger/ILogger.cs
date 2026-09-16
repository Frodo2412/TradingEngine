namespace TradingEngine.Logger;

public interface ILogger
{
    public void Debug(string module, string message);
    public void Debug(string module, Exception ex);

    public void Warning(string module, string message);
    public void Warning(string module, Exception ex);

    public void Info(string module, string message);
    public void Info(string module, Exception ex);

    public void Error(string module, string message);
    public void Error(string module, Exception ex);
}