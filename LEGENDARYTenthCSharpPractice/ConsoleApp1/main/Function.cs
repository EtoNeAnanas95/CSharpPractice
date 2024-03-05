using ConsoleApp1.classes;
using ConsoleApp1.clients;
using ConsoleApp1.ENUM;
using ConsoleApp1.main;
using Newtonsoft.Json;
using static System.Console;

namespace ConsoleApp1
{
    internal class Function
    {
        public static void PrintHat(string hello, string post = null)
        {
            if (post != null)
            {
                int windowWidth = WindowWidth / 2;
                hello = $"Добро пожаловать, {hello}!";
                int typeSpace = windowWidth / 2 - hello.Length / 2;
                PaintOverTheArea(typeSpace);
                ForegroundColor = ConsoleColor.Yellow;
                Write(hello);
                ResetColor();
                post = $"Должность: {post}";
                typeSpace = windowWidth / 2 - post.Length / 2;
                PaintOverTheArea(typeSpace);
                ForegroundColor = ConsoleColor.Yellow;
                WriteLine(post);
                ResetColor();
                for (int i = 0; i < WindowWidth; i++)
                {
                    Write("-");
                }

                WriteLine();
            }
            else
            {
                hello = $"Добро пожаловать, {hello}!";
                int typeSpace = WindowWidth / 2 - hello.Length / 2;
                for (int i = 0; i < typeSpace + 1; i++)
                {
                    Write(" ");
                }

                WriteLine(hello);
                for (int i = 0; i < WindowWidth; i++)
                {
                    Write("-");
                }

                WriteLine();
            }
        }

        public static DateOnly DateInputValidation(int x, int y)
        {
            DateOnly date;
            while (true)
            {
                try
                {
                    SetCursorPosition(x, y);
                    string input = ReadLine();
                    date = DateOnly.ParseExact(input, "yyyy.MM.dd",
                        null);
                    break;
                }
                catch (Exception e)
                {
                    SetCursorPosition(x, y);
                    Write("Дата введена неверно (формат yyyy.MM.dd)");
                    ForegroundColor = BackgroundColor;
                    ReadLine();
                    ResetColor();
                    SetCursorPosition(x, y);
                    PaintOverTheArea("Дата введена неверно (формат yyyy.MM.dd)");
                }
            }

            return date;
        }

        public static bool BoolValidation(int x, int y)
        {
            bool item;
            while (true)
            {
                try
                {
                    SetCursorPosition(x, y);
                    item = Convert.ToBoolean(ReadLine());
                    break;
                }
                catch (Exception e)
                {
                    SetCursorPosition(x, y);
                    Write("Данные введены неверно (нажмите чтобы убрать)");
                    ForegroundColor = BackgroundColor;
                    ReadLine();
                    ResetColor();
                    SetCursorPosition(x, y);
                    PaintOverTheArea("Данные введены неверно (нажмите чтобы убрать)");
                }
            }

            return item;
        }

        public static int InputValidation(int x, int y)
        {
            int num;
            while (true)
            {
                try
                {
                    SetCursorPosition(x, y);
                    num = Convert.ToInt32(ReadLine());
                    break;
                }
                catch (Exception e)
                {
                    SetCursorPosition(x, y);
                    Write("Данные Введены не верно (нажмите чтобы продолжить)");
                    ForegroundColor = BackgroundColor;
                    ReadLine();
                    SetCursorPosition(x, y);
                    ResetColor();
                    PaintOverTheArea("Данные Введены не верно (нажмите чтобы продолжить)");
                }
            }

            return num;
        }

        public static void PrintAttributes(string[] attributes, int factor)
        {
            List<int> lengths = new List<int>();

            int workingArea = ((WindowWidth - 2) / 6 * factor) / (attributes.Length * 2);

            foreach (var item in attributes)
            {
                int itemLengthForPosition = item.Length / 2;

                if (item.Length % 2 != 0)
                {
                    lengths.Add(workingArea - itemLengthForPosition);
                }
                else
                {
                    lengths.Add(workingArea - itemLengthForPosition);
                }
            }

            int _ = 0;
            Write("  ");

            foreach (var item in lengths)
            {
                Write("|");
                PaintOverTheArea(item - 1);
                Write(attributes[_]);
                PaintOverTheArea(item - (attributes[_].Length % 2));
                _++;
            }

            Write("|");
        }

