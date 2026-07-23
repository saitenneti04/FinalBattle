public abstract class Player
{
    public Party Party { get; }

    protected Player(Party party)
    {
        Party = party;
    }

    public abstract GameAction ChooseAction(Party characterParty, Character character, Party enemy);
}
