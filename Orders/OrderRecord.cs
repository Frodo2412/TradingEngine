namespace TradingEngine.Orders;

public record OrderRecord(
    long OrderId,
    long Price,
    uint Quantity,
    bool IsBuySide,
    string Username,
    string SecurityId,
    uint TheoreticalQueuePosition);