public class ChooseEngine
{
    public IEngine ChooseEngineForCar()
    {
        Console.WriteLine( "Выберите двигатель: " );
        Console.WriteLine( "(1) V6 " );
        Console.WriteLine( "(2) Inline4 " );
        Console.WriteLine( "(3) Electric " );
        Console.Write( "Введите номер -  " );
        try
        {
            string numberOfEngine = Console.ReadLine();
            if ( numberOfEngine == "1" )
            {
                return new V6Engine();
            }
            else if ( numberOfEngine == "2" )
            {
                return new Inline4Engine();
            }
            else
            {
                return new ElectricEngine();
            }
        }
        catch
        {
            Console.WriteLine( "Ошибка ввода, дигатель выбран по умолчанию V6!" );
            return new V6Engine();
        }
    }
}