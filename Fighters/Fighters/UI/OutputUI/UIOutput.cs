using Fighters.Models.Fighters;
using System.IO;
using System.Reflection;

namespace Fighters.UI.OutputUI
{
    public class UIOutput : IUIOutput
    {
        public void WriteLine(string text, string color)
        {
            ConsoleColor colorValue;
            if (!Enum.TryParse(color, true, out colorValue))
                throw new ArgumentException($"Invalid color value: {color}");
            Console.ForegroundColor = colorValue;
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void Write(string text, string color)
        {
            ConsoleColor colorValue;
            if (!Enum.TryParse(color, true, out colorValue))
                throw new ArgumentException($"Invalid color value: {color}");
            Console.ForegroundColor = colorValue;
            Console.Write(text);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void WriteFightLog(bool IsEvasion, bool IsCrit,
            IFighter fighter, int damage, int resist)
        {
            FightLog fileWriter = new FightLog("Log.txt");
            if (IsEvasion)
            {
                fileWriter.WriteTextToFile($"Соперник {fighter.Name} уклонился");
                fileWriter.WriteTextToFile("DarkCyan");
            }
            else
            {
                if (IsCrit)
                {
                    fileWriter.WriteTextToFile($"Прошел Крит.удар по {fighter.Name}");
                    fileWriter.WriteTextToFile("DarkRed");
                }
                fileWriter.WriteTextToFile($"Боец {fighter.Name} получает {damage} урона. ");
                fileWriter.WriteTextToFile("White");
                fileWriter.WriteTextToFile($"(поглощено {resist}) ");
                fileWriter.WriteTextToFile("Blue");
            }
            fileWriter.WriteTextToFile($"Количество жизней {fighter.Name}: {fighter.CurrentHealth}");
            fileWriter.WriteTextToFile("White");
            fileWriter.WriteTextToFile("---------------------------------");
            fileWriter.WriteTextToFile("DarkGreen");
        }
        public void WriteWinner(IFighter winner)
        {
            var UIO = new UIOutput();
            UIO.WriteLine($"Выигрывает  {winner.Name}", "DarkYellow");
        }
        public void AboutFighter(IFighter Fighter)
        {
            UIOutput UIO = new UIOutput();
            UIO.WriteLine($"{Fighter.Name} - {Fighter.Race.NameRace}, " +
                $"{Fighter.Race.AboutRace}.\nСейчас вступит в битву c " +
                $"{Fighter.Weapon.About}, в {Fighter.Armor.About}\n", "DarkMagenta");
        }
        public void FighterCard(IFighter Fighter, string color)
        {
            string Block = '\u2588'.ToString();
            string CurrentHealthBlock = "";
            string CurrentHealth;
            float FNumBlock;
            int NumBlock;
            if (Fighter.CurrentHealth != Fighter.MaxHealth)
            {
                FNumBlock = (float)(Fighter.CurrentHealth /
                    (Fighter.MaxHealth / 10f));
                NumBlock = (int)FNumBlock+1;
            }
            else
            {
                NumBlock = 10;
            }
            string Name = Fighter.Name;
            string Armor = Fighter.Armor.Name;
            string Weapon = Fighter.Weapon.Name;
            UIOutput UIO = new UIOutput();
            UIO.WriteLine("____________", color);
            UIO.Write("|", color);
            while(Name.Length != 10)
            {
                Name += " ";
                if(Name.Length != 10)
                {
                    Name = " " + Name;
                }
            }
            UIO.Write(Name, "DarkMagenta");
            UIO.WriteLine("|", color);
            UIO.WriteLine("|----------|", color);
            UIO.Write("|", color);
            UIO.Write("  Health  ", "Green");
            UIO.WriteLine("|", color);
            UIO.Write("|", color);
            while (CurrentHealthBlock.Length != NumBlock)
            {
                CurrentHealthBlock += Block;
            }
            CurrentHealth = CurrentHealthBlock;
            while (CurrentHealth.Length != 10)
            {
                CurrentHealth += " ";
            }
            UIO.Write(CurrentHealth, "Green");
            UIO.WriteLine("|", color);
            UIO.WriteLine("|----------|", color);
            UIO.Write("|", color);
            UIO.Write("  Armor   ", "Gray");
            UIO.WriteLine("|", color);
            UIO.Write("|", color);
            while (Armor.Length != 10)
            {
                Armor += " ";
                if (Armor.Length != 10)
                {
                    Armor = " " + Armor;
                }
            }
            UIO.Write(Armor, "Gray");
            UIO.WriteLine("|", color);
            UIO.WriteLine("|----------|", color);
            UIO.Write("|", color);
            UIO.Write("  Weapon  ", "Gray");
            UIO.WriteLine("|", color);
            UIO.Write("|", color);
            while (Weapon.Length != 10)
            {
                Weapon += " ";
                if (Weapon.Length != 10)
                {
                    Weapon = " " + Weapon;
                }
            }
            UIO.Write(Weapon, "Gray");
            UIO.WriteLine("|", color);
            UIO.WriteLine("------------", color);
        }
        public string SelectBattleMode()
        {
            while (true)
            {
                Console.WriteLine("Выберите режим боя: \n(1)Автодуэль\n(2)Командный бой");
                string StrSelectMode = Console.ReadLine();
                if (StrSelectMode != "1" && StrSelectMode != "2")
                {
                    Console.WriteLine("Проверьте правильность введеных данных");
                }
                else
                {
                    return StrSelectMode;
                }
            }
        }
        public int ChooseTarget()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Выберите номер цели");;
                    return (int.Parse(Console.ReadLine()) - 1);
                }
                catch
                {
                    Console.WriteLine("Неккоректные данные");
                }
            }
        }
        public void WriteWinnerTeam(IFighter[] WinnerTeam,string Color)
        {
            UIOutput UIO = new UIOutput();
            UIO.WriteLine($"Команда {Color} одержала верх", Color);
            for (int i = 0; i < WinnerTeam.Length; i++)
            {    
                UIO.FighterCard(WinnerTeam[i], "Yellow");
            }
        }
        public void FightLog()
        {
            var UIO = new UIOutput();
            FightLog fileWriter = new FightLog("Log.txt");
            string[] lines = fileWriter.ReadTextInFile();
            while (lines.Length > 0)
            {
                string text = lines[0];
                string color = lines[1];
                UIO.WriteLine(text, color);
                lines = lines.Skip(2).ToArray();
            }
            fileWriter.ClearFile("Log.txt");
        }
        public bool IsRestartingGame()
        {
            bool IsCountineGame = true;
            Console.WriteLine("Хотите продолжить игру? yes/no");
            if (Console.ReadLine() != "yes")
            {
                IsCountineGame = false;
            }
            Console.Clear();
            return IsCountineGame;
        }
        public void IsCheckLog()
        {
            var UIO = new UIOutput();
            Console.WriteLine("Хотите посмотреть логи битвы? yes/no");
            if (Console.ReadLine() == "yes")
            {
                UIO.FightLog();
            }
        }
    }
}

