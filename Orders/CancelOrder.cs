namespace TradingEngine.Orders;

public class CancelOrder(IOrderCore orderCore) : IOrderCore
{
    public long OrderId => orderCore.OrderId;
    public string Username => orderCore.Username;
    public string SecurityId => orderCore.SecurityId;
}