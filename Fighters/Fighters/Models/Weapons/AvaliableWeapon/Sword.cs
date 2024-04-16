namespace Fighters.Models.Weapons.AvaliableWeapon;

public class Sword : IWeapon
{
    public int Damage { get; } = 20;
    public int Speed { get; } = 10;
    public int CritChance { get; } = 30;
    public int CritDamage { get; } = 35;
    public string About { get; } = "блескающим на солнце мечом";
    public string Name { get; } = "Sword";
}

