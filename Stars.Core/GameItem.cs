using Stars.Core.Abstractions;
using Stars.Trading;

namespace Stars.Core;

public class GameItem : TradingItem, IInteractable
{
    public static Dictionary<int, GameItem> ItemPool
        => new()
        {
            {0, new GameItem(0, "Уголь", default, 3, ItemType.Ore)},
            {1, new GameItem(1, "Медная руда", default, 7, ItemType.Ore)},
            {2, new GameItem(1, "Железная руда", default, 12, ItemType.Ore)}
        };

    public ItemType Type { get; }
    
    public GameItem(int id, string name, int amount, int price, ItemType type) : base(id, name, amount, price)
    {
        Type = type;
    }

    public void Interact(Player player)
    {
        throw new NotImplementedException();
    }

    public static GameItem Get(int id, int amount = 1)
    {
        var origin = ItemPool[id];
        var item = new GameItem(id, origin.Name, amount, origin.Price, origin.Type);

        return item;
    }
}