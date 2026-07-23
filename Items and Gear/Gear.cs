using System;
using System.Collections.Generic;
using System.Text;

public abstract class Gear
{
    public string Name { get; set; }
    public Attack Attack { get; }
    public Gear(string name, Attack attack)
    {  Name = name; Attack = attack; }
    
}

public class Sword : Gear
{
    public Sword()
        : base("Sword", new SlashAttack()) { }

}

public class Dagger : Gear
{
    public Dagger()
        : base("Dagger", new StabAttack()) { }
}