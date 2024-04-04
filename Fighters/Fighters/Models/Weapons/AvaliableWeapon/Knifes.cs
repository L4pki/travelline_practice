﻿namespace Fighters.Models.Weapons.AvaliableWeapon
{
    public class Knifes : IWeapon
    {
        public int Damage { get; } = 12;
        public int Speed { get; } = 14; 
        public int CritChance { get; } = 39;
        public int CritDamage { get; } = 35;
    }
}

