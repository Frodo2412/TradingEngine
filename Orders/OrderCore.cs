using TradingEngine.Orders;

namespace TradingEngine.Instrument;

public class OrderCore(long orderId, string username, string securityId) : IOrderCore
{
    public long OrderId { get; } = orderId;
    public string Username { get; } = username;
    public string SecurityId { get; } = securityId;
}