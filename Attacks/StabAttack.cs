using System;
using System.Collections.Generic;
using System.Text;

public class StabAttack : Attack
{
    public StabAttack()
    : base("STAB ATTACK") { }

    public override int GetDamage()
    {
        return 1;
    }
}