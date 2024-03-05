using System.Diagnostics;
using System;

namespace cakes
{
    internal class Program
    {
        
        static int give_me_info_baby(int i, List<string[]> argument, List<int[]> cost)
        {
            int index = argument[i].Count();
            function.print(index, argument[i], cost[i]);
            int second_index = function.arrow_menu(index);
            return second_index;
        }
        /*Боль сама по себе очень важна, за обучением ученика будет следить, но это происходит в такое время, когда работы и боли много.
        Если говорить до мельчайших деталей, никто не должен заниматься никакой работой, кроме как для того, чтобы получить от нее какой-нибудь хороший результат.
        
         **София Алексеевна 
         */
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            int price = 0;
            cake cake = new cake();
            List<int[]> cost = new List<int[]>();
            cost.Add(new int[] { 913984, 300, 500, 700 });
            cost.Add(new int[] { 300, 400, 500, 19874 });
            cost.Add(new int[] { 200, 9999, 500, 450000, 500, 300, 1200, 400, 1 });
            cost.Add(new int[] { 100, 300, 500, 700 });
            cost.Add(new int[] { 200, 300, 200, 11700, 19000 });
            cost.Add(new int[] { 15, 9999, 1500});
            List<string[]> argument = new List<string[]>();
            argument.Add(new string[] { "Чтоб в карман поместился", "Большой", "Средний", "Маленький" });
            argument.Add(new string[] { "Круг", "Квадрат", "Сердечко", "Вялая нога деда"});
            argument.Add(new string[] { "Клубника", "кошачий лоток", "Черника", "Ушная сера шрека", "Молочный шоколад", "чёрный шоколад", "белый шоколад", "кокос", "тухлые носки" });
            argument.Add(new string[] { "1", "2", "3", "58" });
            argument.Add(new string[] { "Шоколад", "Крем", "Бизе", "Волосы с бороды", "Полеэтилен" });
            argument.Add(new string[] { "Фигурка осла", "Бабкин ковёр", "Посыпка из гвоздей" });
            while (true)
            {
                Console.WriteLine("Пранк фирма \"Подставной торт\". Рады вас обслужить!");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Выберите параметр торта:");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("->1. Размер");
                Console.WriteLine("  2. Форма");
                Console.WriteLine("  3. Вкус");
                Console.WriteLine("  4. Количесвто коржей");
                Console.WriteLine("  5. Глазурь");
                Console.WriteLine("  6. Декор");
                Console.WriteLine("  7. Выход");
                int index = 7;
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.SetCursorPosition(0, index+3);
                Console.WriteLine($"Цена заказа: {price}");
                Console.ResetColor();
                ConsoleKey key;
                int position = 2;
                do
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
                            if (position < index + 1) position++;
                            break;
                    }
                    Console.SetCursorPosition(0, position);
                    Console.WriteLine("->");
                    Console.ResetColor();
                }
                while (key != ConsoleKey.Enter);
                switch (position)
                {
                    case 2:
                        index = give_me_info_baby(position - 2, argument, cost);
                        if (index != -1) cake.size = argument[position - 2][index];
                        else break;
                        price += cost[position-2][index];
                        break;
                    case 3:
                        index = give_me_info_baby(position - 2, argument, cost);
                        if (index != -1) cake.foarm = argument[position - 2][index];
                        else break;
                        price += cost[position - 2][index];
                        break;
                    case 4:
                        index = give_me_info_baby(position - 2, argument, cost);
                        if (index != -1) cake.taste = argument[position - 2][index];
                        else break;
                        price += cost[position - 2][index];
                        break;
                    case 5:
                        index = give_me_info_baby(position - 2, argument, cost);
                        if (index != -1) cake.number_of_cakes = argument[position - 2][index];
                        else break;
                        price += cost[position - 2][index];
                        break;
                    case 6:
                        index = give_me_info_baby(position - 2, argument, cost);
                        if (index != -1) cake.glaze = argument[position - 2][index];
                        else break;
                        price += cost[position - 2][index];
                        break;
                    case 7:
                        index = give_me_info_baby(position - 2, argument, cost);
                        if (index != -1) cake.decorations = argument[position - 2][index];
                        else break;
                        price += cost[position - 2][index];
                        break;
                    case 8:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("--------------------------------------------");
                        Console.WriteLine("Сохранить заказ?");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("->1. Да");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("  2. Нет");
                        index = function.arrow_menu(2);
                        function.save_the_order(cake, index, price);
                        break;
                }
            }
        }
    }
}