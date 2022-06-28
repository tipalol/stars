using Stars.Trading;

namespace Stars.Core.Extensions;

public static class GameItemExtensions
{
    public static GameItem TakeSome(this GameItem item, int amount)
    {
        return new GameItem(item.Id, item.Name, amount, item.Price, ItemType.Ore);
    }
    
    public static TradingItem TakeSome(this TradingItem item, int amount)
    {
        return new TradingItem(item.Id, item.Name, amount, item.Price);
    }
}