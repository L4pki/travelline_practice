using Fighters.Models.Fighters;
using Fighters.UI.InputUI;
using Fighters.UI.OutputUI;
using System.Collections.Generic;
using System.Drawing;
using System.IO;


namespace Fighters
{
    public class Program
    {
        public static void Main()
        {
            var UII = new UIInput();
            var UIO = new UIOutput();
            bool IsCountineGame = true;
            string StrSelectMode =  UIO.SelectBattleMode();
            while (IsCountineGame)
            {
                if (StrSelectMode == "1")
                {
                    Fighter firstFighter = UII.ChooseFighter();
                    Fighter secondFighter = UII.ChooseFighter();
                    UIO.AboutFighter(firstFighter);
                    UIO.AboutFighter(secondFighter);
                    var master = new GameMaster();
                    var winner = master.PlayAndGetWinnerWithTwoChampions(firstFighter, secondFighter);
                    UIO.FightLog();
                    UIO.WriteWinner(winner);
                    IsCountineGame = UIO.IsRestartingGame();
                }
                else
                {
                    int[] NumberFighters = UII.SelectNumberFighters();
                    IFighter[] RedTeam = UII.ChooseTeam(NumberFighters[0], true,"Red");
                    IFighter[] BlueTeam = UII.ChooseTeam(NumberFighters[1], false, "Blue");
                    IFighter[] AllFighters = BlueTeam.Concat(RedTeam).ToArray();
                    var master = new GameMaster();
                    var WinnerTeam = master.PlayAndGetWinnerTeam(AllFighters, BlueTeam, RedTeam);
                    if(WinnerTeam == BlueTeam)
                    {
                        UIO.WriteWinnerTeam(WinnerTeam,"Blue");
                    }
                    else
                    {
                        UIO.WriteWinnerTeam(WinnerTeam, "Red");
                    }
                    UIO.IsCheckLog();
                    IsCountineGame = UIO.IsRestartingGame();
                }
            }  
        }
    }
}

