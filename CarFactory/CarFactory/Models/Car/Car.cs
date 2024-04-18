public class Car
{
    public IBodyColor BodyColor { get; set; }
    public IBodyType BodyType { get; set; }
    public IEngine Engine { get; set; }
    public ITransmission Transmission { get; set; }
    public int MaxSpeed { get; set; }
    public int Gears { get; set; }

    public void PrintConfiguration()
    {
        Console.WriteLine( $"Цвет кузова: {BodyColor.Color}" );
        Console.WriteLine( $"Тип кузоа: {BodyType.Name}" );
        Console.WriteLine( $"Дигатель: {Engine.Type}" );
        Console.WriteLine( $"Коробка передач: {Transmission.Type}" );
        Console.WriteLine( $"Максимальная скорость: {MaxSpeed} км/ч" );
        Console.WriteLine( $"Количество передач: {Gears}" );
    }
}