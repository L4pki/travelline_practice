namespace Fighters.Models.Races.AvaliableRaces;

public class Dworf : IRace
{
    public int Damage { get; } = 7;
    public int Health { get; } = 120;
    public int Armor { get; } = 15;
    public int Speed { get; } = 24;
    public int Dexterity { get; } = 10;
    public string NameRace { get; } = "Скряга Гном";
    public string AboutRace { get; } = "Нелюдимый персонаж, мы мало чего знаем о нем,\n его оружие более красноречиво";
}

