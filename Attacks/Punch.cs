public class Punch : Attack
{
    public Punch()
        : base("PUNCH") { }

    public override int GetDamage()
    {
        return 1;
    }

    public override float GetDamageProbability()
    {
        return 1;
    }
}
