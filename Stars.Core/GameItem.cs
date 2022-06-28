using Stars.Core.Abstractions;
using Stars.Trading;

namespace Stars.Core;

public class GameItem : TradingItem, IInteractable
{
    public ItemType Type { get; }
    
    public GameItem(int id, string name, int amount, int price, ItemType type) : base(id, name, amount, price)
    {
        Type = type;
    }

    public void Interact(Player player)
    {
        throw new NotImplementedException();
    }
}