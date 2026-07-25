using System;
using System.Collections.Generic;
using System.Text;

public class QuickShot : Attack
{
    public QuickShot()
        : base("QUICK SHOT") { }

    public override int GetDamage()
    {
        return 3;
    }
    public override float GetDamageProbability()
    {
        return 0.5f;
    }
}