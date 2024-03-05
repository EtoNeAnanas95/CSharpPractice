using ConsoleApp1.classes;
using ConsoleApp1.ENUM;
using ConsoleApp1.main;
using static ConsoleApp1.Function;
using static System.Console;

namespace ConsoleApp1.clients
{
    internal class HR : ICRUD
    {
        public List<Employee> employees;
        private readonly string userName;
        private const string usersPath = "employesList.json";

        public HR(List<Employee> employees, string userName)
        {
            this.employees = employees;
            this.userName = userName;
        }

        public void Create()
        {
            Clear();
            PrintHat(userName, "HR");
            ForegroundColor = ConsoleColor.Yellow;
            WriteLine("  ID: ");
            WriteLine("  Имя: ");
            WriteLine("  Фамилия: ");
            WriteLine("  Отчество: ");
            WriteLine("  Дата рождения: ");
            WriteLine("  Серия и номер паспорта: ");
            WriteLine("  ЗП: ");
            WriteLine("  Должность: ");

            string[] options = {"Подсказка!", "S - сохранить изменения", "ESCAPE - выйти из описания", "\tДолжности:", "", "1. Администратор", "2. HR", "3. Склад менеджер", "4. Бухгалтер", "5. Кассир" };
            PrintToolTip(options, 4);

            
            int newId = 0;
            string newName = null;
            string newSurname = null;
            string newMiddlename = null;
            DateOnly newBirthDate;
            int newPassportSeriesAndNunmber = 0;
            int newWage = 0;
            int newUserPost = 0;
            while (true)
            {
                int choose = ArrowMenu.Menu(2, 8);
                switch (choose)
                {
                    case 0:
                        CursorVisible = true;
                        SetCursorPosition(6, 2);
                        if (newId != 0) PaintOverTheArea(newId.ToString());
                        SetCursorPosition(6, 2);
                        newId = InputValidation(6, 2);
                        CursorVisible = false;
                        break;
                    case 1:
                        CursorVisible = true;
                        SetCursorPosition(7, 3);
                        if (newName != string.Empty) PaintOverTheArea(newName);
                        SetCursorPosition(7, 3);
                        newName = ReadLine();
                        CursorVisible = false;
                        break;
                    case 2:
                        CursorVisible = true;
                        SetCursorPosition(11, 4);
                        if (newSurname != string.Empty) PaintOverTheArea(newSurname);
                        SetCursorPosition(11, 4);
                        newSurname = ReadLine();
                        CursorVisible = false;
                        break;
                    case 3:
                        CursorVisible = true;
                        SetCursorPosition(12, 5);
                        if (newMiddlename != string.Empty) PaintOverTheArea(newMiddlename);
                        SetCursorPosition(12, 5);
                        newMiddlename = ReadLine();
                        CursorVisible = false;
                        break;
                    case 4:
                        CursorVisible = true;
                        SetCursorPosition(17, 6);
                        if (newBirthDate != default(DateOnly)) PaintOverTheArea(newBirthDate.ToString());
                        SetCursorPosition(17, 6);
                        newBirthDate = DateInputValidation(17, 6);
                        CursorVisible = false;
                        break;
                    case 5:
                        CursorVisible = true;
                        SetCursorPosition(26, 7);
                        if (newPassportSeriesAndNunmber != 0) PaintOverTheArea(newPassportSeriesAndNunmber.ToString());
                        SetCursorPosition(26, 7);
                        newPassportSeriesAndNunmber = InputValidation(26, 7);
                        CursorVisible = false;
                        break;
                    case 6:
                        CursorVisible = true;
                        SetCursorPosition(6, 8);
                        if (newWage != 0) PaintOverTheArea(newWage.ToString());
                        SetCursorPosition(6, 8);
                        newWage = InputValidation(6, 8);
                        CursorVisible = false;
                        break;
                    case 7:
                        CursorVisible = true;
                        SetCursorPosition(13, 9);
                        if (newUserPost != 0) PaintOverTheArea(newUserPost.ToString());
                        SetCursorPosition(13, 9);
                        newUserPost = InputValidation(13, 9);
                        CursorVisible = false;
                        break;
                    case (int)Actions.Save:
                        if (employees.Exists(employee => employee.id == newId))
                        {
                            SetCursorPosition(0, 11);
                            ForegroundColor = ConsoleColor.Red;
                            WriteLine("Такой айди уже существует!");
                        }
                        else if (
                            newId != 0 &&
                            !string.IsNullOrEmpty(newName) &&
                            !string.IsNullOrEmpty(newSurname) &&
                            !string.IsNullOrEmpty(newMiddlename) &&
                            newBirthDate != null && newBirthDate != default(DateOnly) &&
                            newPassportSeriesAndNunmber != 0 &&
                            newWage != 0 &&
                            newUserPost != 0
                            )
                        {
                            Employee newUser = new Employee(
                                newId,
                                newName,
                                newSurname,
                                newMiddlename,
                                newBirthDate,
                                newPassportSeriesAndNunmber,
                                newWage,
                                newUserPost
                            );
                            employees.Add(newUser);
                            Serialize(employees, usersPath);
                            string text = "Изменения успешно сохранены";
                            SetCursorPosition(WindowWidth / 2 - text.Length / 2, 7);
                            ForegroundColor = ConsoleColor.Green;
                            WriteLine(text);
                            Thread.Sleep(1000);
                            return;
                        }
                        else
                        {
                            SetCursorPosition(0, 11);
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
            if (obj is List<Employee> items)
            {
                Clear();
                PrintHat(userName, "HR");

                string[] attributes = {"ID","Имя","Фамилия","Отчество","ДР","ПД","ЗП","Должность"};
                string[] options = { "Подсказка!", "F1 - Добавить запись", "F2 - Найти запись", "ENTER - открыть описание" };

                ForegroundColor = ConsoleColor.Yellow;
                PrintAttributes(attributes, 5);
                PrintToolTip(options, 5);

                int _ = 3;
                foreach (var item in items)
                {
                    string[] attributesForPrint =
                    {
                        item.id.ToString(), 
                        item.name, 
                        item.surname, 
                        item.middlename, 
                        item.birthDate.ToString(), 
                        item.passportSeriesAndNunmber.ToString(), 
                        item.wage.ToString(), 
                        item.post.ToString()
                    };
                    SetCursorPosition(0, _);
                    PrintAttributes(attributesForPrint, 5);
                    WriteLine();
                    _++;
                }
            }
            else if (obj is Employee item1)
            {
                List<Employee> employees = new List<Employee>();
                employees.Add(item1);
                
                Clear();
                PrintHat(userName, "HR");

                string[] attributes = {"ID","Фамилия","Имя","Отчество","ДР","ПД","ЗП","Должность"};
                string[] options = {"Подсказка!", "S - сохранить изменения", "ESCAPE - выйти из описания", "\tДолжности:", "", "1. Администратор", "2. HR", "3. Склад менеджер", "4. Бухгалтер", "5. Кассир" };

                ForegroundColor = ConsoleColor.Yellow;
                PrintAttributes(attributes, 5);
                PrintToolTip(options, 5);

                int _ = 3;
                foreach (var item in employees)
                {
                    string[] attributesForPrint =
                    {
                        item.id.ToString(), 
                        item.name, 
                        item.surname, 
                        item.middlename, 
                        item.birthDate.ToString(), 
                        item.passportSeriesAndNunmber.ToString(), 
                        item.wage.ToString(), 
                        item.post.ToString()
                    };
                    SetCursorPosition(0, _);
                    PrintAttributes(attributesForPrint, 5);
                    WriteLine();
                    _++;
                }
            }
            
        }

        private void printToolTip()
        {
            Clear();
            PrintHat(userName, "HR");
            ForegroundColor = ConsoleColor.Yellow;

            string[] attributes = {"ID","Фамилия","Имя","Отчество","ДР","ПД","ЗП","Должность"};
            string[] options = { "ESCAPE - выход из меню", "ENTER - выбрать фильтр", "\tДолжности:", "", "1. Администратор", "2. HR", "3. Склад менеджер", "4. Бухгалтер", "5. Кассир" };

            ForegroundColor = ConsoleColor.Yellow;
            PrintAttributes(attributes, 4);
            PrintToolTip(options, 4);
        }

        public void Search()
        {
            Clear();
            PrintHat(userName, "HR");
            ForegroundColor= ConsoleColor.Yellow;
            WriteLine("Выберите фильтр поиска:");
            WriteLine("  ID: ");
            WriteLine("  Имя: ");
            WriteLine("  Фамилия: ");
            WriteLine("  Отчество: ");
            WriteLine("  Дата рождения: ");
            WriteLine("  Серия и номер паспорта: ");
            WriteLine("  ЗП: ");
            WriteLine("  Должность: ");

            string[] options = { "ESCAPE - выход из меню", "ENTER - выбрать фильтр", "\tДолжности:", "", "1. Администратор", "2. HR", "3. Склад менеджер", "4. Бухгалтер", "5. Кассир" };
            PrintToolTip(options, 4);

            while (true)
            {
                int choose = ArrowMenu.Menu(3, 8);
                switch (choose)
                {
                    case (int)Actions.BackToMenu:
                        return;
                    case 0:
                        SetCursorPosition(0, 14);
                        WriteLine("Введите значение: ");
                        CursorVisible = true;
                        int searchingInt = InputValidation(18, 14);
                        CursorVisible = false;

                        int foundUser = employees.FindIndex(employees => employees.id == searchingInt);

                        printToolTip();

                        Display(employees[foundUser]);

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
                        SetCursorPosition(0, 14);
                        WriteLine("Введите значение: ");
                        CursorVisible = true;
                        string searching = ReadLine();
                        CursorVisible = false;

                        var foundUsers = employees.FindAll(employees => employees.name == searching);
                        
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
                                    int findUseIndex = employees.FindIndex(accounting => accounting.id == foundUsers[choose].id);
                                    Read(findUseIndex);
                                    return;
                            }
                        }
                    case 2:
                        SetCursorPosition(0, 14);
                        WriteLine("Введите значение: ");
                        CursorVisible = true;
                        searching = ReadLine();
                        CursorVisible = false;

                        foundUsers = employees.FindAll(employees => employees.surname == searching);
                        
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
                                    int findUseIndex = employees.FindIndex(accounting => accounting.id == foundUsers[choose].id);
                                    Read(findUseIndex);
                                    return;
                            }
                        }
                    case 3:
                        SetCursorPosition(0, 14);
                        WriteLine("Введите значение: ");
                        CursorVisible = true;
                        searching = ReadLine();
                        CursorVisible = false;

                        foundUsers = employees.FindAll(employees => employees.middlename == searching);
                        
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
                                    int findUseIndex = employees.FindIndex(accounting => accounting.id == foundUsers[choose].id);
                                    Read(findUseIndex);
                                    return;
                            }
                        }
                    case 4:
                        SetCursorPosition(0, 14);
                        WriteLine("Введите значение: ");
                        CursorVisible = true;
                        searching = DateInputValidation(18, 14).ToString();
                        CursorVisible = false;

