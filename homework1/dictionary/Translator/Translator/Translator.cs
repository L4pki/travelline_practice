namespace EnRuTranslator
{
    class Translator
    {
        private Dictionary<string, string> _translations;

        public Translator()
        {
            _translations = new Dictionary<string, string>();
            LoadTranslationsFromFile("translations.txt");
        }

        public void AddTranslation(string word, string translation)
        {
            _translations[word] = translation;
            _translations[translation] = word;
            SaveTranslationsToFile("translations.txt");
        }

        public void RemoveTranslation(string word)
        {
            if (_translations.ContainsKey(word))
            {
                _translations.Remove(_translations[word]);
                _translations.Remove(word);
                SaveTranslationsToFile("translations.txt");
            }
            else
            {
                Console.WriteLine("Слова нет в словаре");
            }
        }

        public void ChangeTranslation(string word, string newTranslation)
        {
            if (_translations.ContainsKey(word))
            {
                _translations.Remove(_translations[word]);
                _translations.Remove(word);
                _translations[word] = newTranslation;
                _translations[newTranslation] = word;
                SaveTranslationsToFile("translations.txt");
            }
            else
            {
                Console.WriteLine("Слова нет в словаре");
            }
        }

        public string Translate(string word)
        {
            if (_translations.ContainsKey(word))
            {
                return _translations[word];
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
                    _translations[parts[0]] = parts[1];
                }
            }
        }

        private void SaveTranslationsToFile(string fileName)
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                foreach (var pair in _translations)
                {
                    writer.WriteLine(pair.Key + "," + pair.Value);
                }
            }
        }
    }
}
