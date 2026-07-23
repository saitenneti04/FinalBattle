using System;
using System.Collections.Generic;
using System.Text;

public class SlashAttack : Attack
{
    public SlashAttack()
        : base("SLASH ATTACK") { }

    public override int GetDamage()
    {
        return 2;
    }
}