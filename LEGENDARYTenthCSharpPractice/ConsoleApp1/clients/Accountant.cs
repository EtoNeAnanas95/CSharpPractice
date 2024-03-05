using ConsoleApp1.classes;
using ConsoleApp1.ENUM;
using ConsoleApp1.main;
using static ConsoleApp1.Function;
using static System.Console;

namespace ConsoleApp1.clients
{
    public class Accountant : ICRUD
    {
        public List<Accounting> accounting;
        private readonly string userName;
        private const string accountingPath = "accountingList.json";
        private int total;

        public Accountant(List<Accounting> accounting, string userName)
        {
            this.accounting = accounting;
            this.userName = userName;
        }

        public void Create()
        {
            Clear();
            DateOnly newOperationDate = DateOnly.FromDateTime(DateTime.Today);
            PrintHat(userName, "Бухгалтер");
            ForegroundColor = ConsoleColor.Yellow;
            if (accounting.Count != 0) WriteLine($"  ID {accounting[accounting.Count-1].id + 1}");
            else WriteLine("  ID 1");
            WriteLine("  Название: ");
            WriteLine("  Сумма: ");
            WriteLine($"  Время: {newOperationDate}");
            WriteLine("  Прибавка?: true");

            string[] options =
            {
                "Подсказка!",
                "S - сохранить изменения",
                "ESCAPE - выйти из описания",
                "\tПрибавка:",
                "false/true"
            };
            PrintToolTip(options, 4);
            string nameOperation = null;
            int newSum = 0;
            bool newGain = true;
            while (true)
            {
                int choose = ArrowMenu.Menu(3, 4);
                switch (choose)
                {
                    case 0:
                        CursorVisible = true;
                        SetCursorPosition(12, 3);
                        if (nameOperation != string.Empty) PaintOverTheArea(nameOperation);
                        SetCursorPosition(12, 3);
                        nameOperation = ReadLine();
                        CursorVisible = false;
                        break;
                    case 1:
                        CursorVisible = true;
                        SetCursorPosition(9, 4);
                        if (newSum != 0) PaintOverTheArea(newSum.ToString());
                        SetCursorPosition(9, 4);
                        newSum = InputValidation(9, 4);
                        CursorVisible = false;
                        break;
                    case 2:
                        CursorVisible = true;
                        SetCursorPosition(9, 5);
                        if (newOperationDate != default(DateOnly)) PaintOverTheArea(newOperationDate.ToString());
                        SetCursorPosition(9, 5);
                        newOperationDate = DateInputValidation(9, 5);
                        CursorVisible = false;
                        break;
                    case 3:
                        CursorVisible = true;
                        SetCursorPosition(13, 6);
                        PaintOverTheArea(newGain.ToString());
                        SetCursorPosition(13, 6);
                        newGain = BoolValidation(13, 6);
                        CursorVisible = false;
                        break;
                    case (int)Actions.Save:
                        if (
                            nameOperation != string.Empty &&
                            newSum > 0
                            )
                        {
                            Accounting newaccounting;
                            if (!newGain) newSum *= -1;
                            if (accounting.Count != 0)
                            {
                                newaccounting = new Accounting(
                                accounting[accounting.Count - 1].id + 1,
                                nameOperation,
                                newSum,
                                newOperationDate,
                                newGain
                                );
                            }
                            else
                            {
                                newaccounting = new Accounting(
                                1,
                                nameOperation,
                                newSum,
                                newOperationDate,
                                newGain
                                );
                            }
                            accounting.Add(newaccounting);
                            Serialize(accounting, accountingPath);
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
            if (obj is List<Accounting> accounting1)
            {
                Clear();
                
                
                PrintHat(userName, "Бухгалтер");

                string[] attributes = { "ID", "Название", "Сумма", "Время", "Прибавка?" };
                string[] options = { "Подсказка!", "F1 - Добавить запись", "F2 - Найти запись", "ENTER - открыть описание" };

                ForegroundColor = ConsoleColor.Yellow;
                PrintAttributes(attributes, 5);
                PrintToolTip(options, 5);

                int _ = 3;
                foreach (var item in accounting1)
                {
                    string[] attributesForPrint =
                    {
                        item.id.ToString(), 
                        item.nameOperation, 
                        item.sum.ToString(), 
                        item.operationDate.ToString(), 
                        item.gain.ToString()
                    };
                    SetCursorPosition(0, _);
                    PrintAttributes(attributesForPrint, 5);
                    WriteLine();
                    _++;
                }

                total = 0;
                foreach (var item in accounting) total += item.sum;

                
                ForegroundColor = ConsoleColor.Yellow;
                attributes = new[] {"-----------------", "-----------------", "-----------------", "-----------------", "-----------------"};
                PrintAttributes(attributes, 5);
                WriteLine();
                ForegroundColor = ConsoleColor.Green;
                attributes = new[] {"", "", "","", $"ИТОГО: {total}"};
                PrintAttributes(attributes, 5);

            }
            else if (obj is Accounting accounting)
            {
                List<Accounting> accounting2 = new List<Accounting>();
                accounting2.Add(accounting);

                Clear();
                PrintHat(userName, "Бухгалтер");

                string[] attributes = { "ID", "Название", "Сумма", "Время", "Прибавка?" };
                string[] options = { "Подсказка!", "F1 - Добавить запись", "F2 - Найти запись", "ENTER - открыть описание" };

                ForegroundColor = ConsoleColor.Yellow;
                PrintAttributes(attributes, 5);
                PrintToolTip(options, 5);

                int _ = 3;
                foreach (var item in accounting2)
                {
                    string[] attributesForPrint =
                    {
                        item.id.ToString(), 
                        item.nameOperation, 
                        item.sum.ToString(), 
                        item.operationDate.ToString(), 
                        item.gain.ToString()
                    };
                    SetCursorPosition(0, _);
                    PrintAttributes(attributesForPrint, 5);
                    WriteLine();
                    _++;
                }
                
                total = 0;
                foreach (var item in accounting2) total += item.sum;

                
                ForegroundColor = ConsoleColor.Yellow;
                attributes = new[] {"-----------------", "-----------------", "-----------------", "-----------------", "-----------------"};
                PrintAttributes(attributes, 5);
                WriteLine();
                ForegroundColor = ConsoleColor.Green;
                attributes = new[] {"", "", "","", $"ИТОГО: {total}"};
                PrintAttributes(attributes, 5);
            }
            else if (obj is List<Accounting>)
            {
                Clear();
                PrintHat(userName, "Бухгалтер");

                string[] attributes = { "ID", "Название", "Сумма", "Время", "Прибавка?" };
                string[] options = { "Подсказка!", "F1 - Добавить запись", "F2 - Найти запись", "ENTER - открыть описание" };

                ForegroundColor = ConsoleColor.Yellow;
                PrintAttributes(attributes, 5);
                PrintToolTip(options, 5);

                total = 0;
                
                ForegroundColor = ConsoleColor.Yellow;
                attributes = new[] {"-----------------", "-----------------", "-----------------", "-----------------", "-----------------"};
                PrintAttributes(attributes, 5);
                WriteLine();
                ForegroundColor = ConsoleColor.Green;
                attributes = new[] {"", "", "","", $"ИТОГО: {total}"};
                PrintAttributes(attributes, 5);
            }
        }

        private void printToolTip()
        {
            Clear();
            PrintHat(userName, "Бухгалтер");

            string[] attributes = { "ID", "Название", "Сумма", "Время", "Прибавка?" };
            string[] options = { "F1 - Добавить запись", "F2 - Найти запись", "ENTER - открыть описание" };

            ForegroundColor = ConsoleColor.Yellow;
            PrintAttributes(attributes, 5);
            PrintToolTip(options, 5);
        }

        public void Search()
        {
            Clear();
            PrintHat(userName, "Бухгалтер");
            ForegroundColor = ConsoleColor.Yellow;
            WriteLine($"  ID: ");
            WriteLine("  Название: ");
            WriteLine("  Сумма: ");
            WriteLine("  Время: ");
            WriteLine("  Прибавка?: ");

            string[] options = new string[] { "Подсказка!", "ESCAPE - выйти", "ENTER - открыть описание" };
            PrintToolTip(options, 4);

            while (true)
            {
                int choose =
                    ArrowMenu.Menu(2, 5);
                switch (choose)
                {
                    case (int)Actions.BackToMenu:
                        return;
                    case 0:
                        SetCursorPosition(0, 8);
                        WriteLine("Введите значение: ");
                        CursorVisible = true;
                        int searchingInt = InputValidation(18, 8);
                        CursorVisible = false;

                        int foundUser = accounting.FindIndex(item => item.id == searchingInt);

                        printToolTip();

                        Display(accounting[foundUser]);

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
                                    Read(choose);
                                    return;
                            }
                        }

                        return;
                    case 1: 
                        SetCursorPosition(0, 8);
                        WriteLine("Введите значение: ");
                        CursorVisible = true;
                        string searching = ReadLine();
                        CursorVisible = false;

                        var foundItems = accounting.FindAll(employees => employees.nameOperation == searching);
                        
                        printToolTip();

                        Display(foundItems);

                        choose = ArrowMenu.Menu(3, foundItems.Count);
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
                                    int findUseIndex = accounting.FindIndex(accounting => accounting.id == foundItems[choose].id);
                                    Read(findUseIndex);
                                    return;
                            }
                        }
                        return;
                    case 2: 
                        SetCursorPosition(0, 8);
                        WriteLine("Введите значение: ");
                        CursorVisible = true;
                        searchingInt = InputValidation(18, 8);
                        CursorVisible = false;

                        foundItems = accounting.FindAll(employees => employees.sum == searchingInt);
                        
                        printToolTip();

                        Display(foundItems);

                        choose = ArrowMenu.Menu(3, foundItems.Count);
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
                                    int findUseIndex = accounting.FindIndex(accounting => accounting.id == foundItems[choose].id);
                                    Read(findUseIndex);
                                    return;
                            }
                        }
                        return;
                    case 3: 
                        SetCursorPosition(0, 8);
                        WriteLine("Введите значение: ");
                        CursorVisible = true;
                        var searchingDate = DateInputValidation(18, 8);
                        CursorVisible = false;

