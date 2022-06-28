using System;
using System.Collections.Generic;

namespace Stars.Core;

public class Sector
{
    public Guid Id { get; }
    
    public IEnumerable<Sector> NearSectors { get; }
    
    public IEnumerable<Location> Locations { get; }

    public Sector(Guid id, IEnumerable<Sector> nearSectors, IEnumerable<Location> locations)
    {
        Id = id;
        NearSectors = nearSectors;
        Locations = locations;
    }
}