        public static void PrintToolTip(string[] options, int factor)
        {
            ForegroundColor = ConsoleColor.Cyan;
            int workingArea = (WindowWidth - 2) / 6 * factor;
            int position = 2;
            foreach (var item in options)
            {
                SetCursorPosition(workingArea + 1, position);
                Write(item);

                position++;
            }

            ResetColor();
        }

        public static void PaintOverTheArea<T>(T obj)
        {
            if (obj is string)
            {
                string text = obj.ToString();
                for (int i = 0; i < text.Length; i++)
                {
                    Write(" ");
                }
            }
            else if (obj is int)
            {
                int g = Convert.ToInt32(obj);
                for (int i = 0; i < g; i++)
                {
                    Write(" ");
                }
            }
        }

        public static string GetHiddenInput()
        {
            string input = "";
            ConsoleKeyInfo key;

            do
            {
                key = ReadKey(true);

                if (
                    key.Key != ConsoleKey.Backspace &&
                    key.Key != ConsoleKey.Enter &&
                    key.Key != ConsoleKey.LeftArrow &&
                    key.Key != ConsoleKey.RightArrow &&
                    key.Key != ConsoleKey.UpArrow &&
                    key.Key != ConsoleKey.DownArrow &&
                    key.Key != ConsoleKey.Tab &&
                    key.Key != ConsoleKey.Delete &&
                    key.Key != ConsoleKey.F1 &&
                    key.Key != ConsoleKey.F2 &&
                    key.Key != ConsoleKey.F3 &&
                    key.Key != ConsoleKey.F4 &&
                    key.Key != ConsoleKey.F5 &&
                    key.Key != ConsoleKey.F6 &&
                    key.Key != ConsoleKey.F7 &&
                    key.Key != ConsoleKey.F8 &&
                    key.Key != ConsoleKey.F9 &&
                    key.Key != ConsoleKey.F10 &&
                    key.Key != ConsoleKey.F11 &&
                    key.Key != ConsoleKey.F12

                )
                {
                    input += key.KeyChar;
                    Write("*");
                }
                else if (key.Key == ConsoleKey.Backspace && input.Length > 0)
                {
                    input = input.Substring(0, (input.Length - 1));
                    Write("\b \b");
                }
            } while (key.Key != ConsoleKey.Enter);

            return input;
        }

        public static void Serialize<T>(T obj, string filePath)
        {
            string json = JsonConvert.SerializeObject(obj, Formatting.Indented);

            File.WriteAllText(filePath, json);
        }

