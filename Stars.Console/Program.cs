using Stars.Console.Extensions;
using Stars.Console.Utils;
using Stars.Core;
using Stars.Storage;

var world = WorldBuilder.Build();
var storage = new Storage<GameItem>(GetStartItems());

var name = Input.Ask("What's your name?");

var player = new PlayerBuilder()
    .WithName(name)
    .WithBalance(1000)
    .InSector(world.StartingSector)
    .HasStorage(storage)
    .Build();

Input.Print($"Hi, {player.Name}! You have {player.Balance} credits.");
Input.Print($"You have {player.Storage.GetAll().Count} items");
Input.Print($"First of them is {player.Storage.GetAll().First(i => i.Id == 0).Name}");

var choose = -1;

while (choose != 0)
{
    PrintInfo(player);
    
    ShowMenu();
    
    choose = Input.AskNumber(string.Empty, 0, 3);

    switch (choose)
    {
        case 1:
            player.Sector.PrintDetailedInfo();

            var locationsCount = player.Sector.Locations.Count();
            var nextLocationIndex = Input.AskNumber(
                "Куда двинемся? (введите номер локации)", 0, locationsCount);
            
            if (nextLocationIndex == 0)
                break;

            var locations = player.Sector.Locations
                .ToArray();
            
            var locationToMove = locations[nextLocationIndex - 1];
            
            locationToMove.Visit(player);
            
            break;
        case 2:
            player.Sector.PrintDetailedInfo();
            
            var sectorsCount = player.Sector.NearSectors.Count();
            var nextSectorIndex = Input.AskNumber(
                "Куда двинемся? (введите номер сектора)", 0, sectorsCount);

            if (nextSectorIndex == 0)
                break;
            
            var sectorToMove = player.Sector.NearSectors.ToArray()[nextSectorIndex - 1];
            
            player.Move(sectorToMove);
            
            break;
        case 3:
            var resources = player.Storage.GetAll();

            foreach (var resource in resources)
                Input.Print($"{resource.Id} - {resource.Amount} т.");
            
            if (resources.Count == 0)
                Input.Print("Отсек пуст, капитан!");

            break;
    }
}


ICollection<GameItem> GetStartItems()
{
    return new List<GameItem>()
    {
        new GameItem(0, "Ore", 10, 3, ItemType.Ore)
    };
}

void ShowMenu()
{
    Input.Print("1 - Посетить объект в секторе");
    Input.Print("2 - Переместиться");
    Input.Print("3 - Грузовой отсек");
    Input.Print("0 - Выйти");
}

void PrintInfo(Player player)
{
    Input.Print($"Капитан {player.Name}");
    Input.Print($"Баланс: {player.Balance} кредитов");
}