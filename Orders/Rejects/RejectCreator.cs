using TradingEngine.Orders;

namespace TradingEngine.Rejects;

public sealed class RejectCreator
{
    public static Reject GenerateOrderCoreRejection(IOrderCore rejectedOrder, RejectionReason reason)
    {
        return new Reject(rejectedOrder, reason);
    }
}