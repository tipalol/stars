using Stars.Storage.Abstractions;

namespace Stars.Trading.Abstractions;

public interface ITrader
{
    public IStorage<TradingItem> Storage { get; }

    public void Buy(TradingItem item);

    public void Sell(TradingItem item);
    
    public int Balance { get; }

    public bool HasEnoughMoneyFor(TradingItem item);
}