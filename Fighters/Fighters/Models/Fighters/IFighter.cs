using Fighters.Models.Armors;
using Fighters.Models.Races;
using Fighters.Models.Weapons;

namespace Fighters.Models.Fighters;

public interface IFighter
{
    public int MaxHealth { get; }
    public int CurrentHealth { get; }
    public int CurrentSpeedScale { get; }
    public int FullSpeedScale { get; }

    public string Name { get; }

    public IWeapon Weapon { get; }
    public IRace Race { get; }
    public IArmor Armor { get; }
    public bool IsRedTeam { get; set; }

    public bool TimeToAttack();
    public bool IsEvasion();
    public bool IsCrit();
    public int TakeDamage(int damage, bool IsEvasion);
    public void SetDamage(int damage, bool IsEvasion);
    public int CalculateDamage(bool IsCrit);
}

