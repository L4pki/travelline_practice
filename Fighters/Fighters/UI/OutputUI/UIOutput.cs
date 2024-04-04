namespace Fighters.UI.OutputUI
{
    public class UIOutput
    {
        public void WriteLine(string text, string color)
        {
            ConsoleColor colorValue;
            if (!Enum.TryParse(color, true, out colorValue))
                throw new ArgumentException($"Invalid color value: {color}");
            Console.ForegroundColor = colorValue;
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void Write(string text, string color)
        {
            ConsoleColor colorValue;
            if (!Enum.TryParse(color, true, out colorValue))
                throw new ArgumentException($"Invalid color value: {color}");
            Console.ForegroundColor = colorValue;
            Console.Write(text);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}

