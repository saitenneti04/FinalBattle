public class AttackAction : GameAction
{
    private readonly Character _attacker;
    private readonly Attack _attack;
    private readonly Character _target;
    private readonly Party _enemyParty;

    public AttackAction(Character attacker, Attack attack, Character target, Party enemyParty)
    {
        _attacker = attacker;
        _attack = attack;
        _target = target;
        _enemyParty = enemyParty;
    }

    private void CheckDefeat()
    {
        if (_target.CurrHP == 0) 
        { 
            _enemyParty.RemoveCharacter(_target);
            Console.WriteLine($"{_target.Name} has been defeated!");
        }

    }
    public override void Run()
    {
        Console.WriteLine($"{_attacker.Name} used {_attack.Name} on {_target.Name}."); 
        int damage = _attack.GetDamage();
        _target.ReceiveDamage( damage );
        Console.WriteLine($"{_attack.Name} dealt {damage} damage to {_target.Name}.");
        Console.WriteLine($"{_target.Name} is now at {_target.CurrHP}/{_target.MaxHP} HP.");
        CheckDefeat();
    }
}
