using TradingEngine.Orders;

namespace OrderBook;

public interface IOrderEntryBook : IReadOnlyOrderBook
{
    void AddOrder(Order order);
    void RemoveOrder(CancelOrder cancelOrder);
    void ModifyOrder(ModifyOrder modifyOrder);
}