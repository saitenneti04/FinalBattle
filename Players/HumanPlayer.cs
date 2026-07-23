public class HumanPlayer : Player
{
    public HumanPlayer(Party party)
        : base(party) { }

    public override GameAction ChooseAction(Party characterParty, Character character, Party enemyParty)
    {
        List<MenuItem> items = GetMenuItems(character, characterParty, enemyParty);
        for (int i = 0; i < items.Count; i++)
        {
            Console.WriteLine($"{i+1} {items[i].description}.");
        }

        int choice;
        do
        {
            Console.Write("What do you want to do? Pick a number from above: ");
            choice = Convert.ToInt32(Console.ReadLine());
        } while (choice < 1 || choice > items.Count);

        return items[choice - 1].action;
    }

    private List<MenuItem> GetMenuItems(Character character, Party characterParty, Party enemyParty)
    {
        List<MenuItem> items = new List<MenuItem>();
        items.Add(new MenuItem("Standard Attack ({characater.StandardAttackName}", new AttackAction(character, character.StandardAttack, enemyParty.Characters[0], enemyParty)));
        items.Add(new MenuItem("Do Nothing", new DoNothingAction(character)));

        if (characterParty.Items != null)
        {
            for (int i = 0; i < characterParty.Items.Count; i++)
            {
                items.Add(new MenuItem($"Select item {i + 1} from party inventory = {characterParty.Items[i].Name}", new ItemAction(characterParty.Items[i], character, characterParty)));
            }
        }
        if (characterParty.Gear != null)
        {
            for (int i = 0; i < characterParty.Gear.Count; i++)
            {
                items.Add(new MenuItem($"Select gear {i + 1} from party inventory to equip character = {characterParty.Gear[i].Name}", new EquipAction(character, characterParty.Gear[i], characterParty)));
            }
        }
        if (character.Gear != null) { items.Add(new MenuItem($"Gear attack - {character.Gear.Attack.Name}", new AttackAction(character, character.Gear.Attack, enemyParty.Characters[0], enemyParty))); }

        return items;
    }


}

record MenuItem(string description, GameAction action);