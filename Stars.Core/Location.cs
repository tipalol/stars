using System;

namespace Stars.Core;

public class Location
{
    public Guid Id { get; }
    
    public string Name { get; }
    
    public Location(Guid id, string name)
    {
        Id = id;
        Name = name;
    }
}