namespace OrderBook;

public interface IReadOnlyOrderBook
{
    public int Count { get; }
    bool ContainsOrder(float orderId);
    OrderBookSpread GetSpread();
}