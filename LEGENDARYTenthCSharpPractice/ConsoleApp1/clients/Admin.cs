using ConsoleApp1.classes;
using ConsoleApp1.ENUM;
using ConsoleApp1.main;
using static ConsoleApp1.Function;
using static System.Console;

namespace ConsoleApp1.clients
{
    internal class Admin : ICRUD
    {
        public List<User> users;
        private readonly string userName;
        private const string usersPath = "usersList.json";

        public Admin(List<User> users, string userName)
        {
            this.users = users;
            this.userName = userName;
        }

        public void Create()
        {
            Clear();
            PrintHat(userName, "Администратор");
            ForegroundColor = ConsoleColor.Yellow;
            if (users.Count != 0) WriteLine($"  ID {users[users.Count-1].id + 1}");
            else WriteLine("  ID 1");
            WriteLine("  Логин: ");
            WriteLine("  Пароль: ");
            WriteLine("  Должность: ");

            string[] options = {"Подсказка!", "S - сохранить изменения", "ESCAPE - выйти из описания", "\tДолжности:", "", "1. Администратор", "2. HR", "3. Склад менеджер", "4. Бухгалтер", "5. Кассир" };
            PrintToolTip(options, 4);

            string newUserLogin = null;
            string newUserPassword = null;
            int newUserPost = 0;
            while (true)
            {
                int choose = ArrowMenu.Menu(3, 3);
                switch (choose)
                {
                    case 0:
                        CursorVisible = true;
                        SetCursorPosition(9, 3);
                        if (newUserLogin != string.Empty) PaintOverTheArea(newUserLogin);
                        SetCursorPosition(9, 3);
                        newUserLogin = ReadLine();
                        CursorVisible = false;
                        break;
                    case 1:
                        CursorVisible = true;
                        SetCursorPosition(10, 4);
                        if (newUserPassword != string.Empty) PaintOverTheArea(newUserPassword);
                        SetCursorPosition(10, 4);
                        newUserPassword = ReadLine();
                        CursorVisible = false;
                        break;
                    case 2:
                        CursorVisible = true;
                        SetCursorPosition(13, 5);
                        if (newUserPost <= 0 && newUserPost > 5) PaintOverTheArea(newUserPost.ToString());
                        SetCursorPosition(13, 5);
                        newUserPost = InputValidation(13, 5);
                        CursorVisible = false;
                        break;
                    case (int)Actions.Save:
                        if (users.Exists(user => user.login == newUserLogin))
                        {
                            SetCursorPosition(0, 6);
                            ForegroundColor = ConsoleColor.Red;
                            WriteLine("Такой логин уже существует!");
                        }
                        else if (newUserLogin != string.Empty && newUserPassword != string.Empty && newUserPost > 0 && newUserPost <= 5)
                        {
                            User newUser = new User(
                                users[users.Count-1].id + 1,
                                newUserLogin, 
                                newUserPassword, 
                                newUserPost
                                );
                            users.Add(newUser);
                            Serialize(users, usersPath);
                            string text = "Изменения успешно сохранены";
                            SetCursorPosition(WindowWidth / 2 - text.Length / 2, 7);
                            ForegroundColor = ConsoleColor.Green;
                            WriteLine(text);
                            Thread.Sleep(1000);
                            return;
                        }
                        else
                        {
                            SetCursorPosition(0, 6);
                            ForegroundColor = ConsoleColor.Red;
                            WriteLine("Вы не ввели значения!");
                        }
                        break;
                    case (int)Actions.BackToMenu:
                        return;
                }
            }
        }

        public void Display<T>(T obj)
        {
            if (obj is List<User> users1)
            {
                Clear();
                PrintHat(userName, "Администартор");

                string[] attributes = {"ID", "Логин", "Пароль", "Должность"};
                string[] options = {"Подсказка!", "F1 - Добавить запись", "F2 - Найти запись", "ENTER - открыть описание"};

                ForegroundColor = ConsoleColor.Yellow;
                PrintAttributes(attributes, 4);
                ResetColor();
                PrintToolTip(options, 4);

                int _ = 3;
                foreach (var item in users1)
                {
                    string[] attributesForPrint = {item.id.ToString(), item.login, item.password, item.post.ToString()};
                    SetCursorPosition(0, _);
                    PrintAttributes(attributesForPrint, 4);
                    WriteLine();
                    _++;
                }
            }
            else if (obj is User user)
            {
                List<User> users2 = new List<User>();
                users2.Add(user);
                
                Clear();
                ReadLine();
                PrintHat(userName, "Администартор");

                string[] attributes = {"ID", "Логин", "Пароль", "Должность"};
                string[] options = {"Подсказка!", "F1 - Добавить запись", "F2 - Найти запись", "ENTER - открыть описание"};

                PrintAttributes(attributes, 4);
                PrintToolTip(options, 4);

                int _ = 3;
                foreach (var item in users2)
                {
                    string[] attributesForPrint = {item.id.ToString(), item.login, item.password, item.post.ToString()};
                    SetCursorPosition(0, _);
                    PrintAttributes(attributesForPrint, 4);
                    WriteLine();
                    _++;
                }
            }
        }

