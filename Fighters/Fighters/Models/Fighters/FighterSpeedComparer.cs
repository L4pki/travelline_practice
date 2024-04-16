namespace Fighters.Models.Fighters;

public class FighterSpeedComparer : IComparer<IFighter>
{
    public int Compare( IFighter x, IFighter y ) => x.FullSpeedScale.CompareTo( y.FullSpeedScale );
}

