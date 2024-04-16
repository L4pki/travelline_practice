namespace Fighters.Models.Races.AvaliableRaces;

public class Elf : IRace
{
    public int Damage { get; } = 13;
    public int Health { get; } = 80;
    public int Armor { get; } = 9;
    public int Speed { get; } = 45;
    public int Dexterity { get; } = 50;
    public string NameRace { get; } = "Прекрасная Эльфа";
    public string AboutRace { get; } = "Желает вернуть своему дому Лазурного листа былое величие";

}

