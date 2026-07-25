public class UnravelAttack : Attack
{
    private static readonly Random Random = new();
    public UnravelAttack()
        : base("UNRAVEL") { }

    public override int GetDamage()
    {
        return Random.Next(3);
    }

    public override float GetDamageProbability()
    {
        return 1;
    }
}
