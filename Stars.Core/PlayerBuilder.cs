using Stars.Storage.Abstractions;

namespace Stars.Core;

public class PlayerBuilder
{
    private PlayerInfo _player = new PlayerInfo();

    public PlayerBuilder WithName(string name)
    {
        _player.Name = name;

        return this;
    }

    public PlayerBuilder WithBalance(int money)
    {
        _player.Balance = money;

        return this;
    }

    public PlayerBuilder InSector(Sector sector)
    {
        _player.Sector = sector;

        return this;
    }

    public PlayerBuilder HasStorage(IStorage<GameItem> storage)
    {
        _player.Storage = storage;

        return this;
    }

    public Player Build()
    {
        return new Player(_player.Balance)
        {
            Name = _player.Name,
            Sector = _player.Sector,
            Storage = _player.Storage
        };
    }

    private class PlayerInfo
    {
        public string Name { get; set; }

        public int Balance { get; set; }

        public Sector Sector { get; set; }
        
        public IStorage<GameItem> Storage { get; set; }
    }
}