        public static T Deserialize<T>(string filePath)
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                T obj = JsonConvert.DeserializeObject<T>(json);
                return obj;
            }
            else
            {
                WriteLine("Json по данному пути не существует");
                return default(T);
            }
        }

        public static void AdminWorking(List<User> users, string userName)
        {
            try
            {
                Admin admin = new Admin(users, userName);
                int choose;
                while (true)
                {
                    admin.Display(admin.users);
                    choose = ArrowMenu.Menu(3, admin.users.Count);
                    switch (choose)
                    {
                        case (int)Actions.NewElement:
                            admin.Create();
                            break;
                        case (int)Actions.BackToMenu:
                            return;
                        case (int)Actions.Search:
                            admin.Search();
                            break;
                        default:
                            admin.Read(choose);
                            break;
                    }
                }
            }
            catch (Exception)
            {
                List<User> _users = new List<User>();
                Admin admin = new Admin(_users, userName);
                int choose;
                while (true)
                {
                    admin.Display(users);
                    choose = ArrowMenu.Menu(3, users.Count);
                    switch (choose)
                    {
                        case (int)Actions.NewElement:
                            admin.Create();
                            break;
                        case (int)Actions.BackToMenu:
                            return;
                        case (int)Actions.Search:
                            admin.Search();
                            break;
                        default:
                            admin.Read(choose);
                            break;
                    }
                }
            }
        }

        public static void HRWorking(List<Employee> employees, string userName)
        {
            try
            {
                HR hr = new HR(employees, userName);
                int choose;
                while (true)
                {
                    hr.Display(hr.employees);
                    choose = ArrowMenu.Menu(3, hr.employees.Count);
                    switch (choose)
                    {
                        case (int)Actions.NewElement:
                            hr.Create();
                            break;
                        case (int)Actions.BackToMenu:
                            return;
                        case (int)Actions.Search:
                            hr.Search();
                            break;
                        default:
                            hr.Read(choose);
                            break;
                    }
                }
            }
            catch (Exception)
            {
                List<Employee> _employees = new List<Employee>();
                HR hr = new HR(_employees, userName);
                int choose;
                while (true)
                {
                    hr.Display(_employees);
                    choose = ArrowMenu.Menu(3, hr.employees.Count);
                    switch (choose)
                    {
                        case (int)Actions.NewElement:
                            hr.Create();
                            break;
                        case (int)Actions.BackToMenu:
                            return;
                        case (int)Actions.Search:
                            hr.Search();
                            break;
                        default:
                            hr.Read(choose);
                            break;
                    }
                }
            }
        }

        public static void StockManagerWorking(string userName)
        {
            try
            {
                List<Stock> stock = Deserialize<List<Stock>>("stockList.json");
                StockManager stockManager = new StockManager(stock, userName);
                int choose;
                while (true)
                {
                    stockManager.Display(stockManager.itemsInStock);
                    choose = ArrowMenu.Menu(3, stockManager.itemsInStock.Count);
                    switch (choose)
                    {
                        case (int)Actions.NewElement:
                            stockManager.Create();
                            break;
                        case (int)Actions.BackToMenu:
                            return;
                        case (int)Actions.Search:
                            stockManager.Search();
                            break;
                        default:
                            stockManager.Read(choose);
                            break;
                    }
                }
            }
            catch (Exception)
            {
                List<Stock> stock = new List<Stock>();
                StockManager stockManager = new StockManager(stock, userName);
                int choose;
                while (true)
                {
                    stockManager.Display(stock);
                    choose = ArrowMenu.Menu(3, stockManager.itemsInStock.Count);
                    switch (choose)
                    {
                        case (int)Actions.NewElement:
                            stockManager.Create();
                            break;
                        case (int)Actions.BackToMenu:
                            return;
                        case (int)Actions.Search:
                            stockManager.Search();
                            break;
                        default:
                            stockManager.Read(choose);
                            break;
                    }
                }
            }
        }

        public static void AccountantWorking(string userName)
        {
            try
            {
                List<Accounting> accounting = Deserialize<List<Accounting>>("accountingList.json");
                Accountant accountant = new Accountant(accounting, userName);
                int choose;
                while (true)
                {
                    accountant.Display(accountant.accounting);
                    choose = ArrowMenu.Menu(3, accountant.accounting.Count);
                    switch (choose)
                    {
                        case (int)Actions.NewElement:
                            accountant.Create();
                            break;
                        case (int)Actions.BackToMenu:
                            return;
                        case (int)Actions.Search:
                            accountant.Search();
                            break;
                        default:
                            accountant.Read(choose);
                            break;
                    }
                }
            }
            catch (Exception)
            {
                List<Accounting> accounting = new List<Accounting>();
                Accountant accountant = new Accountant(accounting, userName);
                int choose;
                while (true)
                {
                    accountant.Display(accounting);
                    choose = ArrowMenu.Menu(3, accountant.accounting.Count);
                    switch (choose)
                    {
                        case (int)Actions.NewElement:
                            accountant.Create();
                            break;
                        case (int)Actions.BackToMenu:
                            return;
                        case (int)Actions.Search:
                            accountant.Search();
                            break;
                        default:
                            accountant.Read(choose);
                            break;
                    }
                }
            }
        }

        public static void CashierWorking(string userName)
        {
            while (true)
            {
                var accounting = Deserialize<List<Accounting>>("accountingList.json");
                var itemsInStock = Deserialize<List<Stock>>("stockList.json");
                Cashier cashier = new Cashier(userName, accounting, itemsInStock);
                bool save = false;
                while (!save)
                {
                    cashier.Display(cashier.purchases);
                    int choose = ArrowMenu.Menu(3, itemsInStock.Count);

                    switch (choose)
                    {
                        case (int)Actions.Save:
                            cashier.SaveChanges();
                            save = true;
                            break;
                        case (int)Actions.BackToMenu:
                            return;
                        default:
                            cashier.ShowDescription(choose);
                            break;
                    }
                }
            }

        }
    }
}