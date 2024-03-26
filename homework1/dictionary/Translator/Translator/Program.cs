class Translator
{
    private Dictionary<string, string> translations;

    public Translator()
    {
        translations = new Dictionary<string, string>();
        LoadTranslationsFromFile("translations.txt");
    }

    public void AddTranslation(string word, string translation)
    {
        translations[word] = translation;
        translations[translation] = word;
        SaveTranslationsToFile("translations.txt");
    }

    public void RemoveTranslation(string word)
    {
        if (translations.ContainsKey(word))
        {
            translations.Remove(translations[word]);
            translations.Remove(word);
            SaveTranslationsToFile("translations.txt");
        }
        else
        {
            Console.WriteLine("Слова нет в словаре");
        }
    }

    public void ChangeTranslation(string word, string newTranslation)
    {
        if (translations.ContainsKey(word))
        {
            translations[word] = newTranslation;
            translations.Remove(translations[word]);
            translations[newTranslation] = word;
            translations.Remove(word);
            SaveTranslationsToFile("translations.txt");
        }
        else
        {
            Console.WriteLine("Слова нет в словаре");
        }
    }

    public string Translate(string word)
    {
        if (translations.ContainsKey(word))
        {
            return translations[word];
        }
        else
        {
            return "Слова нет в словаре";
        }
    }

    private void LoadTranslationsFromFile(string fileName)
    {
        if (File.Exists(fileName))
        {
            string[] lines = File.ReadAllLines(fileName);
            foreach (var line in lines)
            {
                string[] parts = line.Split(',');
                translations[parts[0]] = parts[1];
            }
        }
    }

    private void SaveTranslationsToFile(string fileName)
    {
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            foreach (var pair in translations)
            {
                writer.WriteLine(pair.Key + "," + pair.Value);
            }
        }
    }

    static void Main()
    {
        Translator translator = new Translator();
        bool isProgrammWorking = true;
        while (isProgrammWorking)
        {
            Console.WriteLine("Введите код команды: Добавить перевод(1), Удалить перевод(2), Изменить перевод(3), Перевести слово(4), Выйти(5)");
            string command = Console.ReadLine();

            switch (command)
            {
                case "1":
                    Console.WriteLine("Введите слово и его перевод через запятую:");
                    string[] input = Console.ReadLine().Split(',');
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