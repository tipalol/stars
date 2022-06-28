using Stars.Console.Utils;
using Stars.Core;
using Stars.Core.Extensions;
using Stars.Core.Locations;

namespace Stars.Console.Extensions;

public static class StationExtensions
{
    public static void Visit(this Station station, Player player)
    {
        var choose = -1;

        while (choose != 0)
        {
            Input.Clear();

            station.PrintMenu();

            choose = Input.AskNumber(string.Empty, 0, 1);

            switch (choose)
            {
                case 1:
                    Input.Print($"Ваш баланс: {player.Balance}");
                    Input.Print($"Баланс терминала: {station.Trader.Balance}");

                    var tradeOption = -1;

                    while (tradeOption != 0)
                    {
                        tradeOption = Input.AskNumber("Купить (1) или продать (2)", 0, 2);

                        switch (tradeOption)
                        {
                            case 1:
                                Input.Print($"Хранилище терминала:");

                                var traderItems = station.Trader.Storage.GetAll();

                                foreach (var item in traderItems)
                                {
                                    Input.Print($"{item.Name} - {item.Amount} шт. по цене {item.Price} кредитов");
                                }
                                
                                var itemToBuyIndex = Input.AskNumber($"Что берем? (0 - ничего)", 0, traderItems.Count);

                                if (itemToBuyIndex is 0)
                                    break;

                                var itemToBuy = traderItems[itemToBuyIndex-1];
                                
                                var amount = Input.AskNumber($"Сколько берем?", 0, itemToBuy.Amount);

                                if (amount is 0)
                                    break;

                                var tradingItem = itemToBuy.TakeSome(amount);

                                if (player.HasEnoughMoneyFor(tradingItem) is not true)
                                {
                                    Input.Print("Денег нет, но вы держитесь");
                                    break;
                                }
                                    
                                player.Buy(tradingItem);
                                station.Trader.Sell(tradingItem);
                                
                                Input.Print("Спасибо за покупку!");
                                
                                break;
                            case 2:
                                Input.Print($"Хранилище корабля:");

                                var playerItems = player.Storage.GetAll();

                                foreach (var item in playerItems)
                                {
                                    Input.Print($"{item.Name} - {item.Amount} шт. по цене {item.Price} кредитов");
                                }
                                
                                itemToBuyIndex = Input.AskNumber($"Что продаем? (0 - ничего)", 0, playerItems.Count);

                                if (itemToBuyIndex is 0)
                                    break;

                                var itemToSell = playerItems[itemToBuyIndex-1];
                                
                                amount = Input.AskNumber($"Сколько продаем?", 0, itemToSell.Amount);

                                if (amount is 0)
                                    break;

                                tradingItem = itemToSell.TakeSome(amount);

                                if (station.Trader.HasEnoughMoneyFor(tradingItem) is not true)
                                {
                                    Input.Print("В терминале недостаточно кредитов");
                                    break;
                                }
                                    
                                player.Sell(tradingItem);
                                station.Trader.Buy(tradingItem);
                                
                                Input.Print("С вами приятно иметь дело!");

                                break;
                        }
                    }
                    
                    break;
            }
        }
    }
    
    private static void PrintMenu(this Station station)
    {
        Input.Print($"{station.Name}");
        Input.Print("1 - Торговый терминал");
        Input.Print("0 - Выйти");
    }

}