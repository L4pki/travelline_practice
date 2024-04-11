namespace Fighters.Models.Weapons
{
    public interface IWeapon
    {
        int Damage { get; }
        int Speed { get; }
        int CritChance { get; }
        int CritDamage { get; }
        string About { get; }
        string Name { get; }
    }
}

