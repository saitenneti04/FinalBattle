
Console.Write("What's your name: ");
string name = Console.ReadLine() ?? "Programmer";

Party heroes = new Party(
    new List<Character> { new TrueProgrammer(name) },
    "HEROES", new List<Item> { new HealthPotion(), new HealthPotion(), new HealthPotion()}
);


Party monstersOne = new Party(
    new List<Character> { new Skeleton() },
    "MONSTERS", new List<Item> { new HealthPotion() }
);
Party monstersTwo = new Party(
    new List<Character> { new Skeleton(), new Skeleton() },
    "MONSTERS", new List<Item> { new HealthPotion() }
);

Party UncodedOne = new Party(new List<Character> { new UncodedOne() },
    "Monsters", new List<Item> { new HealthPotion() }
   );


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