                        foundItems = accounting.FindAll(employees => employees.operationDate.ToString() == searchingDate.ToString());
                        
                        printToolTip();

                        Display(foundItems);

                        choose = ArrowMenu.Menu(3, foundItems.Count);
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
                                    int findUseIndex = accounting.FindIndex(accounting => accounting.id == foundItems[choose].id);
                                    Read(findUseIndex);
                                    return;
                            }
                        }
                        return;
                    case 4: 
                        SetCursorPosition(0, 8);
                        WriteLine("Введите значение: ");
                        CursorVisible = true;
                        bool searchingGain = BoolValidation(18, 8);
                        CursorVisible = false;

                        foundItems = accounting.FindAll(employees => employees.gain == searchingGain);
                        
                        printToolTip();

                        Display(foundItems);

                        choose = ArrowMenu.Menu(3, foundItems.Count);
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
                                    int findUseIndex = accounting.FindIndex(accounting => accounting.id == foundItems[choose].id);
                                    Read(findUseIndex);
                                    return;
                            }
                        }
                        return;
                }
            }
        }

        public void Read(int userIndex)
        {
            Clear();
            if (accounting.Count == 0 || userIndex < 0 || userIndex >= accounting.Count) return;
            

            PrintHat(userName, "Бухгалтер");
            ForegroundColor = ConsoleColor.Yellow;
            Write("  ID ");
            ForegroundColor = ConsoleColor.White;
            WriteLine(accounting[userIndex].id.ToString());
            ForegroundColor = ConsoleColor.Yellow;
            Write("  Название: ");
            ForegroundColor = ConsoleColor.White;
            WriteLine(accounting[userIndex].nameOperation);
            ForegroundColor = ConsoleColor.Yellow;
            Write("  Сумма: ");
            ForegroundColor = ConsoleColor.White;
            WriteLine(accounting[userIndex].sum.ToString());
            ForegroundColor = ConsoleColor.Yellow;
            Write("  Время: ");
            ForegroundColor = ConsoleColor.White;
            WriteLine(accounting[userIndex].operationDate.ToString());
            ForegroundColor = ConsoleColor.Yellow;
            Write("  Прибавка?: ");
            ForegroundColor = ConsoleColor.White;
            WriteLine(accounting[userIndex].gain.ToString());

            string[] options =
            {
                "Подсказка!", "S - сохранить изменения", "ESCAPE - выйти из описания", "ENTER - изменить",
                "DEL - удалить пользователя"
            };
            PrintToolTip(options, 4);

            List<Accounting> accountingHistory = accounting.Select(user => (Accounting)user.Clone()).ToList();

            Update(accountingHistory, userIndex);

        }

        public void Delete<T>(T obj, int userIndex)
        {
            if (obj is List<Accounting>)
            {
                accounting.Remove(accounting[userIndex]);
                Serialize(accounting, accountingPath);
                string text = "Операция успешно удалёна";
                SetCursorPosition(WindowWidth / 2 - text.Length / 2, 7);
                ForegroundColor = ConsoleColor.Red;
                WriteLine(text);
                Thread.Sleep(1000);
            }
        }

        public void Update<T>(T obj, int userIndex)
        {
            if (obj is List<Accounting> accountingHistory)
            {
                while (true)
                {
                    int choose = ArrowMenu.Menu(3, 4);
                    SetCursorPosition(0, 7);
                    PaintOverTheArea("Вы не ввели значения для логина или пароля!");

                    switch (choose)
                    {
                        case 0:
                        CursorVisible = true;
                        SetCursorPosition(12, 3);
                        PaintOverTheArea(accountingHistory[userIndex].nameOperation);
                        SetCursorPosition(12, 3);
                        accountingHistory[userIndex].nameOperation = ReadLine();
                        CursorVisible = false;
                        break;
                    case 1:
                        CursorVisible = true;
                        SetCursorPosition(9, 4);
                        PaintOverTheArea(accountingHistory[userIndex].sum.ToString());
                        SetCursorPosition(9, 4);
                        accountingHistory[userIndex].sum = InputValidation(9, 4);
                        CursorVisible = false;
                        break;
                    case 2:
                        CursorVisible = true;
                        SetCursorPosition(9, 5);
                        PaintOverTheArea(accountingHistory[userIndex].operationDate.ToString());
                        SetCursorPosition(9, 5);
                        accountingHistory[userIndex].operationDate = DateInputValidation(9, 5);
                        CursorVisible = false;
                        break;
                    case 3:
                        CursorVisible = true;
                        SetCursorPosition(13, 6);
                        PaintOverTheArea(accountingHistory[userIndex].gain.ToString());
                        SetCursorPosition(13, 6);
                        accountingHistory[userIndex].gain = BoolValidation(13, 6);
                        CursorVisible = false;
                        break;
                    case (int)Actions.Save:
                        if (
                            accountingHistory[userIndex].nameOperation != string.Empty &&
                            accountingHistory[userIndex].sum > 0
                            )
                        {
                            accounting = accountingHistory;
                            Serialize(accounting, accountingPath);
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
                            Delete(accounting, userIndex);
                            return;
                    }
                }
            }
        }

    }
}