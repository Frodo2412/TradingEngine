using TradingEngine.Orders;

namespace OrderBook;

public interface IRetrievalOrderBook : IOrderEntryBook
{
    List<OrderBookEntry> GetAskOrders();
    List<OrderBookEntry> GetBidOrders();
}