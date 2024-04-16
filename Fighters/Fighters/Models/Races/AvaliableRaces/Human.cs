namespace Fighters.Models.Races.AvaliableRaces;

public class Human : IRace
{
    public int Damage { get; } = 11;
    public int Health { get; } = 100;
    public int Armor { get; } = 10;
    public int Speed { get; } = 37;
    public int Dexterity { get; } = 35;
    public string NameRace { get; } = "Человек";
    public string AboutRace { get; } = "До начала великой войны, был обычным крестьянином";
}

