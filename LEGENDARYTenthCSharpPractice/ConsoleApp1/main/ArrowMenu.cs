using ConsoleApp1.ENUM;

namespace ConsoleApp1.main
{
    internal class ArrowMenu
    {
        public static int Menu(int position, int length)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(0, position);
            int startPosition = position;
            int deviation = 0;
            if (position > 2) deviation = position - 2;
            length = length + deviation;
            Console.WriteLine("->");
            ConsoleKey key;
            do
            {
                key = Console.ReadKey(true).Key;

                Console.SetCursorPosition(0, position);
                Console.WriteLine("  ");
                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        if (position > startPosition) position--;
                        break;
                    case ConsoleKey.DownArrow:
                        if (position <= length) position++;
                        break;
                    case ConsoleKey.Escape:
                        return (int)Actions.BackToMenu;
                    case ConsoleKey.S:
                        return (int)Actions.Save;
                    case ConsoleKey.F1:
                        return (int)Actions.NewElement;
                    case ConsoleKey.Delete:
                        return (int)Actions.Delete;
                    case ConsoleKey.F2:
                        return (int)Actions.Search;
                }
                Console.SetCursorPosition(0, position);
                Console.WriteLine("->");
            }
            while (key != ConsoleKey.Enter);
            Console.SetCursorPosition(0, position);
            Console.WriteLine("  ");
            return position - 2 - deviation;
        }
    }
}
