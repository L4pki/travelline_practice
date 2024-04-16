namespace Fighters.Models.Armors.AvaliableArmor;

public class HeavyArmor : IArmor
{
    public int Armor { get; } = 75; 
    public int Speed { get; } = -20; 
    public int Dexterity { get; } = -40;
    public string About { get; } = "тяжёлых доспехах";
    public string Name { get; } = "Heavy";
}

