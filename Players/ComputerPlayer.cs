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
