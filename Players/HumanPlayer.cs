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
