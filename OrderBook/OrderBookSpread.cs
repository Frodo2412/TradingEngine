namespace OrderBook;

public class OrderBookSpread
{
    public OrderBookSpread(long? bid, long? ask)
    {
    }

    public long? Bid { get; }
    public long? Ask { get; }

    public long? Spread
    {
        get
        {
            if (Bid != null && Ask != null)
            {
                return Bid! - Ask!;
            }
            else return null;
        }
    }
}