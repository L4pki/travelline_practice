using Fighters.Models.Armors;
using Fighters.Models.Races;
using Fighters.Models.Weapons;

namespace Fighters.Models.Fighters;

public class Fighter : IFighter
{
    public int MaxHealth => Race.Health;
    public int CurrentSpeedScale { get; private set; }
    public int CurrentHealth { get; private set; }
    public int FullSpeedScale { get; }
    private int FullArmor { get; }
    private int FullDexterity { get; }
    private int FullDamage { get; }

    public string Name { get; }

    public IRace Race { get; }
    public IWeapon Weapon { get; }
    public IArmor Armor { get; }
    public bool IsRedTeam { get; set; }

    public Fighter(string name, IRace race, IWeapon weapon, IArmor armor)
    {
        Name = name;
        Race = race;
        Weapon = weapon;
        Armor = armor;
        CurrentHealth = MaxHealth;
        FullSpeedScale = Race.Speed + Weapon.Speed + Armor.Speed;
        FullArmor = Armor.Armor;
        FullDexterity = Race.Dexterity + Armor.Dexterity;
        FullDamage = Race.Damage + Weapon.Damage;
    }

    public bool TimeToAttack()
    {
        CurrentSpeedScale += FullSpeedScale;
        if (CurrentSpeedScale >= 100)
        {
            CurrentSpeedScale -= 100;
            return true;
        }
        return false;
    }
    public bool IsEvasion()
    {
        var rand = new Random();
        int Dexterity = FullDexterity;
        if( Dexterity < 5)
        {
            Dexterity = 5;
        }
        if (Dexterity >= rand.Next(0,100))
        {
            return true;
        }
        return false;
    }
    public bool IsCrit()
    {
        var rand = new Random();
        int CritChance = Weapon.CritChance;
        if (CritChance >= rand.Next(0, 100))
        {
            return true;
        }
        return false;

    }
    public int CalculateDamage(bool IsCrit)
    {
        Random rand = new Random();
        int GodLuck = rand.Next(0, 20);
        int damage = (int)(( FullDamage ) * (1 + (float)GodLuck / 100));
        if (IsCrit)
        {
            return (int)((damage) * (1 + (float)Weapon.CritDamage/100));
        }
        return damage;
    }

    public int TakeDamage(int damage, bool IsEvasion)
    {
        if (!IsEvasion)
        {
            return (int)(damage * CalculateDamageResist());
        }
        return 0;  
    }
    public void SetDamage(int damage, bool IsEvasion)
    {
        if (!IsEvasion)
        {
            CurrentHealth -= (int)(damage * (1 - CalculateDamageResist()));
        }
        if (CurrentHealth < 0)
        {
            CurrentHealth = 0;
        }
    }
    private float CalculateDamageResist()
    {
        if ( FullArmor <= 100 )
        {
            return ( float )FullArmor / 100;
        }
        else
        {
            return 0;
        }

    }
}

