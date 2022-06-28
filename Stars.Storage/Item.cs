namespace Stars.Storage;

public class Item
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public int Amount { get; set; }

    public Item(int id, string name, int amount)
    {
        Id = id;
        Name = name;
        Amount = amount;
    }

    public int Take(int amount)
    {
        Amount -= amount;

        return Amount;
    }

    public int Add(int amount)
    {
        Amount += amount;

        return Amount;
    }
}