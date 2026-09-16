namespace TradingEngine.Orders;

public interface IOrderCore
{
    public long OrderId { get; }
    public string Username { get; }
    public string SecurityId { get; }
}