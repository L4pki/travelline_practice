using Fighters.Models.Fighters;

namespace Fighters.UI.OutputUI;

public interface IUIOutput
{
    public void WriteLine( string text, string color );
    public void Write( string text, string color );
    public void WriteFightLog( bool isEvasion, bool isCrit,
        IFighter fighter, int damage, int resist );
    public void WriteWinner( IFighter winner );
    public void AboutFighter( IFighter fighter );
    public void FighterCard( IFighter fighter, string color );
    public string SelectBattleMode();
    public int ChooseTarget();
    public void WriteWinnerTeam( IFighter[] winnerTeam, string color );
    public void FightLog();
    public bool IsRestartingGame();
    public void IsCheckLog();
}

