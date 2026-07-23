using System;
using System.Collections.Generic;
using System.Text;

public abstract class Item
{
    public string Name { get; }
    public Item(string name) { Name = name; }

    public abstract void UseItem(Character character);
    public abstract string GetItemInfo();
}

public class HealthPotion : Item
{
    public int HealthIncrease { get; } = 10;
    public HealthPotion()
        : base("Health Potion") { }

    public override void UseItem(Character character)
    {
        character.UseHealthPotion(HealthIncrease);
    }
    public override string GetItemInfo()
    {
        return "improve their HP";
    }
}