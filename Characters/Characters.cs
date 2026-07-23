using System;
using System.Collections.Generic;
using System.Text;



public class Character
{
    public string Name { get; }
    public Attack StandardAttack { get; }

    public int MaxHP { get; }
    public int CurrHP { get; private set; }

    public Character(string name, Attack standardAttack, int maxHP)
    {
        Name = name;
        StandardAttack = standardAttack;
        MaxHP = maxHP;
        CurrHP = maxHP;
    }

    public void ReceiveDamage(int amount)
    {
        CurrHP = Math.Max(0, CurrHP - amount);
    }

    public void UseHealthPotion(int amount)
    {
        CurrHP = Math.Min(MaxHP, CurrHP + amount);
    }
}