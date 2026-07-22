public class Game
{
    private readonly Player _heroPlayer;
    private readonly List<Party> _monsterParties;
    private readonly GameMode _gameMode;

    public Game(Player heroPlayer, List<Party> monsterParties, GameMode gameMode)
    {
        _monsterParties = monsterParties;
        _gameMode = gameMode;
        _heroPlayer = heroPlayer;
    }

    public void Run()
    {
        foreach (Party party in _monsterParties)
        {
            Player monsterPlayer = GetPlayer(party);
            bool heroesWon = RunBattle(monsterPlayer);
            if (!heroesWon)
            {
                Console.WriteLine("Monsters Win the overall battle!");
                return;
            }

        }

        Console.WriteLine();
        Console.WriteLine("The heroes win the battle! Congratulations.");

    }

    private Player GetPlayer(Party party)
    {
        return _gameMode switch
        {
            GameMode.PlayerVsPlayer => new HumanPlayer(party),
            _ => new ComputerPlayer(party)
        };
    }

    private bool RunBattle(Player monsterPlayer)
    {
        while (true)
        {
            bool monstersStillAlive = RunPartyTurns(_heroPlayer, monsterPlayer.Party);
            if (!monstersStillAlive)
            {
                Console.WriteLine("Heroes win, this round!");
                Console.WriteLine();
                return true;
            }


            bool heroesStillAlive = RunPartyTurns(monsterPlayer, _heroPlayer.Party);
            if (!heroesStillAlive)
            {
                Console.WriteLine("Monsters win this round!");
                return false;
            }
        }
    }

    private bool RunPartyTurns(Player player, Party enemyParty)
    {
        foreach (Character character in player.Party.Characters)
        {
            Console.WriteLine($"It is {character.Name}'s turn...");

            GameAction action = player.ChooseAction(character, enemyParty);
            action.Run();
            if (enemyParty.Characters.Count == 0) { return false; }
            Console.WriteLine();
            Thread.Sleep(1000);
        }
        return true;
    }
}
