using TradingEngine.Orders;

namespace TradingEngine.Rejects;

public class Reject(IOrderCore rejectedOrder, RejectionReason reason) : IOrderCore
{
    private readonly RejectionReason _reason = reason;

    public long OrderId => rejectedOrder.OrderId;
    public string Username => rejectedOrder.Username;
    public string SecurityId => rejectedOrder.SecurityId;
}