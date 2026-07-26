using System;
using System.Collections.Generic;
using System.Text;

public class StabAttack : Attack
{
    public StabAttack()
    : base("STAB ATTACK", DamageType.Normal) { }

    public override int GetDamage()
    {
        return 1;
    }

    public override float GetDamageProbability()
    {
        return 1;
    }
}