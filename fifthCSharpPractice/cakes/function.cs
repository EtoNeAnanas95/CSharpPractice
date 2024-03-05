using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cakes
{
    internal class function
    {
        public static int arrow_menu(int index)
        {
            Console.SetCursorPosition(0, index + 2);
            Console.WriteLine("--------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Нажмите Escape чтобы вернуться в меню");
            Console.ResetColor();
            ConsoleKey key = ConsoleKey.Q;
            int position = 2;
            while (key != ConsoleKey.Enter)
            {

                key = Console.ReadKey().Key;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.SetCursorPosition(0, position);
                Console.WriteLine("  ");
                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        if (position > 2) position--;
                        break;
                    case ConsoleKey.DownArrow:
                        if (position <= index) position++;
                        break;
                }
                Console.SetCursorPosition(0, position);
                Console.WriteLine("->");
                Console.ResetColor();
                if (key == ConsoleKey.Escape)
                {
                    Console.Clear();
                    return -1;
                }
                if (key == ConsoleKey.Enter) Console.Clear();
            }
            return position-2;
        }
        public static void print(int index, string[] argument, int[] cost)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Выберите параметр торта:");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("--------------------------------------------");
            for (int i = 1; i <= index; i++)
            {
                Console.WriteLine($"  {i}. {argument[i-1]}, цена -- {cost[i-1]}");
            }
            Console.SetCursorPosition(0, 2);
            Console.WriteLine("->");
        }
       public static void save_the_order(cake cake, int index, int price)
       {
            if (index != -1)
            {
                switch (index)
                {
                    case 0:
                        Console.Clear();
                        if (cake.size == null || cake.foarm == null || cake.glaze == null || cake.taste == null || cake.decorations == null || cake.number_of_cakes == null)
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine("Вы не настроили торт до конца");
                            Console.WriteLine("Настройте его и возвращайтесь к выходу)");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("\nДля возвращения в меню настроек нажмите любую кнопку");
                            ConsoleKey key = Console.ReadKey().Key;
                            Console.ResetColor();
                            Console.Clear();
                        }
                        else
                        {
                            write_data(cake, price);
                        }
                        break;
                    case 1:
                        Console.Clear();
                        Environment.Exit(0);
                        break;
                    default: break;
                }
            }
       }
        private static void write_data(cake cake, int price)
        {
            DateTime dateOrder = DateTime.Now;
            string[] order = new string[8];
            order[0] = $"Дата заказа: {Convert.ToString(dateOrder)}";
            order[1] = $"\tразмер: {cake.size}";
            order[2] = $"\tформа: {cake.foarm}";
            order[3] = $"\tвкус: {cake.taste}";
            order[4] = $"\tкол-во коржей: {cake.number_of_cakes}";
            order[5] = $"\tглазурь: {cake.glaze}";
            order[6] = $"\tдекор: {cake.decorations}";
            order[7] = $"\tстоимость: {price}";
            File.AppendAllLines("order.txt", order);
            Console.ResetColor();
            Console.Clear();
        }
    }
}
