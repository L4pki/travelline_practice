namespace Fighters.Models.Armors.AvaliableArmor
{
    public class NoArmor : IArmor
    {
        public int Armor { get; } = 0;
        public int Speed { get; } = 15;
        public int Dexterity { get; } = 35;
    }
}

