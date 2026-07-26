public abstract class Attack
{
    public string Name{ get; }
    public DamageType DamageType { get; }
    public Attack(string name, DamageType type) { Name = name; DamageType = type; }
    public abstract int GetDamage();
    public abstract float GetDamageProbability();

}

public enum DamageType { Normal, Decoding}