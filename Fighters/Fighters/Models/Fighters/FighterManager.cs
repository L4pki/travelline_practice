namespace Fighters.Models.Fighters;

public class FighterManager
{
    public IFighter[] SortSpeedScaleFighters(IFighter[] team)
    {           
        IFighter[] speedSortTeam = new IFighter[team.Length];
        Array.Copy(team, speedSortTeam, team.Length);
        Array.Sort(speedSortTeam, new FighterSpeedComparer());
        return speedSortTeam;
    }
}

