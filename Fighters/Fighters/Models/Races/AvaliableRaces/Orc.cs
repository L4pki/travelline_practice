namespace Fighters.Models.Races.AvaliableRaces
{
    public class Orc : IRace
    {
        public int Damage { get; } = 17;
        public int Health { get; } = 65;
        public int Armor { get; } = 5;
        public int Speed { get; } = 50;
        public int Dexterity { get; } = 25;
        public string NameRace { get; } = "Злобный Орк";
        public string AboutRace { get; } = "Яростный и безжалостный берсерк";
    }
}

