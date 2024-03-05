using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Menu
    {
        public static int ArrowMenuFirst(int length)
        {
            Console.ForegroundColor = ConsoleColor.White;
            int position = 2;
            Console.SetCursorPosition(0, position);
            Console.WriteLine("->");
            ConsoleKey key;
            do
            {
                key = Console.ReadKey().Key;

                Console.SetCursorPosition(0, position);
                Console.WriteLine("  ");
                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        if (position > 2) position--;
                        break;
                    case ConsoleKey.DownArrow:
                        if (position <= length) position++;
                        break;
                    case ConsoleKey.Escape:
                        return -1;
                }
                Console.SetCursorPosition(0, position);
                Console.WriteLine("->");
            }
            while (key != ConsoleKey.Enter);
            Console.Clear();
            return position - 2;
        }

        public static int ArrowMenuMain(DirectoryInfo Item)
        {
            FileSystemInfo[] allItems = Item.GetFileSystemInfos();
            int length = allItems.Length + 1;
            Console.ForegroundColor = ConsoleColor.White;
            int position = 4;
            Console.SetCursorPosition(0, position);
            Console.WriteLine("->");
            ConsoleKey key;
            do
            {
                key = Console.ReadKey().Key;

                Console.SetCursorPosition(0, position);
                Console.WriteLine("  ");
                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        if (position > 4) position--;
                        break;
                    case ConsoleKey.DownArrow:
                        if (position < length + 2) position++;
                        break;
                    case ConsoleKey.Escape:
                        return -1;
                    case ConsoleKey.F1:
                        ExplorerEditor.CreateDirectory(Item);
                        return -1;
                    case ConsoleKey.F2:
                        ExplorerEditor.CreateFile(Item);
                        return -1;
                    case ConsoleKey.F3:
                        ExplorerEditor.Delete(allItems[position - 4]);
                        return -1;
                }
                Console.SetCursorPosition(0, position);
                Console.WriteLine("->");
            }
            while (key != ConsoleKey.Enter);

            ExplorerEditor.Open(allItems[position - 4]);
            return 1;
        }
    }
}
