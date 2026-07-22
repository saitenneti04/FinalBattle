public class DoNothingAction : GameAction
{
    private readonly Character _character;

    public DoNothingAction(Character character) { _character = character; }
    public override void Run()
    {
        Console.WriteLine($"{_character.Name} did NOTHING.");
    }
}
