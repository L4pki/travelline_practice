int balance = 10000;
Random random = new Random();
int strikeNum = 0;

while (balance > 0)
{
    Console.Clear();
    Console.WriteLine("У тебя на счету: " + balance);
    Console.Write("Введи свою ставку: ");
    string betStr = Console.ReadLine();
    int bet = int.Parse(betStr);

    if (bet > balance)
    {
        Console.WriteLine("На твоем счету мало средств!");
        Thread.Sleep(2000);
        continue;
    }
    if (bet < 0)
    {
        strikeNum++;
        if (strikeNum == 1)
        {
            Console.WriteLine("ЧИТЕР!\nУ тебя " + strikeNum + " Страйк");
            Thread.Sleep(2000);
            continue;
        }
        Console.WriteLine("ЧИТЕР!\nУ тебя " + strikeNum + " Страйка");
        if (strikeNum >= 3)
        {
            Console.WriteLine("Вы покидаете игру, набрав 3 срайка");
            break;
        }
        Thread.Sleep(2000);
        continue;
    }

    int rndNumber = random.Next(1, 21);
    Console.WriteLine("Твое число: " + rndNumber);

    if (rndNumber >= 18)
    {
        int winAmount = bet * (1 + (2 * (rndNumber % 17)));
        balance += winAmount;
        Console.WriteLine("Ты Выиграл " + winAmount + " u.e.");
    }
    else
    {
        balance -= bet;
        Console.WriteLine("Ты проиграл свою ставку(");
    }
    Console.WriteLine("Ты хочешь остановиться?\nУ тебя на счету " + balance + " u.e. (да)");
    string answer = Console.ReadLine();
    if (answer == "да")
    {
        Console.WriteLine("Ваш выигрышь" + balance + " u.e.");
    }
    else
    {
        Console.WriteLine("Продолжим");
    }
    Thread.Sleep(2000);
}
Console.WriteLine("Игра окончена");
