using Stars.Core;
using Stars.Core.Locations;

namespace Stars.Console.Extensions;

public static class LocationExtensions
{
    public static void Visit(this Location location, Player player)
    {
        switch (location)
        {
            case Mine mine:
                mine.Visit(player);
                break;
            case Station station:
                station.Visit(player);
                break;
        }
    }

}