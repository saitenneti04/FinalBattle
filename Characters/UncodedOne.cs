using System;
using System.Collections.Generic;
using System.Text;

public class UncodedOne : Character
{
    public UncodedOne()
        : base("THE UNCODED ONE", new UnravelAttack(), 15, null) { }
}


public class TrueProgrammer : Character
{
    public TrueProgrammer(string name)
        : base(name, new Punch(), 25, new Sword())
    {
    }
}