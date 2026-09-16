namespace TradingEngine.Orders;

public class Order(IOrderCore orderCore, long price, uint quantity, bool isBuySide)
    : IOrderCore
{
    public Order(ModifyOrder modifyOrder) : this(modifyOrder, modifyOrder.Price, modifyOrder.Quantity,
        modifyOrder.IsBuySide)
    {
    }

    public long Price { get; } = price;
    public uint InitialQuantity { get; } = quantity;
    public uint CurrentQuantity { get; private set; } = quantity;
    public bool IsBuySide { get; set; } = isBuySide;

    public void IncreaseQuantity(uint quantityDelta)
    {
        CurrentQuantity += quantityDelta;
    }

    public void DecreaseQuantity(uint quantityDelta)
    {
        if (quantityDelta > CurrentQuantity)
            throw new InvalidOperationException($"Quantity delta > Current quantity for order {OrderId}");
        CurrentQuantity -= quantityDelta;
    }


    public long OrderId => orderCore.OrderId;
    public string Username => orderCore.Username;
    public string SecurityId => orderCore.SecurityId;
}