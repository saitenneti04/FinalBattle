public class UnravelAttack : Attack
{
    private static readonly Random Random = new();
    public UnravelAttack()
        : base("UNRAVEL", DamageType.Decoding) { }

    public override int GetDamage()
    {
        return Random.Next(5);
    }

    public override float GetDamageProbability()
    {
        return 1;
    }
}
