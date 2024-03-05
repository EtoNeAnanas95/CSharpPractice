using Microsoft.VisualBasic;
using System.Runtime;
using System;
using System.Text;
using System.Net.Http.Headers;
using System.Security.Authentication;

namespace diary
{
    internal class Program
    {
        static void manual(int i)
        {
            Console.SetCursorPosition(0, i + 2);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Для написания новой записки нажмите \"G\"");
            Console.ResetColor();
        }

        static int GetNotesCount(Date? date)
        {
            if (date != null)
                return date.notes.Count;
            else
                return 1;
        }

        static int DrawDate(Date date, DateTime selectedDataTime, string format)
        {
            Console.Clear();
            int index;
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("                   ");
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("Дата " + selectedDataTime.ToString(format));
            Console.SetCursorPosition(0, 1);

            if (date == null)
            {
                Console.WriteLine("  Здесь нет записок");
                index = 0;
            }
            else
            {
                index = date.Print();
            }
            manual(GetNotesCount(date));
            return index;
        }

        static int find_index(Date date)
        {
            int index;
            if (date == null)
            {
                index = 0;
            }
            else
            {
                index = date.index();
            }
            return index;
        }
        static void DrowNameAndDecription(int position, Date note_for_print, DateTime selected_date, string format)
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Дата: {selected_date.ToString(format)}");
            Console.ResetColor();
            Console.SetCursorPosition(0, 1);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Название:");
            Console.ResetColor();
            Console.WriteLine($" {note_for_print.notes[position-1].name}");
            Console.SetCursorPosition(0, 2);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Описание:");
            Console.ResetColor();
            Console.WriteLine($" {note_for_print.notes[position-1].description}");
        }

        static Date CreateNote(string format)
        {
            Date date = new Date();
            DateTime data_1 = new DateTime(2023, 9, 15);
            Console.Clear();
            DatesManager datesManager = new DatesManager();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Для выхода нажмите ENTER");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Выберите дату: ");
            Console.ResetColor();
            ConsoleKey consoleKey = new ConsoleKey();
            Console.WriteLine(data_1.ToString(format));
            while (consoleKey != ConsoleKey.Enter)
            {
                consoleKey = Console.ReadKey().Key;
                Console.SetCursorPosition(0, 2);
                Console.WriteLine("                         ");
                Console.SetCursorPosition(0, 2);
                switch (consoleKey)
                {
                    case ConsoleKey.LeftArrow:
                        data_1 = data_1.AddDays(-1);
                        break;
                    case ConsoleKey.RightArrow:
                        data_1 = data_1.AddDays(1);
                        break;
                }
                Console.WriteLine(data_1.ToString(format));
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Введите имя задачи: ");
            Console.ResetColor();
            string name = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Введите описание задачи: ");
            Console.ResetColor();
            string description = Console.ReadLine();
            date.datetime = data_1;
            date.notes.Add(new Note(name, description));
            return date;

        }


        static int i = 0;
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            i++;
            string format = "dd.MM.yyyy";
            DateTime SelectedDateTime = new DateTime(2023, 9, 15);
            DatesManager DatesManager = new DatesManager();



            Date date_Whith_Note_1 = new Date();
            date_Whith_Note_1.datetime = new DateTime(2023, 9, 15);
            date_Whith_Note_1.notes = new List<Note>();
            date_Whith_Note_1.notes.Add(new Note("Покрутить землю, чтобы она не остановилась"));
            date_Whith_Note_1.notes.Add(new Note("Не рожал -- не мужик", "Обязательно (партийное задание от партии комунистов)"));
            date_Whith_Note_1.notes.Add(new Note("Подоить быка", "и чё?"));

            Date date_Whith_Note_2 = new Date();
            date_Whith_Note_2.datetime = new DateTime(2023, 9, 14);
            date_Whith_Note_2.notes = new List<Note>();
            date_Whith_Note_2.notes.Add(new Note("Выкинуть мусор с балкона в прохожего", "Чтоб не втыкал"));
            date_Whith_Note_2.notes.Add(new Note("Завернуть в фальгу атомную бомбу", "Обязательное задание от деда, нето она отсыреет и будет не вкусная"));
            date_Whith_Note_2.notes.Add(new Note("Отодрать обои"));

            Date date_Whith_Note_3 = new Date();
            date_Whith_Note_3.datetime = new DateTime(2023, 9, 16);
            date_Whith_Note_3.notes = new List<Note>();
            date_Whith_Note_3.notes.Add(new Note("Обгадить весь туалет", "Чтоб было что убрать вечером"));
            date_Whith_Note_3.notes.Add(new Note("Пожарить кота не гриле", "Ну а чё он?"));
            date_Whith_Note_3.notes.Add(new Note("сделать дз по гастрбайтерингу", "Научиться хреного класть плитку и разучиться говорить по русски"));

            DatesManager.dates.Add(date_Whith_Note_1);
            DatesManager.dates.Add(date_Whith_Note_2);
            DatesManager.dates.Add(date_Whith_Note_3);

            Date note_for_print = DatesManager.FindByDateTime(SelectedDateTime);
            int index = DrawDate(note_for_print, SelectedDateTime, format);

            int position = 1;

            Console.SetCursorPosition(0, position);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("->");
            Console.ResetColor();
            ConsoleKey key = ConsoleKey.Q;
            while (key != ConsoleKey.Enter)
            {
                Console.SetCursorPosition(0, 0);
                Console.Write("                   ");
                Console.SetCursorPosition(0, 0);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write($"  Дата: {SelectedDateTime.ToString(format)}");
                Console.ResetColor();
                key = Console.ReadKey().Key;
                Console.SetCursorPosition(0, position);
                Console.WriteLine("  ");
                index = find_index(note_for_print);
                


                switch (key)
                {
                    case ConsoleKey.DownArrow:
                        if (position < index) 
                            position++;
                        break;
                    case ConsoleKey.UpArrow:  
                        if (position > 1)
                            position--;
                        break;
                    case ConsoleKey.LeftArrow:
                        SelectedDateTime = SelectedDateTime.AddDays(-1);
                        note_for_print = DatesManager.FindByDateTime(SelectedDateTime);
                        DrawDate(note_for_print, SelectedDateTime, format);
                        if (note_for_print == null)
                        {
                            index = 1;
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        SelectedDateTime = SelectedDateTime.AddDays(1);
                        note_for_print = DatesManager.FindByDateTime(SelectedDateTime);
                        DrawDate(note_for_print, SelectedDateTime, format);
                        if (note_for_print == null)
                        {
                            index = 1;
                        }
                        break;
                    case ConsoleKey.G:
                        Date buffer = new Date();
                        buffer = CreateNote(format);
                        /*Console.WriteLine(buffer.datetime.ToString(format));*/
                        if (buffer.datetime == date_Whith_Note_1.datetime)
                        {
                            DatesManager.dates[0].notes.Add(new Note(buffer.notes[0].name, buffer.notes[0].description));
                        }
                        else if (buffer.datetime == date_Whith_Note_2.datetime)
                        {
                            DatesManager.dates[1].notes.Add(new Note(buffer.notes[0].name, buffer.notes[0].description));
                        }
                        else if (buffer.datetime == date_Whith_Note_3.datetime)
                        {
                            DatesManager.dates[2].notes.Add(new Note(buffer.notes[0].name, buffer.notes[0].description));
                        }
                        DatesManager.dates.Add(buffer);
                        DrawDate(note_for_print, SelectedDateTime, format);
                        break;
                }
                Console.SetCursorPosition(0, position);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("->");
                Console.ResetColor();
            }
            DrowNameAndDecription(position, note_for_print, SelectedDateTime, format);
        }
    }
}