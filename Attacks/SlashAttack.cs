using System;
using System.Collections.Generic;
using System.Text;

public class SlashAttack : Attack
{
    public SlashAttack()
        : base("SLASH ATTACK", DamageType.Normal) { }

    public override int GetDamage()
    {
        return 2;
    }
    public override float GetDamageProbability()
    {
        return 1;
    }
}