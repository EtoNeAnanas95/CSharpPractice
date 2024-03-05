using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class function
    {

        public static void PrintHat(string name)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            int width = Console.WindowWidth;

            Console.SetCursorPosition((width / 2) - name.Length, 0);
            Console.WriteLine(name);
            for (int i = 0; i < width; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine();
            string text = "  Имя файла:                                               Дата создания файла:                                                 | *Для создания файла:";
            Console.Write(text);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(" F1");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(0, 3);
            Console.Write("                                                                                                                                | *Для создания папки:");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(" F2");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("                                                                                                                                | *Для удаления файла:");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(" F3");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(0, 3);
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------");
        }

        public static void PrintSpace(FileSystemInfo item)
        {
            for (int i = 0; i < 57-item.Name.Length; i++)
            {
                Console.Write(" ");
            }
        }
    }
}
