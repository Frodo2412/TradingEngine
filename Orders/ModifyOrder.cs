namespace TradingEngine.Orders;

public class ModifyOrder(IOrderCore orderCore, long price, uint quantity, bool isBuySide)
    : IOrderCore
{
    public long Price { get; private set; } = price;
    public uint Quantity { get; private set; } = quantity;
    public bool IsBuySide { get; private set; } = isBuySide;

    public long OrderId => orderCore.OrderId;
    public string Username => orderCore.Username;
    public string SecurityId => orderCore.SecurityId;

    public CancelOrder ToCancelOrder()
    {
        return new CancelOrder(this);
    }

    public Order ToNewOrder()
    {
        return new Order(this);
    }
}