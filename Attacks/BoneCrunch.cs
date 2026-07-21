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
