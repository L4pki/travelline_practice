using Fighters.Models.Armors;
using Fighters.Models.Races;
using Fighters.Models.Weapons;
using static System.Net.Mime.MediaTypeNames;

namespace Fighters.Models.Fighters
{
    public class Fighter : IFighter
    {
        public int MaxHealth => Race.Health;
        public int CurrentSpeedScale { get; private set; }
        public int CurrentHealth { get; private set; }

        public string Name { get; }

        public IRace Race { get; }
        public IWeapon Weapon { get; }
        public IArmor Armor { get; }

        public Fighter(string name, IRace race, IWeapon weapon, IArmor armor)
        {
            Name = name;
            Race = race;
            Weapon = weapon;
            Armor = armor;
            CurrentHealth = MaxHealth;
            CurrentSpeedScale = Race.Speed + Weapon.Speed + Armor.Speed;
        }

        public bool TimeToAttack()
        {
            CurrentSpeedScale += Race.Speed;
            if (CurrentSpeedScale >= 100)
            {
                CurrentSpeedScale -= 100;
                return true;
            }
            return false;
        }
        private float CalculateDamageResist() 
        {
            if (Armor.Armor <= 100)
            {
                return (float)Armor.Armor / 100;
            }
            else
            {
                return 1;
            }
            
        }
        public bool IsEvasion()
        {
            var rand = new Random();
            int Dexterity = Race.Dexterity + Armor.Dexterity;
            if (Dexterity >= rand.Next(0,100))
            {
                return true;
            }
            return false;
        }
        public bool IsCrit()
        {
            var rand = new Random();
            int CritChance = Weapon.CritChance;
            if (CritChance >= rand.Next(0, 100))
            {
                return true;
            }
            return false;

        }
        public int CalculateDamage(bool IsCrit)
        {
            if (IsCrit)
            {
                return (int)((Race.Damage + Weapon.Damage) * (1 + (float)Weapon.CritDamage/100));
            }
            return Race.Damage + Weapon.Damage;
        }

        public int TakeDamage(int damage, bool IsEvasion)
        {
            if (!IsEvasion)
            {
                return (int)(damage * CalculateDamageResist());
            }
            return 0;  
        }
        public void SetDamage(int damage, bool IsEvasion)
        {
            if (!IsEvasion)
            {
                CurrentHealth -= (int)(damage * (1 - CalculateDamageResist()));
            }
            if (CurrentHealth < 0)
            {
                CurrentHealth = 0;
            }
        }
    }
}

