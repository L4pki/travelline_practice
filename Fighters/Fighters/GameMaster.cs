using Fighters.Models.Fighters;
using Fighters.UI.OutputUI;
using System.Diagnostics;


namespace Fighters;

public class GameMaster
{

    private readonly IUIOutput _uiOutput;

    public GameMaster( IUIOutput uiOutput )
    {
        _uiOutput = uiOutput;
    }
    public IFighter[] PlayAndGetWinnerTeam( IFighter[] allFighters, IFighter[] blueTeam, IFighter[] redTeam )
    {
        FighterManager TeamManager = new FighterManager();
        IFighter[] SpeedSortTeam = TeamManager.SortSpeedScaleFighters( allFighters );
        IFighter[] RedTeamCurrentLive = redTeam;
        IFighter[] BlueTeamCurrentLive = blueTeam;
        while ( true )
        {
            for ( int i = 0; i < SpeedSortTeam.Length; i++ )
            {
                if ( SpeedSortTeam[ i ].TimeToAttack() )
                {
                    if ( SpeedSortTeam[ i ].IsRedTeam )
                    {
                        Console.Clear();
                        _uiOutput.FighterCard( SpeedSortTeam[ i ], "Red" );
                        for ( int j = 0; j < BlueTeamCurrentLive.Length; j++ )
                        {
                            _uiOutput.FighterCard( BlueTeamCurrentLive[ j ], "Blue" );
                        }
                        int NumOpponent = _uiOutput.ChooseTarget();
                        bool IsDead = FightAndCheckIfOpponentDead( SpeedSortTeam[ i ], BlueTeamCurrentLive[ NumOpponent ] );
                        if ( IsDead )
                        {
                            BlueTeamCurrentLive = BlueTeamCurrentLive.Where
                                ( val => val != BlueTeamCurrentLive[ NumOpponent ] ).ToArray();
                            if ( BlueTeamCurrentLive.Length == 0 )
                            {
                                return redTeam;
                            }
                            SpeedSortTeam = TeamManager.SortSpeedScaleFighters( allFighters );
                        }
                    }
                    else
                    {
                        Console.Clear();
                        //ii make 
                        _uiOutput.FighterCard( SpeedSortTeam[ i ], "Blue" );
                        for ( int j = 0; j < RedTeamCurrentLive.Length; j++ )
                        {
                            _uiOutput.FighterCard( RedTeamCurrentLive[ j ], "Red" );
                        }
                        int NumOpponent = _uiOutput.ChooseTarget();
                        bool IsDead = FightAndCheckIfOpponentDead( SpeedSortTeam[ i ], RedTeamCurrentLive[ NumOpponent ] );
                        if ( IsDead )
                        {
                            RedTeamCurrentLive = RedTeamCurrentLive.Where
                                ( val => val != RedTeamCurrentLive[ NumOpponent ] ).ToArray();
                            if ( RedTeamCurrentLive.Length == 0 )
                            {
                                return blueTeam;
                            }
                            SpeedSortTeam = RedTeamCurrentLive.Concat( BlueTeamCurrentLive ).ToArray();
                            SpeedSortTeam = TeamManager.SortSpeedScaleFighters( allFighters );
                        }
                    }
                }
            }
        }
    }
    public IFighter PlayAndGetWinnerWithTwoChampions( IFighter firstFighter, IFighter secondFighter )
    {
        while ( true )
        {
            // First fights second
            if ( firstFighter.TimeToAttack() )
            {
                if ( FightAndCheckIfOpponentDead( firstFighter, secondFighter ) )
                {
                    return firstFighter;
                }
            }

            // Second fights first
            if ( secondFighter.TimeToAttack() )
            {
                if ( FightAndCheckIfOpponentDead( secondFighter, firstFighter ) )
                {
                    return secondFighter;
                }
            }
        }
        throw new UnreachableException();
    }

    private bool FightAndCheckIfOpponentDead( IFighter roundOwner, IFighter opponent )
    {
        bool IsEvasion = opponent.IsEvasion();
        bool IsCrit = roundOwner.IsCrit();
        int damage = roundOwner.CalculateDamage( IsCrit );
        int resist = opponent.TakeDamage( damage, IsEvasion );
        opponent.SetDamage( damage, IsEvasion );
        _uiOutput.WriteFightLog( IsEvasion, IsCrit, opponent, damage, resist );
        return opponent.CurrentHealth < 1;
    }
}

