using Stars.Console.Utils;
using Stars.Core;

namespace Stars.Console.Extensions;

public static class SectorExtensions
{
    public static void PrintDetailedInfo(this Sector sector)
    {
        sector.PrintInfo();
        
        Input.Print($"Sectors:");

        foreach (var nearSector in sector.NearSectors)
        {
            Input.Print($"Sector {nearSector.Id} ({nearSector.Locations.Count()})");
        }
    }

    public static void PrintInfo(this Sector sector)
    {
        Input.Print($"Sector {sector.Id}. There are {sector.NearSectors.Count()} " +
                    $"near sectors and {sector.Locations.Count()}");

        Input.Print("Locations:");
        foreach (var location in sector.Locations)
        {
            Input.Print($"Location {location.Name}");
        }
    }
}