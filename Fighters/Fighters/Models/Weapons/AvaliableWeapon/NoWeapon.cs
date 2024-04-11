namespace Fighters.Models.Weapons.AvaliableWeapon
{
    public class NoWeapon : IWeapon
    {
        public int Damage { get; } = 5;
        public int Speed { get; } = 20;
        public int CritChance { get; } = 50;
        public int CritDamage { get; } = 15;
        public string About { get; } = "кулаками готовыми к битве"; 
        public string Name { get; } = "None";
    }
}

