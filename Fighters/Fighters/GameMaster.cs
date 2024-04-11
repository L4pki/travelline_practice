using Fighters.Models.Fighters;
using Fighters.UI.OutputUI;
using System.Collections.Immutable;
using System.ComponentModel;
using System.Diagnostics;


namespace Fighters
{
    public class GameMaster
    {
        public IFighter[] PlayAndGetWinnerTeam(IFighter[] AllFighters, IFighter[] BlueTeam, IFighter[] RedTeam)
        {
            UIOutput UIO = new UIOutput();
            FighterManager TeamManager = new FighterManager();
            IFighter[] SpeedSortTeam = TeamManager.SortSpeedScaleFighters(AllFighters);
            IFighter[] RedTeamCurrentLive = RedTeam;
            IFighter[] BlueTeamCurrentLive = BlueTeam;
            while (true)
            {
                for (int i = 0; i < SpeedSortTeam.Length; i++)
                {
                    if (SpeedSortTeam[i].TimeToAttack())
                    {
                        if (SpeedSortTeam[i].IsRedTeam)
                        {
                            Console.Clear();
                            UIO.FighterCard(SpeedSortTeam[i],"Red");
                            for (int j = 0; j < BlueTeamCurrentLive.Length; j++)
                            {
                                UIO.FighterCard(BlueTeamCurrentLive[j], "Blue");
                            }
                            int NumOpponent = UIO.ChooseTarget();
                            bool IsDead = FightAndCheckIfOpponentDead(SpeedSortTeam[i], BlueTeamCurrentLive[NumOpponent]);
                            if (IsDead)
                            {
                                BlueTeamCurrentLive = BlueTeamCurrentLive.Where
                                    (val => val != BlueTeamCurrentLive[NumOpponent]).ToArray();
                                if(BlueTeamCurrentLive.Length == 0)
                                {
                                    return RedTeam;
                                }
                                SpeedSortTeam = BlueTeamCurrentLive.Concat(RedTeamCurrentLive).ToArray();
                                SpeedSortTeam = TeamManager.SortSpeedScaleFighters(AllFighters);
                            }
                        }
                        else
                        {
                            Console.Clear();
                            //ii make 
                            UIO.FighterCard(SpeedSortTeam[i], "Blue");
                            for (int j = 0; j < RedTeamCurrentLive.Length; j++)
                            {
                                UIO.FighterCard(RedTeamCurrentLive[j], "Red");
                            }
                            int NumOpponent = UIO.ChooseTarget();
                            bool IsDead = FightAndCheckIfOpponentDead(SpeedSortTeam[i], RedTeamCurrentLive[NumOpponent]);
                            if (IsDead)
                            {
                                RedTeamCurrentLive = RedTeamCurrentLive.Where
                                    (val => val != RedTeamCurrentLive[NumOpponent]).ToArray();
                                if (RedTeamCurrentLive.Length == 0)
                                {
                                    return BlueTeam;
                                }
                                SpeedSortTeam = RedTeamCurrentLive.Concat(BlueTeamCurrentLive).ToArray();
                                SpeedSortTeam = TeamManager.SortSpeedScaleFighters(AllFighters);
                            }
                        }
                    }
                }
            } 
        }
        public IFighter PlayAndGetWinnerWithTwoChampions(IFighter firstFighter, IFighter secondFighter)
        {
            while (true)
            {
                // First fights second
                if (firstFighter.TimeToAttack()) 
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
            var UIO = new UIOutput();
            bool IsEvasion = opponent.IsEvasion();
            bool IsCrit = roundOwner.IsCrit();
            int damage = roundOwner.CalculateDamage(IsCrit);
            int resist = opponent.TakeDamage(damage, IsEvasion);
            opponent.SetDamage(damage, IsEvasion);
            UIO.WriteFightLog(IsEvasion, IsCrit, opponent, damage, resist);
            return opponent.CurrentHealth < 1;
        }
    }
}

