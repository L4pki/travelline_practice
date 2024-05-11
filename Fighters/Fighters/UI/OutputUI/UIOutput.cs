using Fighters.Models.Fighters;

namespace Fighters.UI.OutputUI;

public class UIOutput : IUIOutput
{
    public void WriteLine( string text, string color )
    {
        ConsoleColor colorValue;
        if ( !Enum.TryParse( color, true, out colorValue ) )
            throw new ArgumentException( $"Invalid color value: {color}" );
        Console.ForegroundColor = colorValue;
        Console.WriteLine( text );
        Console.ForegroundColor = ConsoleColor.White;
    }
    public void Write( string text, string color )
    {
        ConsoleColor colorValue;
        if ( !Enum.TryParse( color, true, out colorValue ) )
            throw new ArgumentException( $"Invalid color value: {color}" );
        Console.ForegroundColor = colorValue;
        Console.Write( text );
        Console.ForegroundColor = ConsoleColor.White;
    }
    public void WriteFightLog( bool isEvasion, bool isCrit,
        IFighter fighter, int damage, int resist )
    {
        FileLogger fileWriter = new FileLogger( "Log.txt" );
        if ( isEvasion )
        {
            fileWriter.WriteTextToFile( $"Соперник {fighter.Name} уклонился" );
            fileWriter.WriteTextToFile( "DarkCyan" );
        }
        else
        {
            if ( isCrit )
            {
                fileWriter.WriteTextToFile( $"Прошел Крит.удар по {fighter.Name}" );
                fileWriter.WriteTextToFile( "DarkRed" );
            }
            fileWriter.WriteTextToFile( $"Боец {fighter.Name} получает {damage} урона. " );
            fileWriter.WriteTextToFile( "White" );
            fileWriter.WriteTextToFile( $"(поглощено {resist}) " );
            fileWriter.WriteTextToFile( "Blue" );
        }
        fileWriter.WriteTextToFile( $"Количество жизней {fighter.Name}: {fighter.CurrentHealth}" );
        fileWriter.WriteTextToFile( "White" );
        fileWriter.WriteTextToFile( "---------------------------------" );
        fileWriter.WriteTextToFile( "DarkGreen" );
    }
    public void WriteWinner( IFighter winner )
    {
        var uiOutput = new UIOutput();
        uiOutput.WriteLine( $"Выигрывает  {winner.Name}", "DarkYellow" );
    }
    public void AboutFighter( IFighter fighter )
    {
        UIOutput uiOutput = new UIOutput();
        uiOutput.WriteLine( $"{fighter.Name} - {fighter.Race.NameRace}, " +
            $"{fighter.Race.AboutRace}.\nСейчас вступит в битву c " +
            $"{fighter.Weapon.About}, в {fighter.Armor.About}\n", "DarkMagenta" );
    }
    public void FighterCard( IFighter fighter, string color )
    {
        string block = '\u2588'.ToString();
        string currentHealthBlock = "";
        string currentHealth;
        float fNumBlock;
        int numBlock;
        if ( fighter.CurrentHealth != fighter.MaxHealth )
        {
            fNumBlock = ( float )( fighter.CurrentHealth /
                ( fighter.MaxHealth / 10f ) );
            numBlock = ( int )fNumBlock + 1;
        }
        else
        {
            numBlock = 10;
        }
        string name = fighter.Name;
        string armor = fighter.Armor.Name;
        string weapon = fighter.Weapon.Name;
        UIOutput uiOutput = new UIOutput();
        uiOutput.WriteLine( "____________", color );
        uiOutput.Write( "|", color );
        while ( name.Length != 10 )
        {
            name += " ";
            if ( name.Length != 10 )
            {
                name = " " + name;
            }
        }
        uiOutput.Write( name, "DarkMagenta" );
        uiOutput.WriteLine( "|", color );
        uiOutput.WriteLine( "|----------|", color );
        uiOutput.Write( "|", color );
        uiOutput.Write( "  Health  ", "Green" );
        uiOutput.WriteLine( "|", color );
        uiOutput.Write( "|", color );
        while ( currentHealthBlock.Length != numBlock )
        {
            currentHealthBlock += block;
        }
        currentHealth = currentHealthBlock;
        while ( currentHealth.Length != 10 )
        {
            currentHealth += " ";
        }
        uiOutput.Write( currentHealth, "Green" );
        uiOutput.WriteLine( "|", color );
        uiOutput.WriteLine( "|----------|", color );
        uiOutput.Write( "|", color );
        uiOutput.Write( "  Armor   ", "Gray" );
        uiOutput.WriteLine( "|", color );
        uiOutput.Write( "|", color );
        while ( armor.Length != 10 )
        {
            armor += " ";
            if ( armor.Length != 10 )
            {
                armor = " " + armor;
            }
        }
        uiOutput.Write( armor, "Gray" );
        uiOutput.WriteLine( "|", color );
        uiOutput.WriteLine( "|----------|", color );
        uiOutput.Write( "|", color );
        uiOutput.Write( "  Weapon  ", "Gray" );
        uiOutput.WriteLine( "|", color );
        uiOutput.Write( "|", color );
        while ( weapon.Length != 10 )
        {
            weapon += " ";
            if ( weapon.Length != 10 )
            {
                weapon = " " + weapon;
            }
        }
        uiOutput.Write( weapon, "Gray" );
        uiOutput.WriteLine( "|", color );
        uiOutput.WriteLine( "------------", color );
    }
    public string SelectBattleMode()
    {
        while ( true )
        {
            Console.WriteLine( "Выберите режим боя: \n(1)Автодуэль\n(2)Командный бой" );
            string strSelectMode = Console.ReadLine();
            if ( strSelectMode != "1" && strSelectMode != "2" )
            {
                Console.WriteLine( "Проверьте правильность введеных данных" );
            }
            else
            {
                return strSelectMode;
            }
        }
    }
    public int ChooseTarget()
    {
        while ( true )
        {
            try
            {
                Console.WriteLine( "Выберите номер цели" );
                ;
                return ( int.Parse( Console.ReadLine() ) - 1 );
            }
            catch
            {
                Console.WriteLine( "Неккоректные данные" );
            }
        }
    }
    public void WriteWinnerTeam( IFighter[] winnerTeam, string color )
    {
        UIOutput uiOutput = new UIOutput();
        uiOutput.WriteLine( $"Команда {color} одержала верх", color );
        for ( int i = 0; i < winnerTeam.Length; i++ )
        {
            uiOutput.FighterCard( winnerTeam[ i ], "Yellow" );
        }
    }
    public void FightLog()
    {
        var uiOutput = new UIOutput();
        FileLogger fileWriter = new FileLogger( "Log.txt" );
        string[] lines = fileWriter.ReadTextInFile();
        while ( lines.Length > 0 )
        {
            string text = lines[ 0 ];
            string color = lines[ 1 ];
            uiOutput.WriteLine( text, color );
            lines = lines.Skip( 2 ).ToArray();
        }
        fileWriter.ClearFile( "Log.txt" );
    }
    public bool IsRestartingGame()
    {
        bool isCountineGame = true;
        Console.WriteLine( "Хотите продолжить игру? yes/no" );
        if ( Console.ReadLine() != "yes" )
        {
            isCountineGame = false;
        }
        Console.Clear();
        return isCountineGame;
    }
    public void IsCheckLog()
    {
        var uiOutput = new UIOutput();
        Console.WriteLine( "Хотите посмотреть логи битвы? yes/no" );
        if ( Console.ReadLine() == "yes" )
        {
            uiOutput.FightLog();
        }
    }
}

