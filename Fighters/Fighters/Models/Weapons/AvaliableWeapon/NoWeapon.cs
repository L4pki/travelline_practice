namespace Fighters.Models.Weapons.AvaliableWeapon
{
    public class NoWeapon : IWeapon
    {
        public int Damage { get; } = 5;
        public int Speed { get; } = 20;
        public int CritChance { get; } = 50;
        public int CritDamage { get; } = 15;
    }
}

