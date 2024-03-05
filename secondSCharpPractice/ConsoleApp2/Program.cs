using System;
using System.Diagnostics.Metrics;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int menu;
            do
            {
                Console.WriteLine("Выберете действие: ");
                Console.WriteLine("1. Игра «угодай число»");
                Console.WriteLine("2. Таблица умножения");
                Console.WriteLine("3. Вывод делителя числа");
                Console.WriteLine("4. Выход");
                menu = Convert.ToInt32(Console.ReadLine());
                switch (menu)
                {
                    case 1:

                        game();
                        break;

                    case 2:

                        tablica();
                        break;

                    case 3:

                        delitel();
                        break;
                }

                static void game()
                {
                    Random random = new Random();
                    int chislo = random.Next(0, 100);
                    Console.WriteLine("Угодай число, сладенький)");
                    int ygodai = Convert.ToInt32(Console.ReadLine());
                    while (ygodai != chislo)
                    {
                        if (ygodai < chislo)
                        {

                            Console.WriteLine("Бро, нада побольше");
                        }
                        else if (ygodai > chislo)
                        {

                            Console.WriteLine("Бро, это слишком много, я не вывожу");
                        }
                        ygodai = Convert.ToInt32(Console.ReadLine());
                    }
                    
                    Console.WriteLine("УРА ПОБЕДА");
                    Console.WriteLine("УРА ПОБЕДА");
                    Console.WriteLine("УРА ПОБЕДА");
                }
                static void tablica()
                {

                    int[,] tablica = new int[9, 9];
                    for (int i = 0; i < 9; i++)
                    {
                        for (int j = 0; j < 9; j++)
                        {
                            int G = i + 1;
                            int B = j + 1;
                            int Q = G * B;
                            tablica[i, j] = Q;
                        }
                    }
                    for (int j = 0; j < 9; j++)
                    {
                        for (int i = 0; i < 9; i++)
                        {
                            int G = i + 1;
                            int B = j + 1;
                            Console.Write(G + " * " + B + " = " + tablica[j, i]);
                            Console.Write("\t\t");
                        }
                        Console.WriteLine();
                    }

                }
                static void delitel()
                {
                    string a = "жопа";

                    while (a != "да" & a != "Да")
                    {
                        Console.WriteLine("Введите число");
                        int chislo = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("число " + chislo + " может делиться на: ");
                        for (int i = 1; i <= chislo; i++)
                        {
                            /*int Q = chislo % i;*/
                            if (chislo % i == 0)
                            {
                                Console.WriteLine(i);
                            }
                        }
                        Console.WriteLine("Завершить?");
                        a = Console.ReadLine();
                    }

                }
            }
            while (menu != 4);
        }
    }
}