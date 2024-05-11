public class ChooseTransmission
{
    public ITransmission ChooseTransmissionForCar()
    {
        Console.WriteLine( "Выберите коробку передач: " );
        Console.WriteLine( "(1) Автоматическая " );
        Console.WriteLine( "(2) Механическая " );
        Console.Write( "Введите номер -  " );
        try
        {
            string numberOfTransmission = Console.ReadLine();
            if ( numberOfTransmission == "1" )
            {
                return new AutomaticTransmission();
            }
            else
            {
                return new ManualTransmission();
            }
        }
        catch
        {
            Console.WriteLine( "Ошибка ввода, коробка передач выбрана по умолчанию механическая!" );
            return new ManualTransmission();
        }
    }
}