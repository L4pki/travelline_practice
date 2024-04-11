namespace Fighters.Models.Weapons.AvaliableWeapon
{
    public class Bow : IWeapon
    {
        public int Damage { get; } = 20;
        public int Speed { get; } = 10;
        public int CritChance { get; } = 40; 
        public int CritDamage { get; } = 60;
        public string About { get; } = "разящим в цель луком";
        public string Name { get; } = "Bow";
    }
}

