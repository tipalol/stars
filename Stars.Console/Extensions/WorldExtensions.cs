using Stars.Core;
using Stars.Core.Locations;
using Stars.Storage;
using Stars.Trading;

namespace Stars.Console.Extensions;

public static class WorldBuilder
{
    private static readonly Random _random = new();
    
    public static World Build()
    {
        var startingSector = GenerateSector(default);

        foreach (var sector in startingSector.NearSectors)
        {
            foreach (var minorSector in sector.NearSectors)
            {
                GenerateSector(minorSector);
            }
        }

        var world = new World(startingSector);

        return world;
    }

    private static Sector GenerateSector(Sector? sourceSector)
    {
        var locations = new List<Location>();

        var locationsCount = _random.Next(3);

        for (var i  = 0; i < locationsCount; i++)
        {
            locations.Add(GenerateLocation());
        }
        
        var nearSectors = new List<Sector>();

        var sector = new Sector(Guid.NewGuid(), nearSectors, locations);
        
        if (sourceSector is not null) 
            nearSectors.Add(sourceSector);
        
        var sectorsCount = _random.Next(2, 4);

        for (var i  = 0; i < sectorsCount; i++)
        {
            nearSectors.Add(GenerateMinorSector(sector));
        }

        return sector;
    }

    private static Sector GenerateMinorSector(Sector sourceSector)
    {
        var locations = new List<Location>();

        var locationsCount = _random.Next(3);

        for (var i  = 0; i < locationsCount; i++)
        {
            locations.Add(GenerateLocation());
        }
        
        var nearSectors = new List<Sector> { sourceSector };

        return new Sector(Guid.NewGuid(), nearSectors, locations);
    }

    private static Location GenerateLocation()
    {
        var locationType = _random.Next(10);

        if (locationType < 7)
        {
            return new Mine(Guid.NewGuid(), "Шахта", Mine.GenerateResource());
        }
        else
        {
            var trader = new Trader(new Storage<TradingItem>(new List<TradingItem>
            {
                Mine.GenerateResource()
            }), 1000);
            
            return new Station(Guid.NewGuid(), "Станция", trader);
        }
    }
}