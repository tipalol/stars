using Stars.Trading;
using Stars.Core.Extensions;

namespace Stars.Core.Locations;

public class Mine : Location
{
    public GameItem Resource { get; set; }
    
    public Mine(Guid id, string name, GameItem resource) : base(id, name)
    {
        Resource = resource;
    }

    public void MineResource(Player player)
    {
        player.Storage.Add(Resource.TakeSome(1));
        Resource.Take(1);
    }
}