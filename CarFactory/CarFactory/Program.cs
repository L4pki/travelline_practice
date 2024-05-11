class Program
{
    static void Main( string[] args )
    {
        CarFactory factory = new CarFactory();
        bool isContinueWorkFactory = true;
        while ( isContinueWorkFactory )
        {
            Car car = factory.CreateCar();
            Console.WriteLine( "Машина укомплектована! " );
            Console.WriteLine( "Нажмите Enter чтобы продолжить" );
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine( "Конфигурация собранного авто: " );
            car.PrintConfiguration();
            Console.WriteLine( "Продолжить сборку? yes/no" );
            if ( Console.ReadLine() == "no" )
            {
                isContinueWorkFactory = false;
            }
            Console.Clear();
        }
    }
}
