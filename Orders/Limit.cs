namespace TradingEngine.Orders;

public class Limit
{
    public Limit(long orderPrice)
    {
        Price = orderPrice;
    }

    public long Price { get; private set; }
    public OrderBookEntry? Head { get; set; }
    public OrderBookEntry? Tail { get; set; }
    public bool IsEmpty => Head == null && Tail == null;

    public Side IsBuySide
    {
        get
        {
            if (IsEmpty)
            {
                return Side.Unknown;
            }
            else
            {
                return Head!.CurrentOrder.IsBuySide ? Side.Bid : Side.Ask;
            }
        }
    }

    public uint GetLevelOrderCount()
    {
        uint orderCount = 0;
        var currentPointer = Head;

        while (currentPointer != null)
        {
            if (currentPointer.CurrentOrder.CurrentQuantity != 0)
                orderCount++;
            currentPointer = currentPointer.Next;
        }

        return orderCount;
    }

    public uint GetLevelOrderQuantity()
    {
        uint orderQuantity = 0;
        var currentPointer = Head;

        while (currentPointer != null)
        {
            if (currentPointer.CurrentOrder.CurrentQuantity != 0)
                orderQuantity += currentPointer.CurrentOrder.CurrentQuantity;
            currentPointer = currentPointer.Next;
        }

        return orderQuantity;
    }

    public List<OrderRecord> GetLevelOrderRecords()
    {
        var orderRecords = new List<OrderRecord>();
        var currentPointer = Head;
        uint theoreticalQueuePosition = 0;

        while (currentPointer != null)
        {
            var currentOrder = currentPointer.CurrentOrder;
            if (currentOrder.CurrentQuantity == 0) continue;

            orderRecords.Add(new OrderRecord(currentOrder.OrderId, Price, currentOrder.CurrentQuantity,
                currentOrder.IsBuySide, currentOrder.Username, currentOrder.SecurityId, theoreticalQueuePosition));
            theoreticalQueuePosition++;
            currentPointer = currentPointer.Next;
        }

        return orderRecords;
    }
}