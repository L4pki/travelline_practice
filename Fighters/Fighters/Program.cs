using Fighters.Models.Fighters;
using Fighters.UI.InputUI;
using Fighters.UI.OutputUI;


namespace Fighters;

public class Program
{
    private static readonly IUIInput _uiInput = new UIInput();
    private static readonly IUIOutput _uiOutput = new UIOutput();
    public static void Main()
    {
        bool IsCountineGame = true;
        string StrSelectMode = _uiOutput.SelectBattleMode();
        var master = new GameMaster( _uiOutput );
        while ( IsCountineGame )
        {
            if ( StrSelectMode == "1" )
            {
                Fighter firstFighter = _uiInput.ChooseFighter();
                Fighter secondFighter = _uiInput.ChooseFighter();
                _uiOutput.AboutFighter( firstFighter );
                _uiOutput.AboutFighter( secondFighter );
                var winner = master.PlayAndGetWinnerWithTwoChampions( firstFighter, secondFighter );
                _uiOutput.FightLog();
                _uiOutput.WriteWinner( winner );
                IsCountineGame = _uiOutput.IsRestartingGame();
            }
            else
            {
                int[] NumberFighters = _uiInput.SelectNumberFighters();
                IFighter[] RedTeam = _uiInput.ChooseTeam( NumberFighters[ 0 ], true, "Red" );
                IFighter[] BlueTeam = _uiInput.ChooseTeam( NumberFighters[ 1 ], false, "Blue" );
                IFighter[] AllFighters = BlueTeam.Concat( RedTeam ).ToArray();
                var WinnerTeam = master.PlayAndGetWinnerTeam( AllFighters, BlueTeam, RedTeam );
                if ( WinnerTeam == BlueTeam )
                {
                    _uiOutput.WriteWinnerTeam( WinnerTeam, "Blue" );
                }
                else
                {
                    _uiOutput.WriteWinnerTeam( WinnerTeam, "Red" );
                }
                _uiOutput.IsCheckLog();
                IsCountineGame = _uiOutput.IsRestartingGame();
            }
        }
    }
}

