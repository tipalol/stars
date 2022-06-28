using Stars.Core.Locations;
using Stars.Storage;
using Stars.Trading;

namespace Stars.Core;

public class MiningProcess
{
    public const int MiningSpeedInSeconds = 2;
    
    private readonly Player _player;

    private readonly Mine _mine;
    
    public MiningProcess(Player player, Mine mine)
    {
        _player = player;
        _mine = mine;
    }

    /// <summary>
    /// Начинает добычу руды
    /// </summary>
    public async Task Start(CancellationToken token)
    {
        var timespan = TimeSpan.FromSeconds(MiningSpeedInSeconds);
        var resource = _mine.Resource;
        
        while (token.IsCancellationRequested == false && resource.Amount > 0)
        {
            await Task.Delay(timespan, token);

            resource.Take(1);
            _mine.MineResource(_player);
        }
    }

}