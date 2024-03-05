using ConsoleApp1.classes;
using ConsoleApp1.ENUM;
using static System.Console;
using static ConsoleApp1.Function;

namespace ConsoleApp1.main
{
    internal static class authorization
    {
        const string usersPath = "usersList.json";
        const string employesPath = "employesList.json";

        public static void chekExistNeededFiles()
        {
            if (!File.Exists(usersPath))
            {
                User adm = new User(1, "admin", "1", 1);
                List<User> _ = new List<User>();
                _.Add(adm);
                Serialize(_, usersPath);
            }
        }
        public static User chekAuthorization(List<User> users, string login, string password)
        {
            foreach (User user in users)
            {
                if (user.login == login && user.password == password)
                {
                    return user;
                }
            }
            return null;
        }

        public static void Authorization()
        {
            while (true)
            {
                Clear();
                ResetColor();
                PrintHat("в Добрый икея и точка");
                ForegroundColor = ConsoleColor.Yellow;
                WriteLine("  Логин: ");
                WriteLine("  Пароль: ");
                ForegroundColor = ConsoleColor.Green;
                WriteLine("  Авторизоваться!");
                string password = null;
                string login = null;
                bool chek = true;
                while (chek)
                {
                    int chooseAction = ArrowMenu.Menu(2, 3);
                    SetCursorPosition(2, 4);
                    PaintOverTheArea("Неверный логин или пароль");
                    SetCursorPosition(0, 4);
                    ForegroundColor = ConsoleColor.Green;
                    WriteLine("  Авторизоваться!");
                    ResetColor();
                    switch (chooseAction)
                    {
                        case 0:
                            CursorVisible = true;
                            SetCursorPosition(9, 2);
                            if (login != null) PaintOverTheArea(login);
                            SetCursorPosition(9, 2);
                            login = ReadLine();
                            CursorVisible = false;
                            break;
                        case 1:
                            CursorVisible = true;
                            SetCursorPosition(10, 3);
                            if (password != null) PaintOverTheArea(password);
                            SetCursorPosition(10, 3);
                            password = GetHiddenInput();
                            CursorVisible = false;
                            break;
                        case 2:
                            if (login != null && password != null)
                            {
                                List<User> users = Deserialize<List<User>>(usersPath);
                                User mainUser = chekAuthorization(users, login, password);
                                List<Employee> empoloyes;
                                if (mainUser != null)
                                {
                                    string userName = mainUser.login;
                                    if (File.Exists(employesPath))
                                    {
                                        empoloyes = Deserialize<List<Employee>>(employesPath);

                                        foreach (Employee employee in empoloyes)
                                        {
                                            if (employee.id == mainUser.id)
                                            {
                                                userName = employee.name;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        empoloyes = new List<Employee>();
                                        Serialize(empoloyes, employesPath);
                                    }
                                    switch (mainUser.post)
                                    {
                                        case (int)Posts.Administrator:
                                            AdminWorking(users, userName);
                                            break;
                                        case (int)Posts.HR:
                                            HRWorking(empoloyes, userName);
                                            break;
                                        case (int)Posts.StockManager:
                                            StockManagerWorking(userName);
                                            break;
                                        case (int)Posts.Accountant:
                                            AccountantWorking(userName);
                                            break;
                                        case (int)Posts.Cashier:
                                            CashierWorking(userName);
                                            break;
                                    }
                                }
                                else
                                {
                                    ForegroundColor = ConsoleColor.Red;
                                    SetCursorPosition(2, 4);
                                    PaintOverTheArea("  Авторизоваться!");
                                    SetCursorPosition(2, 4);
                                    WriteLine("Неверный логин или пароль");
                                    SetCursorPosition(9, 2);
                                    PaintOverTheArea(login);
                                    SetCursorPosition(10, 3);
                                    PaintOverTheArea(password);
                                    Thread.Sleep(400);
                                }
                            }
                            else
                            {
                                ForegroundColor = ConsoleColor.Magenta;
                                SetCursorPosition(2, 4);
                                PaintOverTheArea("  Авторизоваться!");
                                SetCursorPosition(2, 5);
                                WriteLine("Заполните логин и пароль)");
                                Thread.Sleep(400);
                            }
                            chek = false;
                            break;
                    }
                }
            }
        }
    }
}
