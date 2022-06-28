using Stars.Trading;

namespace Stars.Core.Locations;

public class Station : Location
{
    public Trader Trader { get; set; }
    
    public Station(Guid id, string name, Trader trader) : base(id, name)
    {
        Trader = trader;
    }
}