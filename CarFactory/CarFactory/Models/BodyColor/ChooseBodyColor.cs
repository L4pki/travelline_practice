public class ChooseBodyColor
{
    public IBodyColor ChooseColorForCar()
    {
        Console.WriteLine( "Выберите цвет кузова: " );
        Console.WriteLine( "(1) Красный " );
        Console.WriteLine( "(2) Зеленый " );
        Console.WriteLine( "(3) Синий " );
        Console.Write( "Введите номер -  " );
        try
        {
            string numberOfColor = Console.ReadLine();
            if ( numberOfColor == "1" )
            {
                return new RedColor();
            }
            else if ( numberOfColor == "2" )
            {
                return new GreenColor();
            }
            else
            {
                return new BlueColor();
            }
        }
        catch
        {
            Console.WriteLine( "Ошибка ввода, цвет выбран по умолчанию Красный!" );
            return new RedColor();
        }
    }
}