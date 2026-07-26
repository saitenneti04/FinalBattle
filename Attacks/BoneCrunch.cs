public class BoneCrunch : Attack
{
    private static readonly Random Random = new();
    public BoneCrunch()
        : base("BONE CRUNCH", DamageType.Decoding) { }

    public override int GetDamage()
    {
        return Random.Next(2);
    }

    public override float GetDamageProbability()
    {
        return 1;
    }
}
