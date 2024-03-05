using System;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.IO;
using System.Linq.Expressions;
using System.Text;
using System.Xml.Serialization;
using static System.Net.Mime.MediaTypeNames;

namespace sixth_c_sharp_practo
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Введите путь до файла (вместе с названием), который вы хотите открыть");
            Console.WriteLine("---------------------------------------------------------------------");
            Console.SetCursorPosition(0, 3);
            Console.WriteLine("---------------------------------------------------------------------");
            Console.ForegroundColor= ConsoleColor.White;
            Console.Write("Для выхода нажмите ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("ESCAPE");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Для сохранения нажмите ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("F1\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Для изменения текста нажмите ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("F2");
            Console.ResetColor();
            Console.SetCursorPosition(0, 2);
            string path = Console.ReadLine();

            if (!File.Exists(path))
            {
                Console.SetCursorPosition(0, 2);
                for (int i = 0; i < path.Length; i++) Console.Write(" ");
                Console.SetCursorPosition(0, 2);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Путь не существует!");
                Console.SetCursorPosition(0, 12);
                Console.ResetColor();
                Environment.Exit(1);
            }
            TextEditor editor = new TextEditor(path);
            ConsoleKeyInfo key;
            do
            {
                editor.Display();
                key = Console.ReadKey();

                switch (key.Key)
                {
                    case ConsoleKey.Escape:
                        Console.Clear();
                        break;
                    case ConsoleKey.F2:
                        editor.Edit();
                        break;
                    case ConsoleKey.F1:
                        editor.Save();
                        break;
                }
            } while (key.Key != ConsoleKey.Escape);
        }
    }
}