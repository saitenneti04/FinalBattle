using System;
using System.Collections.Generic;
using System.Text;

public class EquipAction : GameAction
{
    private readonly Character _character;
    private readonly Gear _gear;
    private readonly Party _characterParty;

    public EquipAction(Character character,  Gear gear, Party characterParty)
    {
        _character = character;
        _gear = gear;
        _characterParty = characterParty;
    }

    public override void Run()
    {
        Gear characterPrevGear = _character.Gear;
        _characterParty.Gear.Remove(_gear);
        _character.Gear = _gear;
        if (characterPrevGear != null)
        {
            _characterParty.Gear.Add(characterPrevGear);
        }
    }
}