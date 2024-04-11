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
        public int SpeedScale { get; }

        public string Name { get; }

        public IRace Race { get; }
        public IWeapon Weapon { get; }
        public IArmor Armor { get; }
        public bool IsRedTeam { get; set; }

        public Fighter(string name, IRace race, IWeapon weapon, IArmor armor)
        {
            Name = name;
            Race = race;
            Weapon = weapon;
            Armor = armor;
            CurrentHealth = MaxHealth;
            SpeedScale = Race.Speed + Weapon.Speed + Armor.Speed;
        }

        public bool TimeToAttack()
        {
            CurrentSpeedScale += SpeedScale;
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
            Random rand = new Random();
            int GodLuck = rand.Next(0, 20);
            int damage = (int)((Race.Damage + Weapon.Damage) * (1 + (float)GodLuck / 100));
            if (IsCrit)
            {
                return (int)((damage) * (1 + (float)Weapon.CritDamage/100));
            }
            return damage;
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
    public class FighterSpeedComparer : IComparer<IFighter>
    {
        public int Compare(IFighter x, IFighter y)
        {
            return x.SpeedScale.CompareTo(y.SpeedScale);
        }
    }
    public class FighterManager
    {
        public IFighter[] SortSpeedScaleFighters(IFighter[] Team)
        {           
            IFighter[] SpeedSortTeam = new IFighter[Team.Length];
            Array.Copy(Team, SpeedSortTeam, Team.Length);
            Array.Sort(SpeedSortTeam, new FighterSpeedComparer());
            return SpeedSortTeam;
        }
    }
}

