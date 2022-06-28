using Stars.Console.Utils;
using Stars.Core;
using Stars.Core.Locations;

namespace Stars.Console.Extensions;

public static class MineExtensions
{
    public static void Visit(this Mine mine, Player player)
    {
        var choose = -1;

        while (choose != 0)
        {
            Input.Clear();

            mine.PrintMenu();
            
            choose = Input.AskNumber(string.Empty, 0, 1);

            switch (choose)
            {
                case 1:
                    var source = new CancellationTokenSource();
                    var token = source.Token;
                    
                    var mining = new MiningProcess(player, mine);
                    var initialAmount = mine.Resource.Amount;
                    
                    mining.Start(token);
                    
                    Input.Print($"Скорость добычи: 1 тонна / {MiningProcess.MiningSpeedInSeconds} с.");
                    Input.Print("Для прекращения добычи нажмите любую кнопку");

                    Input.WaitKeyPress();

                    source.Cancel();
                    source.Dispose();
                    
                    Input.Print($"Добыто {initialAmount - mine.Resource.Amount}");

                    break;
            }
        }
    }
    
    private static void PrintMenu(this Mine mine)
    {
        Input.Print("Вы находитесь на шахте");
        Input.Print($"Ресурсы: {mine.Resource.Name} - {mine.Resource.Amount} тонн");
        
        Input.Print("1 - Добывать руду");
        Input.Print("0 - Выйти");
    }

}