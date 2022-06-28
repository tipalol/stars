using Stars.Storage;

namespace Stars.Trading;

public class TradingItem : Item
{
    public int Price { get; }
    
    public TradingItem(int id, string name, int amount, int price) : base(id, name, amount)
    {
        Price = price;
    }
}