using System;
using System.Collections.Generic;
using System.Text;

public abstract class AttackModifier
{
    public string Name { get; }
    public int DamageReduction { get; set; }
    public AttackModifier(string name, int value)
    { this.Name = name; DamageReduction = value; }

    public abstract int GetModifiedDamage(int damage);
    public abstract void PrintDamageMessage();
}

public class StoneArmour : AttackModifier
{ 
    public StoneArmour()
        : base("STONE ARMOR", 1) { }

    public override int GetModifiedDamage(int damage)
    {
        return damage - this.DamageReduction;
    }

    public override void PrintDamageMessage()
    { Console.WriteLine($"{this.Name} reduced attack by {this.DamageReduction} "); }
}
