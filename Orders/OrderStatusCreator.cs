namespace TradingEngine.Orders;

public sealed class OrderStatusCreator
{
    public static CancelOrderStatus GenerateCancelOrderStatus(CancelOrder cancelOrder)
    {
        return new CancelOrderStatus();
    }

    public static ModifyOrderStatus GenerateModifyOrderStatus(ModifyOrder modifyOrder)
    {
        return new ModifyOrderStatus();
    }

    public static NewOrderStatus GenerateNewOrderStatus(Order order)
    {
        return new NewOrderStatus();
    }
}