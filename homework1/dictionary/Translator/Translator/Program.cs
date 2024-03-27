using EnRuTranslator;
class Programm
{
    static void Main()
    {
        Translator translator = new Translator();
        bool isProgrammWorking = true;
        while (isProgrammWorking)
        {
            Console.WriteLine("Введите код команды:\n (1)Добавить перевод\n (2)Удалить перевод\n (3)Изменить перевод\n (4)Перевести слово\n (5)Выйти");
            string command = Console.ReadLine();

            switch (command)
            {
                case "1":
                    Console.WriteLine("Введите слово и его перевод через запятую:");
                    string[] input = Console.ReadLine().Split(',');
                    if (input.Length < 2)
                    {
                        Console.WriteLine("Введены некорректные данные!");
                        break;
                    }
                    translator.AddTranslation(input[0].Trim(), input[1].Trim());
                    break;
                case "2":
                    Console.WriteLine("Введите слово для удаления:");
                    string wordToRemove = Console.ReadLine();
                    translator.RemoveTranslation(wordToRemove);
                    break;
                case "3":
                    Console.WriteLine("Введите слово и новый перевод через запятую:");
                    string[] changeInput = Console.ReadLine().Split(',');
                    if (changeInput.Length < 2)
                    {
                        Console.WriteLine("Введены некорректные данные!");
                        break;
                    }
                    translator.ChangeTranslation(changeInput[0].Trim(), changeInput[1].Trim());
                    break;
                case "4":
                    Console.WriteLine("Введите слово для перевода:");
                    string wordToTranslate = Console.ReadLine();
                    Console.WriteLine(translator.Translate(wordToTranslate));
                    break;
                case "5":
                    isProgrammWorking = false;
                    break;
                default:
                    Console.WriteLine("Неизвестная команда");
                    break;
            }
        }
    }
}