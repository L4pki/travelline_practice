using Fighters.Models.Fighters;
using Fighters.UI.InputUI;
using Fighters.UI.OutputUI;
using System.Diagnostics;


namespace Fighters
{
    public class Program
    {
        public static void Main()
        {
            var UII = new UIInput();
            var UIO = new UIOutput();
            Fighter firstFighter = UII.ChooseFighter();
            Fighter secondFighter = UII.ChooseFighter();
            UII.AboutFighter(firstFighter);
            UII.AboutFighter(secondFighter);

            var master = new GameMaster();
            var winner = master.PlayAndGetWinner(firstFighter, secondFighter);
            UIO.WriteLine($"Выигрывает  {winner.Name}","DarkYellow");
        }
    }

    public class GameMaster
    {
        public IFighter PlayAndGetWinner(IFighter firstFighter, IFighter secondFighter)
        {
            while (true)
            {
                // First fights second
                if(firstFighter.TimeToAttack()) 
                {
                    if (FightAndCheckIfOpponentDead(firstFighter, secondFighter))
                    {
                        return firstFighter;
                    }
                }

                // Second fights first
                if (secondFighter.TimeToAttack())
                {
                    if (FightAndCheckIfOpponentDead(secondFighter, firstFighter))
                    {
                        return secondFighter;
                    }
                }
            }

            throw new UnreachableException();
        }

        private bool FightAndCheckIfOpponentDead(IFighter roundOwner, IFighter opponent)
        {
            bool IsEvasion = opponent.IsEvasion();
            bool IsCrit = roundOwner.IsCrit();
            var UIO = new UIOutput();
            int damage = roundOwner.CalculateDamage(IsCrit);
            int resist = opponent.TakeDamage(damage, IsEvasion);
            opponent.SetDamage(damage, IsEvasion);
            if (IsEvasion)
            {
                UIO.WriteLine($"Соперник {opponent.Name} уклонился", "DarkCyan");
            }
            else
            {
                if (IsCrit)
                {
                    UIO.WriteLine($"Прошел Крит.удар по {opponent.Name}", "DarkRed");
                }
                Console.Write($"Боец {opponent.Name} получает {damage} урона. ");
                UIO.Write($"(поглощено {resist}) ", "Blue");
            }
            Console.Write($"Количество жизней {opponent.Name}: {opponent.CurrentHealth}");
            Console.WriteLine();
            return opponent.CurrentHealth < 1;
        }
    }
}

