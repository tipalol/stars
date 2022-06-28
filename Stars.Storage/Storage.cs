using System.Collections.Immutable;
using Stars.Storage.Abstractions;
using Stars.Storage.Exceptions;

namespace Stars.Storage;

public class Storage<TItem> : IStorage<TItem> where TItem : Item
{
    private readonly ICollection<TItem> _items;

    public Storage(ICollection<TItem> items)
    {
        _items = items;
    }

    public void Add(TItem item)
    {
        if (item.Amount <= 0)
            return;
        
        var itemToAdd = _items.FirstOrDefault(i => i.Id == item.Id) ?? InitEmpty(item);

        itemToAdd.Add(item.Amount);
    }

    public void Take(TItem item)
    {
        var itemToTake = _items.FirstOrDefault(i => i.Id == item.Id);

        if (itemToTake is null)
            return;

        _ = itemToTake.Amount >= item.Amount 
            ? throw new NotEnoughItemsException(item.Id) : itemToTake.Take(item.Amount);
    }

    public bool Has(TItem item)
    {
        var need = _items.FirstOrDefault(i => i.Id == item.Id);

        if (need is null)
            return false;

        return need.Amount >= item.Amount;
    }

    public IReadOnlyList<TItem> GetAll()
    {
        return _items.OrderBy(x => x.Id).ToImmutableList();
    }

    private TItem InitEmpty(TItem item)
    {
        _items.Add(item);

        return item;
    }
}