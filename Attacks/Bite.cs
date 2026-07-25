using System;
using System.Collections.Generic;
using System.Text;

public class Bite : Attack
{
    public Bite()
        : base("BITE") { }

    public override int GetDamage()
    {
        return 1;
    }

    public override float GetDamageProbability()
    {
        return 1;
    }
}