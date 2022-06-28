using System.Collections.Generic;
using FluentAssertions;
using Stars.Core;
using Stars.Storage;
using Xunit;

namespace Stars.UnitTests;

public class StorageTests
{
    [Fact]
    public void PutItemToEmptyStorage()
    {
        var storage = new Storage<GameItem>(new List<GameItem>());
        var itemToPut = GameItem.Get(0, 100);

        storage.Add(itemToPut);

        storage.Has(itemToPut).Should().BeTrue();
    }

    [Fact]
    public void AddExistingItems()
    {
        var existingItem = GameItem.Get(0, 100);
        var storage = new Storage<GameItem>(new List<GameItem> {existingItem});
        
        storage.Add(GameItem.Get(existingItem.Id, 100));

        storage.Has(GameItem.Get(existingItem.Id, amount: 200)).Should().BeTrue();
    }
    
    [Fact]
    public void AddAnotherItems()
    {
        var existingItem = GameItem.Get(0, 100);
        var storage = new Storage<GameItem>(new List<GameItem> {existingItem});
        
        storage.Add(GameItem.Get(1, 50));

        storage.Has(GameItem.Get(0, amount: 100)).Should().BeTrue();
        storage.Has(GameItem.Get(1, amount: 50)).Should().BeTrue();
    }
    
    [Fact]
    public void RemoveItems()
    {
        var existingItem = GameItem.Get(0, 100);
        var storage = new Storage<GameItem>(new List<GameItem> {existingItem});
        
        storage.Take(GameItem.Get(0, 60));

        storage.Has(GameItem.Get(0, amount: 100)).Should().BeFalse();
    }
    
    [Fact]
    public void CheckHasItem()
    {
        var existingItem = GameItem.Get(0, 100);
        var storage = new Storage<GameItem>(new List<GameItem>{ existingItem });

        storage.Has(existingItem).Should().BeTrue();
        storage.GetAll().Should()
            .Contain(x => x.Id == existingItem.Id && x.Amount == existingItem.Amount);

        var notExistingItem = GameItem.Get(2, 10);
        
        storage.Has(notExistingItem).Should().BeFalse();
    }
}