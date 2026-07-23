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
        if (healthPotionAvailable && characterHealthUnderHalf && (chance == 0 || chance == 1) )
        {
            return new ItemAction(characterParty.Items[0], character, characterParty);
        }
        
        if (character.Gear == null && characterParty.Gear != null && characterParty.Gear.Count > 0 && chance == 2)
        {
            return new EquipAction(character, characterParty.Gear[0], characterParty);
        }

        if (character.Gear != null) { return new AttackAction(character, character.Gear.Attack, target, enemyParty); }

        return new AttackAction(character, character.StandardAttack, target, enemyParty);
    }
}
