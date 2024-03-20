Console.WriteLine("Введите название товара:");
string product = Console.ReadLine();

Console.WriteLine("Введите количество:");
int count = int.Parse(Console.ReadLine());

Console.WriteLine("Введите ваше имя:");
string name = Console.ReadLine();

Console.WriteLine("Введите адрес доставки:");
string address = Console.ReadLine();

Console.WriteLine($"Здравствуйте, {name}, вы заказали {count} {product} на адрес {address}, все верно? (да/нет)");
string confirmation = Console.ReadLine();

if (confirmation.ToLower() == "да")
{
    Console.WriteLine($"{name}!\nВаш заказ {product} в количестве {count} оформлен!\nОжидайте доставку по адресу {address} к {DateTime.Now.AddDays(3).ToShortDateString()}");
}
else
{
    Console.WriteLine("Пожалуйста, введите данные заново.");
}