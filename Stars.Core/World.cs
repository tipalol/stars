namespace Stars.Core;

public class World
{
    public Sector StartingSector { get; }

    public World(Sector startingSector)
    {
        StartingSector = startingSector;
    }
}