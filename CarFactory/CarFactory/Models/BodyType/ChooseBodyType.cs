public class ChooseBodyType
{
    public IBodyType ChooseBodyTypeForCar()
    {
        Console.WriteLine( "Выберите кузов: " );
        Console.WriteLine( "(1) Седан " );
        Console.WriteLine( "(2) Хетчбэк " );
        Console.WriteLine( "(3) Коуп " );
        Console.Write( "Введите номер -  " );
        try
        {
            string numberOfBodyType = Console.ReadLine();
            if ( numberOfBodyType == "1" )
            {
                return new Sedan();
            }
            else if ( numberOfBodyType == "2" )
            {
                return new Hatchback();
            }
            else
            {
                return new Coupe();
            }
        }
        catch
        {
            Console.WriteLine( "Ошибка ввода, кузов выбран по умолчанию Седан!" );
            return new Sedan();
        }
    }
}