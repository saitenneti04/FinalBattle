public class HumanPlayer : Player
{
    public HumanPlayer(Party party)
        : base(party) { }

    public override GameAction ChooseAction(Party characterParty, Character character, Party enemyParty)
    {
        Character target = enemyParty.Characters[0];

        int choice = GetChoice(character, characterParty);

        if (choice == 2) { return new DoNothingAction(character); }
        else if (choice == 1) { return new AttackAction(character, character.StandardAttack, target, enemyParty); }
        else
        {
            Item item = GetItemChoice(characterParty);
            return new ItemAction(item, character, characterParty);
        }
    }

    private Item GetItemChoice(Party characterParty)
    {
        for (int i = 0; i < characterParty.Items.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {characterParty.Items[i].Name}");
        }
        int itemChoice;

        do
        {
            Console.Write("What do you want to do? Pick a number from above: ");
            itemChoice = Convert.ToInt32(Console.ReadLine());
        } while (itemChoice < 1 || itemChoice > characterParty.Items.Count);
        return characterParty.Items[itemChoice - 1];

    }

    private int GetChoice(Character character, Party characterParty)
    {
        bool itemsAvailable;
        int choice;
        do
        {
            Console.WriteLine($"1 - Standard Attack ({character.StandardAttack.Name})");
            Console.WriteLine("2 - Do Nothing");
            itemsAvailable = characterParty.CheckItemsAvailable();
            if (itemsAvailable) { Console.WriteLine("3 - Select an item from party inventory"); }
            Console.Write("What do you want to do? Pick a number from above: ");
            choice = Convert.ToInt32(Console.ReadLine());
        } while ((choice != 1 && choice != 2 && !itemsAvailable) || (choice != 1 && choice != 2 && choice != 3 && itemsAvailable) );
        return choice;
    }

}