        private void printToolTip()
        {
            Clear();
            PrintHat(userName, "Администартор");

            string[] attributes = { "ID", "Логин", "Пароль", "Должность" };
            string[] options = { "F1 - Добавить запись", "F2 - Найти запись", "ENTER - открыть описание" };

            PrintAttributes(attributes, 4);
            PrintToolTip(options, 4);
        }

        public void Search()
        {
            Clear();
            PrintHat(userName, "Администартор");
            ForegroundColor= ConsoleColor.Yellow;
            WriteLine("Выберите фильтр поиска:");
            WriteLine("  ID");
            WriteLine("  Логин");
            WriteLine("  Пароль");
            WriteLine("  Должность");

            string[] options = new string[] {"Подсказка!", "ESCAPE - выйти", "ENTER - открыть описание" };
            PrintToolTip(options, 4);

            while (true)
            {
                int choose = ArrowMenu.Menu(3, 4);
                switch (choose)
                {
                    case (int)Actions.BackToMenu:
                        return;
                    case 0:
                        SetCursorPosition(0, 8);
                        WriteLine("Введите значение: ");
                        CursorVisible = true;
                        int searchingId = InputValidation(18, 8);
                        CursorVisible = false;

                        int foundUser = users.FindIndex(user => user.id == searchingId);

                        printToolTip();

                        Display(users[foundUser]);

                        choose = ArrowMenu.Menu(3, 1);
                        switch (choose)
                        {
                            case (int)Actions.BackToMenu:
                                return;
                            default:
                                Read(foundUser);
                                break;
                        }
                        return;
                    case 1:
                        SetCursorPosition(0, 8);
                        WriteLine("Введите значение: ");
                        CursorVisible = true;
                        string searchingLogin = ReadLine();
                        CursorVisible = false;

                        foundUser = users.FindIndex(user => user.login == searchingLogin);
                        
                        printToolTip();

                        Display(users[foundUser]);

                        choose = ArrowMenu.Menu(3, 1);
                        switch (choose)
                        {
                            case (int)Actions.BackToMenu:
                                return;
                            default:
                                Read(foundUser);
                                break;
                        }
                        return;
                    case 2:
                        SetCursorPosition(0, 8);
                        WriteLine("Введите значение: ");
                        CursorVisible = true;
                        string searchingPassword = ReadLine();
                        CursorVisible = false;

                        var foundUsers = users.FindAll(user => user.password == searchingPassword);
                        
                        printToolTip();

                        Display(foundUsers);

                        choose = ArrowMenu.Menu(3, 1);
                        while (true)
                        {
                            switch (choose)
                            {
                                case (int)Actions.BackToMenu:
                                    return;
                                case (int)Actions.NewElement:
                                case (int)Actions.Save:
                                case (int)Actions.Delete:
                                case (int)Actions.Search:
                                    break;
                                default:
                                    int findUseIndex = users.FindIndex(accounting => accounting.id == foundUsers[choose].id);
                                    Read(findUseIndex);
                                    return;
                            }
                        }
                    case 3:
                        SetCursorPosition(0, 8);
                        WriteLine("Введите значение: ");
                        CursorVisible = true;
                        int searchingPost = InputValidation(18, 8);
                        CursorVisible = false;

                        foundUsers = users.FindAll(user => user.post == searchingPost);

                        printToolTip();
                        
                        Display(foundUsers);

                        choose = ArrowMenu.Menu(3, foundUsers.Count);
                        while (true)
                        {
                            switch (choose)
                            {
                                case (int)Actions.BackToMenu:
                                    return;
                                case (int)Actions.NewElement:
                                case (int)Actions.Save:
                                case (int)Actions.Delete:
                                case (int)Actions.Search:
                                    break;
                                default:
                                    int findUseIndex = users.FindIndex(accounting => accounting.id == foundUsers[choose].id);
                                    Read(findUseIndex);
                                    return;
                            }
                        }
                }
            }
        }

