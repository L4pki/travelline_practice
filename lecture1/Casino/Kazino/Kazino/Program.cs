while (true)
{
    Console.WriteLine("Введите ставку: ");
    string stavkaStr = Console.ReadLine();
    int stavka = int.Parse(stavkaStr);
    Random r = new Random();
    int rInt = r.Next(0, 20);
    Console.WriteLine(rInt);
    if (rInt >= 18)
    {
        float result = stavka * (1 + ((rInt - 17) / 10));
        Console.WriteLine(result);
    }
}

