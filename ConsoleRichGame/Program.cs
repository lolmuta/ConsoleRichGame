using ConsoleRichGame;
using ConsoleRichGame.M;
LogHelper.Init();

//inital game 
var landsCount = 10;
var lands = new Land[landsCount];
var players = new List<AbstractPlayer>();
for (int i = 0; i < landsCount; i++)
{
    lands[i] = new Land()
    {
        BuyWhenEmpty = 1,
        Pay = 1
    };
}
players.Add(new PlayerHuman() { Money = 10, Name = "A", LocationIndex = 0 });
//players.Add(new PlayerComputer() { Money = 10, Name = "A", LocationIndex = 0 });
players.Add(new PlayerComputer() { Money = 10, Name = "B", LocationIndex = 0 });
players.Add(new PlayerComputer() { Money = 10, Name = "C", LocationIndex = 0 });
players.Add(new PlayerComputer() { Money = 10, Name = "D", LocationIndex = 0 });
//inital game end

main();

void main()
{

    try
    {
        playGame();
        LogHelper.Info("playGame finish");
    }
    catch (Exception ex)
    {
        LogHelper.Error(ex, "發生異常!");
        throw;
    }
}
void playGame()
{
    while (true)
    {
        eachRound();
        var isOnlyOnePlayerStillive = players.IsOnlyOnePlayerStillive();
        if (isOnlyOnePlayerStillive)
        {
            break;
        }
    }
    var owner = players.Where(x => x.IsBankruptcy == false).First();
    LogHelper.Info($"Player {owner.Name} own the game!");
    LogHelper.Info($"Game over, press any key to exit");
    Console.ReadKey();
}
void eachRound()
{
    PlayerUi.UpdateShowLandInfo(lands, players, true);

    foreach (var player in players)
    {
        PlayerUi.LoadMsgStartLocation();
        if (player.IsBankruptcy)
        {
            LogHelper.Info($"Player {player.Name} is Bankruptcy skip this turn.");
            LogHelper.Info($"Press any key to continue...");
            Console.ReadKey();
            continue;
        }
        LogHelper.Info($"Player {player.Name} at land {player.LocationIndex}");
        var move = player.Move();
        LogHelper.Info($"Player {player.Name} dice {move}");
        var loc = (player.LocationIndex + move) % landsCount;
        player.LocationIndex = loc;
        LogHelper.Info($"Player {player.Name} move to land {player.LocationIndex}");
        PlayerUi.UpdateShowLandInfo(lands, players, true);

        var land = lands[player.LocationIndex];
        player.ArrivedLandAction(land, players);

        if (player.IsBankruptcy)
        {
            LogHelper.Info($"Player {player.Name} is bankruptcy");
            lands.Where(x => x.Owner == player.Name).ToList().ForEach(x =>
            {
                x.EmptyOwner();
            });
        }
        PlayerUi.UpdateShowLandInfo(lands, players, true);
        Console.WriteLine("press any key to continue....");
        Console.ReadKey();
        PlayerUi.ClearMsg(20);
    }

}