                        foundUsers = employees.FindAll(employees => employees.birthDate.ToString() == searching);

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
                                    int findUseIndex = employees.FindIndex(accounting => accounting.id == foundUsers[choose].id);
                                    Read(findUseIndex);
                                    return;
                            }
                        }
                    case 5:
                        SetCursorPosition(0, 14);
                        WriteLine("Введите значение: ");
                        CursorVisible = true;
                        searchingInt = InputValidation(18, 14);
                        CursorVisible = false;

                        foundUsers = employees.FindAll(employees => employees.passportSeriesAndNunmber == searchingInt);

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
                                    int findUseIndex = employees.FindIndex(accounting => accounting.id == foundUsers[choose].id);
                                    Read(findUseIndex);
                                    return;
                            }
                        }
                    case 6:
                        SetCursorPosition(0, 8);
                        WriteLine("Введите значение: ");
                        CursorVisible = true;
                        searchingInt = InputValidation(18, 14);
                        CursorVisible = false;

                        foundUsers = employees.FindAll(employees => employees.wage == searchingInt);

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
                                    int findUseIndex = employees.FindIndex(accounting => accounting.id == foundUsers[choose].id);
                                    Read(findUseIndex);
                                    return;
                            }
                        }
                    case 7:
                        SetCursorPosition(0, 14);
                        WriteLine("Введите значение: ");
                        CursorVisible = true;
                        searchingInt = InputValidation(18, 14);
                        CursorVisible = false;

                        foundUsers = employees.FindAll(employees => employees.post == searchingInt);

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
                                    int findUseIndex = employees.FindIndex(accounting => accounting.id == foundUsers[choose].id);
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
            if (employees.Count == 0 || userIndex < 0 || userIndex >= employees.Count) return;
            PrintHat(userName, "HR");

            ForegroundColor = ConsoleColor.Yellow;
            Write("  ID: ");
            ForegroundColor = ConsoleColor.White;
            WriteLine(employees[userIndex].id);
            ForegroundColor = ConsoleColor.Yellow;
            Write("  Имя: ");
            ForegroundColor = ConsoleColor.White;
            WriteLine(employees[userIndex].name);
            ForegroundColor = ConsoleColor.Yellow;
            Write("  Фамилия: ");
            ForegroundColor = ConsoleColor.White;
            WriteLine(employees[userIndex].surname);
            ForegroundColor = ConsoleColor.Yellow;
            Write("  Отчество: ");
            ForegroundColor = ConsoleColor.White;
            WriteLine(employees[userIndex].middlename);
            ForegroundColor = ConsoleColor.Yellow;
            Write("  Дата рождения: ");
            ForegroundColor = ConsoleColor.White;
            WriteLine(employees[userIndex].birthDate);
            ForegroundColor = ConsoleColor.Yellow;
            Write("  Серия и номер паспорта: ");
            ForegroundColor = ConsoleColor.White;
            WriteLine(employees[userIndex].passportSeriesAndNunmber);
            ForegroundColor = ConsoleColor.Yellow;
            Write("  ЗП: ");
            ForegroundColor = ConsoleColor.White;
            WriteLine(employees[userIndex].wage);
            ForegroundColor = ConsoleColor.Yellow;
            Write("  Должность: ");
            ForegroundColor = ConsoleColor.White;
            WriteLine(employees[userIndex].post);
            
            string[] options = { "Подсказка!", "S - сохранить изменения", "ESCAPE - выйти из описания", "ENTER - изменить", "DEL - удалить пользователя", "", "\tДолжности:", "", "1. Администратор", "2. HR", "3. Склад менеджер", "4. Бухгалтер", "5. Кассир" };
            PrintToolTip(options, 4);

            List<Employee> employeesHistory = employees.Select(Employee => (Employee)Employee.Clone()).ToList();
            
            Update(employeesHistory, userIndex);
            
        }

        public void Delete<T>(T obj, int userIndex)
        {
            if (obj is List<Employee>)
            {
                employees.Remove(employees[userIndex]);
                Serialize(employees, usersPath);
                string text = "Сотрудник успешно удалён";
                SetCursorPosition(WindowWidth / 2 - text.Length / 2, 7);
                ForegroundColor = ConsoleColor.Red;
                WriteLine(text);
                Thread.Sleep(1000);
            }
        }

        public void Update<T>(T obj, int userIndex)
        {
            if (obj is List<Employee> employeesHistory)
            {
                while (true)
                {

                    int choose = ArrowMenu.Menu(2, 8);
                    switch (choose)
                    {
                        case 0:
                            CursorVisible = true;
                            SetCursorPosition(6, 2);
                            PaintOverTheArea(employeesHistory[userIndex].id.ToString());
                            SetCursorPosition(6, 2);
                            employeesHistory[userIndex].id = InputValidation(6, 2);
                            CursorVisible = false;
                            break;
                        case 1:
                            CursorVisible = true;
                            SetCursorPosition(7, 3);
                            PaintOverTheArea(employeesHistory[userIndex].name);
                            SetCursorPosition(7, 3);
                            employeesHistory[userIndex].name = ReadLine();
                            CursorVisible = false;
                            break;
                        case 2:
                            CursorVisible = true;
                            SetCursorPosition(11, 4);
                            PaintOverTheArea(employeesHistory[userIndex].surname);
                            SetCursorPosition(11, 4);
                            employeesHistory[userIndex].surname = ReadLine();
                            CursorVisible = false;
                            break;
                        case 3:
                            CursorVisible = true;
                            SetCursorPosition(12, 5);
                            PaintOverTheArea(employeesHistory[userIndex].middlename);
                            SetCursorPosition(12, 5);
                            employeesHistory[userIndex].middlename = ReadLine();
                            CursorVisible = false;
                            break;
                        case 4:
                            CursorVisible = true;
                            SetCursorPosition(17, 6);
                            PaintOverTheArea(employeesHistory[userIndex].birthDate.ToString());
                            SetCursorPosition(17, 6);
                            employeesHistory[userIndex].birthDate = DateInputValidation(17, 6);
                            CursorVisible = false;
                            break;
                        case 5:
                            CursorVisible = true;
                            SetCursorPosition(26, 7);
                            PaintOverTheArea(employeesHistory[userIndex].passportSeriesAndNunmber.ToString());
                            SetCursorPosition(26, 7);
                            employeesHistory[userIndex].passportSeriesAndNunmber = InputValidation(26, 7);
                            CursorVisible = false;
                            break;
                        case 6:
                            CursorVisible = true;
                            SetCursorPosition(6, 8);
                            PaintOverTheArea(employeesHistory[userIndex].wage.ToString());
                            SetCursorPosition(6, 8);
                            employeesHistory[userIndex].wage = InputValidation(6, 8);
                            CursorVisible = false;
                            break;
                        case 7:
                            CursorVisible = true;
                            SetCursorPosition(13, 9);
                            PaintOverTheArea(employeesHistory[userIndex].post.ToString());
                            SetCursorPosition(13, 9);
                            employeesHistory[userIndex].post = InputValidation(13, 9);
                            CursorVisible = false;
                            break;
                        case (int)Actions.Save:
                            if (employees.Exists(employee => employee.id == employeesHistory[userIndex].id))
                            {
                                SetCursorPosition(0, 11);
                                ForegroundColor = ConsoleColor.Red;
                                WriteLine("Такой айди уже существует!");
                            }
                            if (employeesHistory[userIndex].id != 0 &&
                                !string.IsNullOrEmpty(employeesHistory[userIndex].name) &&
                                !string.IsNullOrEmpty(employeesHistory[userIndex].surname) &&
                                !string.IsNullOrEmpty(employeesHistory[userIndex].middlename) &&
                                employeesHistory[userIndex].birthDate != default(DateOnly) &&
                                employeesHistory[userIndex].passportSeriesAndNunmber != 0 &&
                                employeesHistory[userIndex].wage != 0 &&
                                employeesHistory[userIndex].post != 0)
                            {
                                employees = employeesHistory;
                                Serialize(employees, usersPath);
                                string text = "Изменения успешно сохранены";
                                SetCursorPosition(WindowWidth / 2 - text.Length / 2, 7);
                                ForegroundColor = ConsoleColor.Green;
                                WriteLine(text);
                                Thread.Sleep(1000);
                                return;
                            }
                            else
                            {
                                SetCursorPosition(0, 11);
                                ForegroundColor = ConsoleColor.Red;
                                WriteLine("Вы не ввели значения!");
                            }
                            break;
                        case (int)Actions.BackToMenu:
                            return;
                        case (int)Actions.Delete:
                            Delete(employees, userIndex);
                            return;

                    }
                }
            }
        }
    }
}
