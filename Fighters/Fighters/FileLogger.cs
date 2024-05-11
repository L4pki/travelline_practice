namespace Fighters;

public class FileLogger
{
    private string filePath;

    public FileLogger( string filePath )
    {
        this.filePath = filePath;
    }

    public void WriteTextToFile( string text )
    {
        try
        {
            using ( StreamWriter writer = new StreamWriter( filePath, true ) )
            {
                writer.WriteLine( text );
            }
        }
        catch ( Exception ex )
        {
            Console.WriteLine( "Произошла ошибка при записи в файл: " + ex.Message );
        }
    }
    public string[] ReadTextInFile()
    {
        string[] lines = File.ReadAllLines( filePath );
        return lines;
    }
    public void ClearFile( string filePath )
    {
        File.WriteAllText( filePath, String.Empty );
    }
}

