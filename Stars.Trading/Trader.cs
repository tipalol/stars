using Stars.Storage;
using Stars.Storage.Abstractions;
using Stars.Trading.Abstractions;

namespace Stars.Trading;

public class Trader : ITrader
{
    public int Balance { get; protected set; }

    public IStorage<TradingItem> Storage { get; init; }

    public Trader()
    {
        Storage = new Storage<TradingItem>(new List<TradingItem>());
    }

    public Trader(IStorage<TradingItem> storage, int money)
    {
        Storage = storage;
        Balance = money;
    }
    
    public void Buy(TradingItem item)
    {
        Balance -= GetPrice(item);
        
        Storage.Add(item);
    }

    public void Sell(TradingItem item)
    {
        Balance += GetPrice(item);
        
        Storage.Take(item);
    }
    
    public bool HasEnoughMoneyFor(TradingItem item)
    {
        var need = item.Amount * item.Price;

        return Balance > need;
    }

    private int GetPrice(TradingItem item)
    {
        return item.Amount * item.Price;
    }
}