        public void Read(int userIndex)
        {
            Clear();
            if (userIndex < 0 || userIndex >= users.Count) return;

            PrintHat(userName, "Администартор");
            ForegroundColor = ConsoleColor.Yellow;
            Write("  ID ");
            ForegroundColor = ConsoleColor.White;
            WriteLine(users[userIndex].id);
            ForegroundColor = ConsoleColor.Yellow;
            Write("  Логин: ");
            ForegroundColor = ConsoleColor.White;
            WriteLine(users[userIndex].login);
            ForegroundColor = ConsoleColor.Yellow;
            Write("  Пароль: ");
            ForegroundColor = ConsoleColor.White;
            WriteLine(users[userIndex].password);
            ForegroundColor = ConsoleColor.Yellow;
            Write("  Должность: ");
            ForegroundColor = ConsoleColor.White;
            WriteLine(users[userIndex].post);

            string[] options = { "Подсказка!", "S - сохранить изменения", "ESCAPE - выйти из описания", "ENTER - изменить", "DEL - удалить пользователя", "", "\tДолжности:", "", "1. Администратор", "2. HR", "3. Склад менеджер", "4. Бухгалтер", "5. Кассир" };
            PrintToolTip(options, 4);

            List<User> usersHistory = users.Select(user => (User)user.Clone()).ToList();
            
            Update(usersHistory, userIndex);
            
        }

        public void Delete<T>(T obj, int userIndex)
        {
            if (obj is List<User>)
            {
                users.Remove(users[userIndex]);
                Serialize(users, usersPath);
                string text = "Пользователь успешно удалён";
                SetCursorPosition(WindowWidth / 2 - text.Length / 2, 7);
                ForegroundColor = ConsoleColor.Red;
                WriteLine(text);
                Thread.Sleep(1000);
            }
        }

        public void Update<T>(T obj, int userIndex)
        {
            if (obj is List<User> usersHistory)
            {
                while (true)
                {
                    int choose = ArrowMenu.Menu(3, 3);
                    SetCursorPosition(0, 7);
                    PaintOverTheArea("Вы не ввели значения для логина или пароля!");

                    switch (choose)
                    {
                        case 0:
                            CursorVisible = true;
                            SetCursorPosition(9, 3);
                            PaintOverTheArea(usersHistory[userIndex].login);
                            SetCursorPosition(9, 3);
                            usersHistory[userIndex].login = ReadLine();
                            CursorVisible = false;
                            break;
                        case 1:
                            CursorVisible = true;
                            SetCursorPosition(10, 4);
                            PaintOverTheArea(usersHistory[userIndex].password);
                            SetCursorPosition(10, 4);
                            usersHistory[userIndex].password = ReadLine();
                            CursorVisible = false;
                            break;
                        case 2:
                            CursorVisible = true;
                            SetCursorPosition(13, 5);
                            PaintOverTheArea(usersHistory[userIndex].post.ToString());
                            SetCursorPosition(13, 5);
                            usersHistory[userIndex].post = InputValidation(13, 5);
                            CursorVisible = false;
                            break;
                        case (int)Actions.Save:
                            if (users.Exists(user => user.login == usersHistory[userIndex].login))
                            {
                                SetCursorPosition(0, 6);
                                ForegroundColor = ConsoleColor.Red;
                                WriteLine("Такой логин уже существует!");
                            }
                            else if (
                                usersHistory[userIndex].login != string.Empty &&
                                usersHistory[userIndex].password != string.Empty &&
                                usersHistory[userIndex].post > 0 &&
                                usersHistory[userIndex].post <= 5
                                )
                            {
                                users = usersHistory;
                                Serialize(users, usersPath);
                                string text = "Изменения успешно сохранены";
                                SetCursorPosition(WindowWidth / 2 - text.Length / 2, 7);
                                ForegroundColor = ConsoleColor.Green;
                                WriteLine(text);
                                Thread.Sleep(1000);
                                return;
                            }
                            else
                            {
                                SetCursorPosition(0, 7);
                                ForegroundColor = ConsoleColor.Red;
                                WriteLine("Вы не ввели значения!");
                            }
                            break;
                        case (int)Actions.BackToMenu:
                            return;
                        case (int)Actions.Delete:
                            Delete(users, userIndex);
                            return;
                    }
                }
            }
        }
    }
}
