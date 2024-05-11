public class CarFactory
{
    public Car CreateCar()
    {
        Console.WriteLine( "Давайте создадим новую машину! " );
        ChooseBodyColor chooseColor = new ChooseBodyColor();
        IBodyColor color = chooseColor.ChooseColorForCar();

        ChooseBodyType chooseBodyType = new ChooseBodyType();
        IBodyType bodyType = chooseBodyType.ChooseBodyTypeForCar();

        ChooseEngine chooseEngine = new ChooseEngine();
        IEngine engine = chooseEngine.ChooseEngineForCar();

        ChooseTransmission chooseTransmission = new ChooseTransmission();
        ITransmission transmission = chooseTransmission.ChooseTransmissionForCar();
        return new Car
        {
            BodyColor = color,
            BodyType = bodyType,
            Engine = engine,
            Transmission = transmission,
            MaxSpeed = CalculateMaxSpeed( engine ),
            Gears = CalculateNumberOfGears( engine, transmission )
        };
    }

    private int CalculateMaxSpeed( IEngine engine )
    {
        return engine.MaxSpeed;
    }

    private int CalculateNumberOfGears( IEngine engine, ITransmission transmission )
    {
        return transmission.NumberOfGears > engine.NumberOfGears ? transmission.NumberOfGears : engine.NumberOfGears;
    }
}
