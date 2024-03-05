using System;
namespace ConsoleApp1
{
    internal class Program
    {



     //для вывода анектодота нажмите G
     // возможно он там не один



        static int[] tonal = new int[12];
        static ConsoleKey change = ConsoleKey.F1;
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Для выхода нажмите клавишу ");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("ESC");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Управление пианино осуществляется через клавиши q w e r t y u i o p [ ]");
            Console.ResetColor();
            do
            {
                tonal = octave_change(change);
                pianino(tonal);
            }
            while (change != ConsoleKey.Escape);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Вы вышли из пианино");
            Console.ResetColor();
        }

        static ConsoleKey pianino(int[] tonal)
        {
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.F1:
                        change = key.Key;
                        tonal = octave_change(change);
                        break;
                    case ConsoleKey.F2:
                        change = key.Key;
                        tonal = octave_change(change);
                        break;
                    case ConsoleKey.Escape:
                        change = key.Key;
                        return change;
                        break;
                    case ConsoleKey.G:
                        change = key.Key;
                        return change;
                        break;
                }
                switch (key.Key)
                {
                    case ConsoleKey.Q:
                        Console.Beep(tonal[0], 100);
                        break;

                    case ConsoleKey.W:
                        Console.Beep(tonal[1], 100);
                        break;

                    case ConsoleKey.E:
                        Console.Beep(tonal[2], 100);
                        break;

                    case ConsoleKey.R:
                        Console.Beep(tonal[3], 100);
                        break;

                    case ConsoleKey.T:
                        Console.Beep(tonal[4], 100);
                        break;

                    case ConsoleKey.Y:
                        Console.Beep(tonal[5], 100);
                        break;

                    case ConsoleKey.U:
                        Console.Beep(tonal[6], 100);
                        break;

                    case ConsoleKey.I:
                        Console.Beep(tonal[7], 100);
                        break;

                    case ConsoleKey.O:
                        Console.Beep(tonal[8], 100);
                        break;

                    case ConsoleKey.P:
                        Console.Beep(tonal[9], 100);
                        break;

                    case ConsoleKey.Oem4:
                        Console.Beep(tonal[10], 100);
                        break;

                    case ConsoleKey.Oem6:
                        Console.Beep(tonal[11], 100);
                        break;
                }
            }
        }
        static int[] octave_change(ConsoleKey change)
        {
            int[] octave = new int[12];
            switch (change)
            {
                case ConsoleKey.F1:
                    octave = octave_1();
                    break;
                case ConsoleKey.F2:
                    octave = octave_2();
                    break;
                case ConsoleKey.G:
                    Console.Write("Подходит мужик к песочнице где играет маленькая девочка: \n- Девочка, хочешь конфетку? \n- Дяденька вы педофил? \n- Нет. \n- Ну а смысл тогда?\n\n");
                    Console.WriteLine("ещё один?");
                    string anekdot = Console.ReadLine();
                    if (anekdot == "да" || anekdot == "Да" || anekdot == "Yea" || anekdot == "Yes" || anekdot == "lf" || anekdot == "Lf")
                    {
                        Console.Write("\nШтирлиц топил камин всю ночь \nна утро камин утонул\n\nПианино если что работает на первой актаве\n\n");
                    }
                    else Console.WriteLine("ну и ладно\nПианино если что работает на первой актаве\n\n");
                    octave = octave_1();
                    break;
            }
            return octave;
        }
        static int[] octave_1()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Вы попали в");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(" пeрвую ");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("октаву");
            Console.ResetColor();
            int[] firstOctave = new int[] { 261, 277, 293, 311, 329, 349, 369, 392, 415, 440, 466, 493 };
            return firstOctave;
        }
        static int[] octave_2()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Вы попали в");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(" вторую ");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("октаву");
            Console.ResetColor();
            int[] secondOctave = new int[] { 523, 554, 587, 622, 659, 698, 739, 784, 830, 880, 932, 987 };
            return secondOctave;
        }
    }
}
