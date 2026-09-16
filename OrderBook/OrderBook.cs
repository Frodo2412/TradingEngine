using TradingEngine.Instrument;
using TradingEngine.Orders;

namespace OrderBook;

public class OrderBook : IRetrievalOrderBook
{
    private readonly Security _instrument;
    private readonly Dictionary<long, OrderBookEntry> _orders = new();
    private readonly SortedSet<Limit> _askLimits = new(AskLimitComparer.Comparer);
    private readonly SortedSet<Limit> _bidLimits = new(BidLimitComparer.Comparer);

    public OrderBook(Security instrument)
    {
        _instrument = instrument;
    }

    public int Count => _orders.Count;

    public bool ContainsOrder(float orderId)
    {
        throw new NotImplementedException();
    }

    public OrderBookSpread GetSpread()
    {
        throw new NotImplementedException();
    }

    public void AddOrder(Order order)
    {
        var baseLimit = new Limit(order.Price);
        AddOrder(order, baseLimit, order.IsBuySide ? _bidLimits : _askLimits, _orders);
    }

    private static void AddOrder(Order order, Limit baseLimit, SortedSet<Limit> limitLevels,
        Dictionary<long, OrderBookEntry> internalBook)
    {
        var newEntry = new OrderBookEntry(order, baseLimit);
        if (limitLevels.TryGetValue(baseLimit, out var limit))
        {
            if (limit.Head == null)
            {
                limit.Head = newEntry;
            }
            else
            {
                var tailPointer = limit.Tail;
                tailPointer?.Next = newEntry;
                newEntry.Previous = tailPointer!;
            }

            limit.Tail = newEntry;
        }
        else
        {
            limitLevels.Add(baseLimit);
            baseLimit.Head = newEntry;
            baseLimit.Tail = newEntry;
        }

        internalBook.Add(order.OrderId, newEntry);
    }

    public void RemoveOrder(CancelOrder cancelOrder)
    {
        throw new NotImplementedException();
    }

    public void ModifyOrder(ModifyOrder modifyOrder)
    {
        throw new NotImplementedException();
    }

    public List<OrderBookEntry> GetAskOrders()
    {
        throw new NotImplementedException();
    }

    public List<OrderBookEntry> GetBidOrders()
    {
        throw new NotImplementedException();
    }
}