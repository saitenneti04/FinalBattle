using System;
using System.Collections.Generic;
using System.Text;

public abstract class AttackModifier
{
    public string Name { get; }
    public int DamageReduction { get; set; }
    public AttackModifier(string name, int value)
    { this.Name = name; DamageReduction = value; }

    public int GetModifiedDamage(int damage)
    {
        if (damage - DamageReduction < 0) { return 0; }
        return damage - DamageReduction;
    }
    public void PrintDamageMessage(int difference)
    {
        { Console.WriteLine($"{this.Name} reduced attack by {difference} "); }
    }
}

public class StoneArmour : AttackModifier
{ 
    public StoneArmour()
        : base("STONE ARMOR", 1) { }
}

public class ObjectSight : AttackModifier
{
    public ObjectSight()
        : base("OBJECT SIGHT", 2) { }

}