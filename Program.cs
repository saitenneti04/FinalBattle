Console.Write("What's your name: ");
string name = Console.ReadLine() ?? "Programmer";

Party heroes = new Party(
    new List<Character> { new TrueProgrammer(name) },
    "HEROES"
);


Party monstersOne = new Party(
    new List<Character> { new Skeleton() },
    "MONSTERS"
);
Party monstersTwo = new Party(
    new List<Character> { new Skeleton(), new Skeleton() },
    "MONSTERS"
);

Party UncodedOne = new Party(new List<Character> { new UncodedOne() }, "Monsters");


int choice;
do
{
    Console.WriteLine("Pick a game mode:");
    Console.WriteLine("1. Human vs Human, 2: Human vs Computer, 3: Computer vs Computer: ");
    choice = Convert.ToInt32(Console.ReadLine());
} while (choice != 1 && choice != 2 && choice != 3);

GameMode gameMode = choice switch
{
    1 => GameMode.PlayerVsPlayer,
    2 => GameMode.PlayerVsComputer,
    3 => GameMode.ComputerVsComputer
};

List<Party> monsterParties = new List<Party> {monstersOne, monstersTwo, UncodedOne};



Game game = gameMode switch
{
    GameMode.ComputerVsComputer => new Game(new ComputerPlayer(heroes), monsterParties, gameMode),
    _ => new Game(new HumanPlayer(heroes), monsterParties, gameMode)
};

game.Run();

public class Character
{
    public string Name { get; }
    public Attack StandardAttack { get; }

    public int MaxHP { get; }
    public int CurrHP { get; private set; }

    public Character(string name, Attack standardAttack, int maxHP)
    {
        Name = name;
        StandardAttack = standardAttack;
        MaxHP = maxHP;
        CurrHP = maxHP;
    }

    public void ReceiveDamage(int amount)
    {
        CurrHP = Math.Max(0, CurrHP - amount);
    }
}

public class UncodedOne : Character
{
    public UncodedOne()
        : base("THE UNCODED ONE", new UnravelAttack(), 15) { }
}


public class TrueProgrammer : Character
{
    public TrueProgrammer(string name)
        : base(name, new Punch(), 25)
    {
    }
}


public class Skeleton : Character
{
    public Skeleton()
        : base("SKELETON", new BoneCrunch(), 5)
    {
    }
}


public class Party
{
    public string Name { get; }
    public List<Character> Characters { get; }

    public Party(List<Character> characters, string name)
    {
        Characters = characters;
        Name = name;
    }

    public void RemoveCharacter(Character character) { Characters.Remove(character); }
}

public abstract class Attack
{
    public string Name{ get; }
    public Attack(string name) { Name = name; }
    public abstract int GetDamage();

}

public class UnravelAttack : Attack
{
    private static readonly Random Random = new();
    public UnravelAttack()
        : base("UNRAVEL") { }

    public override int GetDamage()
    {
        return Random.Next(3);
    }
}


public class Punch : Attack
{
    public Punch()
        : base("PUNCH") { }

    public override int GetDamage()
    {
        return 1;
    }
}

public class BoneCrunch : Attack
{
    private static readonly Random Random = new();
    public BoneCrunch()
        : base("BONE CRUNCH") { }

    public override int GetDamage()
    {
        return Random.Next(2);
    }
}

public abstract class GameAction
{
    public abstract void Run();
}


public class DoNothingAction : GameAction
{
    private readonly Character _character;

    public DoNothingAction(Character character) { _character = character; }
    public override void Run()
    {
        Console.WriteLine($"{_character.Name} did NOTHING.");
    }
}

public class AttackAction : GameAction
{
    private readonly Character _attacker;
    private readonly Attack _attack;
    private readonly Character _target;
    private readonly Party _enemyParty;

    public AttackAction(Character attacker, Attack attack, Character target, Party enemyParty)
    {
        _attacker = attacker;
        _attack = attack;
        _target = target;
        _enemyParty = enemyParty;
    }

    private void CheckDefeat()
    {
        if (_target.CurrHP == 0) 
        { 
            _enemyParty.RemoveCharacter(_target);
            Console.WriteLine($"{_target.Name} has been defeated!");
        }

    }
    public override void Run()
    {
        Console.WriteLine($"{_attacker.Name} used {_attack.Name} on {_target.Name}."); 
        int damage = _attack.GetDamage();
        _target.ReceiveDamage( damage );
        Console.WriteLine($"{_attack.Name} dealt {damage} damage to {_target.Name}.");
        Console.WriteLine($"{_target.Name} is now at {_target.CurrHP}/{_target.MaxHP} HP.");
        CheckDefeat();
    }
}

public abstract class Player
{
    public Party Party { get; }

    protected Player(Party party)
    {
        Party = party;
    }

    public abstract GameAction ChooseAction(Character character, Party enemy);
}

public class HumanPlayer : Player
{
    public HumanPlayer(Party party)
        : base(party) { }

    public override GameAction ChooseAction(Character character, Party enemyParty)
    {
        Character target = enemyParty.Characters[0];

        int choice = GetChoice(character);

        if (choice == 2) { return new DoNothingAction(character); }
        else { return new AttackAction(character, character.StandardAttack, target, enemyParty); }

    }

    private int GetChoice(Character character)
    {
        int choice;
        do
        {
            Console.WriteLine($"1 - Standard Attack ({character.StandardAttack.Name})");
            Console.WriteLine("2 - Do Nothing");
            Console.Write("What do you want to do? Pick a number from above: ");
            choice = Convert.ToInt32(Console.ReadLine());
        } while (choice != 1 && choice != 2);
        return choice;
    }
}

public class ComputerPlayer : Player
{
    public ComputerPlayer(Party party)
        : base(party)
    {
    }

    public override GameAction ChooseAction(Character character, Party enemyParty)
    {
        Character target = enemyParty.Characters[0];
        return new AttackAction(character, character.StandardAttack, target, enemyParty);
    }
}


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

public enum GameMode { PlayerVsComputer, ComputerVsComputer, PlayerVsPlayer };