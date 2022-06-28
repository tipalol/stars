using Stars.Trading;

namespace Stars.Core.Extensions;

public static class TradingItemExtensions
{
    public static TradingItem TakeSome(this TradingItem item, int amount)
    {
        return new TradingItem(item.Id, item.Name, amount, item.Price);
    }
}