namespace Fighters.Models.Weapons.AvaliableWeapon
{
    public class Axes : IWeapon
    {
        public int Damage { get; } = 26;
        public int Speed { get; } = 9;
        public int CritChance { get; } = 19;
        public int CritDamage { get; } = 75;
    }
}

