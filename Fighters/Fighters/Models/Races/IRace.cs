namespace Fighters.Models.Races;

public interface IRace
{
    int Damage { get; }
    int Health { get; }
    int Armor { get; }
    int Speed { get; }
    int Dexterity { get; }
    string NameRace { get; }
    string AboutRace { get; }
}

