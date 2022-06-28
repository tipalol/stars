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

    public static GameItem GenerateResource()
    {
        var random = new Random();
        var resourceId = random.Next(3);
        
        var resource = GameItem.Get(resourceId, random.Next(1, 7) * 10);
        
        return resource;
    }
}