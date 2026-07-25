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
                TransferItems(_heroPlayer.Party, monsterPlayer.Party);
                TransferGear(_heroPlayer.Party, monsterPlayer.Party);
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
            DisplayStatus.DisplayGameStatus(player.Party, character, enemyParty);
            Console.WriteLine($"It is {character.Name}'s turn...");

            GameAction action = player.ChooseAction(player.Party,character, enemyParty);
            action.Run();
            if (enemyParty.Characters.Count == 0) { return false; }
            Console.WriteLine();
            Thread.Sleep(1000);
        }
        return true;
    }

    private void TransferItems(Party winner, Party Loser)
    {
        if (Loser.Items == null || Loser.Items.Count == 0) { return; }
        Console.WriteLine($"The following items are being transferred to the winning party: ");
        for (int i = 0; i < Loser.Items.Count; i++) {
            winner.Items.Add(Loser.Items[i]);
            Console.WriteLine($"Item {i + 1}: {Loser.Items[i].Name}");
        }
        Loser.Items.Clear();
    }

    private void TransferGear(Party winner, Party Loser)
    {
        if (Loser.Gear == null || Loser.Gear.Count == 0) { return; }
        Console.WriteLine($"The following gear is being transferred to the winning party: ");
        for (int i = 0; i < Loser.Gear.Count; i++)
        {
            winner.Gear.Add(Loser.Gear[i]);
            Console.WriteLine($"Gear numer {i + 1}: {Loser.Gear[i].Name}");
        }
        Loser.Gear.Clear();
    }

}

