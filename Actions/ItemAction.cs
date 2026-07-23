using System;
using System.Collections.Generic;
using System.Text;

public class ItemAction : GameAction
{
    private readonly Item _item;
    private readonly Character _character;
    private readonly Party _party;

    public ItemAction(Item item , Character character, Party party) 
    { 
        _item = item;
        _character = character;
        _party = party;
    }
    public override void Run()
    {
        _item.UseItem(_character);
        _party.Items.Remove(_item);
        Console.WriteLine($"{_character} used {_item.Name} to {_item.GetItemInfo()}");
    }
}