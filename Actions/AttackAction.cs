using System.Security.Cryptography.X509Certificates;
using static System.Net.Mime.MediaTypeNames;

public class AttackAction : GameAction
{
    private readonly Character _attacker;
    private readonly Attack _attack;
    private readonly Party _attackParty;
    private readonly Character _target;
    private readonly Party _enemyParty;
    private static Random random = new Random();

    public AttackAction(Character attacker, Attack attack, Party attackParty, Character target, Party enemyParty)
    {
        _attacker = attacker;
        _attack = attack;
        _attackParty = attackParty;
        _target = target;
        _enemyParty = enemyParty;
    }

    private void CheckDefeat()
    {
        if (_target.CurrHP == 0) 
        { 
            _enemyParty.RemoveCharacter(_target);
            Console.WriteLine($"{_target.Name} has been defeated!");
            if (_target.Gear != null) 
            {
                Console.WriteLine($"{_attackParty.Name} acquired the defeated character {_target.Name}'s gear: {_target.Gear.Name}! ");
                _attackParty.Gear.Add(_target.Gear);
                _target.Gear = null;
            }
        }

    }
    public override void Run()
    {
        Console.WriteLine($"{_attacker.Name} used {_attack.Name} on {_target.Name}."); 
        int damage = _attack.GetDamage();
        int newDamage = 0;
        bool damageModified = false;
        if (_target.AttackModifier != null)
        {
            newDamage = _target.AttackModifier.GetModifiedDamage(damage);
            damageModified = true;    
        }
        float damageChance = _attack.GetDamageProbability();
        if (damageChance == 1) 
        {
            if (damageModified) 
            { 
                _target.AttackModifier.PrintDamageMessage(damage - newDamage);
                DoRun(newDamage);
            }
            else DoRun(damage);
        }
        else if (damageChance == 0.5) 
        {
            int num = random.Next(2);
            if (num == 1)
            {
                if (damageModified) 
                { 
                    _target.AttackModifier.PrintDamageMessage(damage - newDamage);
                    DoRun(newDamage);
                }
                else DoRun(damage); 
            }
            else { Console.WriteLine($"{_attacker.Name} MISSED!"); }
        }
        else
        {
            Console.WriteLine($"{_attacker.Name} MISSED!");
        }
    }

    public void DoRun(int damage)
    {
        _target.ReceiveDamage(damage);
        Console.WriteLine($"{_attack.Name} dealt {damage} damage to {_target.Name}.");
        Console.WriteLine($"{_target.Name} is now at {_target.CurrHP}/{_target.MaxHP} HP.");
        CheckDefeat();
    }
}
