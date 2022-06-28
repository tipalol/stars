namespace Stars.Storage.Abstractions;

public interface IStorage<TItem> where TItem : Item
{
    public void Add(TItem item);

    public void Take(TItem item);

    public bool Has(TItem item);

    public IReadOnlyList<TItem> GetAll();
}