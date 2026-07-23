public class ComputerPlayer : Player
{
    public static Random random = new Random();
    public ComputerPlayer(Party party)
        : base(party)
    {
    }

    public override GameAction ChooseAction(Party characterParty, Character character, Party enemyParty)
    {
        Character target = enemyParty.Characters[0];
        bool healthPotionAvailable = characterParty.CheckItemsAvailable();
        bool characterHealthUnderHalf = character.CurrHP * 2 < character.MaxHP;
        int chance = random.Next(4);
        if (healthPotionAvailable && characterHealthUnderHalf && chance != 0)
        {
            return new ItemAction(characterParty.Items[0], character, characterParty);
        }
        return new AttackAction(character, character.StandardAttack, target, enemyParty);
    }
}
