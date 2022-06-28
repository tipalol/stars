using Stars.Core.Abstractions;
using Stars.Storage.Abstractions;
using Stars.Trading;

namespace Stars.Core;

public class Player : Trader, IPlayer
{
    public string Name { get; }
    
    public Sector Sector { get; set; }
    
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