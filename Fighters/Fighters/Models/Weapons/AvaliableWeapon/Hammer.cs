namespace Fighters.Models.Weapons.AvaliableWeapon;

public class Hammer : IWeapon
{
    public int Damage { get; } = 30;
    public int Speed { get; } = 7; 
    public int CritChance { get; } = 20;
    public int CritDamage { get; } = 70;
    public string About { get; } = "сокрушительным молотом";
    public string Name { get; } = "Hummer";
}

