namespace Fighters.Models.Armors;

public interface IArmor
{
    int Armor { get; }
    int Speed { get; }
    int Dexterity { get; }
    string About { get; }
    string Name { get; }
}

