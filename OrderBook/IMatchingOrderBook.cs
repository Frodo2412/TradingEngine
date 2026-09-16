namespace OrderBook;

public interface IMatchingOrderBook : IRetrievalOrderBook
{
    MatchResult Match();
}