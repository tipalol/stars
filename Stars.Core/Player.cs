using Stars.Core.Abstractions;
using Stars.Storage;
using Stars.Storage.Abstractions;
using Stars.Trading;

namespace Stars.Core;

public class Player : Trader, IPlayer
{
    public string Name { get; init; }

    public new IStorage<GameItem> Storage { get; init; }

    public Sector Sector { get; set; }

    public Player(int balance) : base()
    {
        Storage = new Storage<GameItem>(new List<GameItem>());
        Balance = balance;
    }

    public Player(IStorage<TradingItem> storage, int money, string name, Sector sector) : base(storage, money)
    {
        Name = name;
        Sector = sector;
    }

    public void Move(Sector sector)
    {
        if (Sector.NearSectors.Contains(sector) == false)
            return;

        Sector = sector;
    }
}