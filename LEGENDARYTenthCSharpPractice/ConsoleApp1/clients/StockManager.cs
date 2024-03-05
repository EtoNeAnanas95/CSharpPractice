using ConsoleApp1.classes;
using ConsoleApp1.ENUM;
using ConsoleApp1.main;
using static ConsoleApp1.Function;
using static System.Console;


namespace ConsoleApp1.clients
{
    public class StockManager : ICRUD
    {
        public List<Stock> itemsInStock;
        private readonly string userName;
        private const string itemsInStockPath = "stockList.json";

        public StockManager(List<Stock> itemsInStock, string userName)
        {
            this.itemsInStock = itemsInStock;
            this.userName = userName;
        }

        public void Create()
        {
            Clear();
            PrintHat(userName, "Склад менеджер");
            ForegroundColor = ConsoleColor.Yellow;
            if (itemsInStock.Count != 0) WriteLine($"  ID {itemsInStock[itemsInStock.Count-1].id + 1}");
            else WriteLine("  ID 1");
            WriteLine("  Имя: ");
            WriteLine("  Кол-во: ");
            WriteLine("  Цена: ");

            string[] options =
            {
                "Подсказка!", "S - сохранить изменения", "ESCAPE - выйти из описания"
            };
            PrintToolTip(options, 4);
            string newProductName = null;
            int newQuantityProductd = -1;
            int newPriceOne = 0;
            while (true)
            {
                int choose = ArrowMenu.Menu(3, 3);
                switch (choose)
                {
                    case 0:
                        CursorVisible = true;
                        SetCursorPosition(7, 3);
                        if (newProductName != string.Empty) PaintOverTheArea(newProductName);
                        SetCursorPosition(7, 3);
                        newProductName = ReadLine();
                        CursorVisible = false;
                        break;
                    case 1:
                        CursorVisible = true;
                        SetCursorPosition(10, 4);
                        if (newQuantityProductd != -1) PaintOverTheArea(newQuantityProductd.ToString());
                        SetCursorPosition(10, 4);
                        newQuantityProductd = InputValidation(10, 4);
                        CursorVisible = false;
                        break;
                    case 2:
                        CursorVisible = true;
                        SetCursorPosition(8, 5);
                        if (newPriceOne != 0) PaintOverTheArea(newPriceOne.ToString());
                        SetCursorPosition(8, 5);
                        newPriceOne = InputValidation(8, 5);
                        CursorVisible = false;
                        break;
                    case (int)Actions.Save:
                        if (
                            newProductName != string.Empty &&
                            newQuantityProductd >= 0 &&
                            newPriceOne != 0)
                        {
                            Stock newitemsInStock;
                            if (itemsInStock.Count != 0)
                            {
                                newitemsInStock = new Stock(
                                itemsInStock[itemsInStock.Count - 1].id + 1,
                                newProductName,
                                newQuantityProductd,
                                newPriceOne
                                );
                            }
                            else
                            {
                                newitemsInStock = new Stock(
                                1,
                                newProductName,
                                newQuantityProductd,
                                newPriceOne
                                );
                            }
                            itemsInStock.Add(newitemsInStock);
                            Serialize(itemsInStock, itemsInStockPath);
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
            if (obj is List<Stock> itemsInStock1)
            {
                Clear();
                PrintHat(userName, "Склад менеджер");

                string[] attributes = { "ID", "Имя", "Кол-во", "Цена" };
                string[] options = { "Подсказка!", "F1 - Добавить запись", "F2 - Найти запись", "ENTER - открыть описание" };

                PrintAttributes(attributes, 5);
                PrintToolTip(options, 5);

                int _ = 3;
                foreach (var item in itemsInStock1)
                {
                    string[] attributesForPrint =
                    {
                        item.id.ToString(), 
                        item.productName, 
                        item.quantityProduct.ToString(), 
                        item.priceOne.ToString()
                    };
                    SetCursorPosition(0, _);
                    PrintAttributes(attributesForPrint, 5);
                    WriteLine();
                    _++;
                }
            }
            else if (obj is Stock Stock)
            {
                List<Stock> itemsInStock2 = new List<Stock>();
                itemsInStock2.Add(Stock);

                Clear();
                PrintHat(userName, "Склад менеджер");

                string[] attributes = { "ID", "Имя", "Кол-во", "Цена" };
                string[] options = { "Подсказка!", "F1 - Добавить запись", "F2 - Найти запись", "ENTER - открыть описание" };

                PrintAttributes(attributes, 5);
                PrintToolTip(options, 5);

                int _ = 3;
                foreach (var item in itemsInStock2)
                {
                    string[] attributesForPrint =
                    {
                        item.id.ToString(), 
                        item.productName, 
                        item.quantityProduct.ToString(), 
                        item.priceOne.ToString()
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
            PrintHat(userName, "Склад менеджер");

            string[] attributes = { "ID", "Имя", "Кол-во", "Цена" };
            string[] options = { "F1 - Добавить запись", "F2 - Найти запись", "ENTER - открыть описание" };

            PrintAttributes(attributes, 5);
            PrintToolTip(options, 5);
        }

        public void Search()
        {
            Clear();
            PrintHat(userName, "Склад менеджер");
            ForegroundColor = ConsoleColor.Yellow;
            WriteLine("  ID: ");
            WriteLine("  Имя: ");
            WriteLine("  Кол-во: ");
            WriteLine("  Цена: ");

            string[] options = new string[] { "Подсказка!", "ESCAPE - выйти", "ENTER - открыть описание" };
            PrintToolTip(options, 4);

            while (true)
            {
                int choose = ArrowMenu.Menu(2, 4);
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

                        int foundUser = itemsInStock.FindIndex(item => item.id == searchingInt);

                        printToolTip();

                        Display(itemsInStock[foundUser]);

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
                        string searching = ReadLine();
                        CursorVisible = false;

                        var foundItems = itemsInStock.FindAll(employees => employees.productName == searching);
                        
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
                                    int findUseIndex = itemsInStock.FindIndex(accounting => accounting.id == foundItems[choose].id);
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

                        foundItems = itemsInStock.FindAll(employees => employees.quantityProduct == searchingInt);

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
                                    int findUseIndex = itemsInStock.FindIndex(accounting => accounting.id == foundItems[choose].id);
                                    Read(findUseIndex);
                                    return;
                            }
                        }
                        return;
                    case 3:
                        SetCursorPosition(0, 8);
                        WriteLine("Введите значение: ");
                        CursorVisible = true;
                        searchingInt = InputValidation(18, 8);
                        CursorVisible = false;

                        foundItems = itemsInStock.FindAll(employees => employees.priceOne == searchingInt);

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
                                    int findUseIndex = itemsInStock.FindIndex(accounting => accounting.id == foundItems[choose].id);
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
            if (itemsInStock.Count == 0 || userIndex < 0 || userIndex >= itemsInStock.Count) return;

            PrintHat(userName, "Склад менеджер");
            ForegroundColor = ConsoleColor.Yellow;
            Write("  ID ");
            ForegroundColor = ConsoleColor.White;
            WriteLine(itemsInStock[userIndex].id);
            ForegroundColor = ConsoleColor.Yellow;
            Write("  Имя: ");
            ForegroundColor = ConsoleColor.White;
            WriteLine(itemsInStock[userIndex].productName);
            ForegroundColor = ConsoleColor.Yellow;
            Write("  Кол-во: ");
            ForegroundColor = ConsoleColor.White;
            WriteLine(itemsInStock[userIndex].quantityProduct.ToString());
            ForegroundColor = ConsoleColor.Yellow;
            Write("  Цена: ");
            ForegroundColor = ConsoleColor.White;
            WriteLine(itemsInStock[userIndex].priceOne.ToString());

            string[] options =
            {
                "Подсказка!", "S - сохранить изменения", "ESCAPE - выйти из описания", "ENTER - изменить",
                "DEL - удалить пользователя"
            };
            PrintToolTip(options, 4);

            List<Stock> itemsInStockHistory = itemsInStock.Select(user => (Stock)user.Clone()).ToList();

            Update(itemsInStockHistory, userIndex);

        }

        public void Delete<T>(T obj, int userIndex)
        {
            if (obj is List<Stock>)
            {
                itemsInStock.Remove(itemsInStock[userIndex]);
                Serialize(itemsInStock, itemsInStockPath);
                string text = "Товар успешно удалён";
                SetCursorPosition(WindowWidth / 2 - text.Length / 2, 7);
                ForegroundColor = ConsoleColor.Red;
                WriteLine(text);
                Thread.Sleep(1000);
            }
        }

        public void Update<T>(T obj, int userIndex)
        {
            if (obj is List<Stock> itemsInStockHistory)
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
                            SetCursorPosition(7, 3);
                            PaintOverTheArea(itemsInStockHistory[userIndex].productName);
                            SetCursorPosition(7, 3);
                            itemsInStockHistory[userIndex].productName = ReadLine();
                            CursorVisible = false;
                            break;
                        case 1:
                            CursorVisible = true;
                            SetCursorPosition(10, 4);
                            PaintOverTheArea(itemsInStockHistory[userIndex].quantityProduct.ToString());
                            SetCursorPosition(10, 4);
                            itemsInStockHistory[userIndex].quantityProduct = InputValidation(10, 4);
                            CursorVisible = false;
                            break;
                        case 2:
                            CursorVisible = true;
                            SetCursorPosition(8, 5);
                            PaintOverTheArea(itemsInStockHistory[userIndex].priceOne.ToString());
                            SetCursorPosition(8, 5);
                            itemsInStockHistory[userIndex].priceOne = InputValidation(8, 5);
                            CursorVisible = false;
                            break;
                        case (int)Actions.Save:
                            if (
                                itemsInStockHistory[userIndex].productName != string.Empty &&
                                itemsInStockHistory[userIndex].quantityProduct >= 0 &&
                                itemsInStockHistory[userIndex].priceOne != 0)
                            {
                                string text = "Изменения успешно сохранены";
                                SetCursorPosition(WindowWidth / 2 - text.Length / 2, 7);
                                ForegroundColor = ConsoleColor.Green;
                                WriteLine(text);
                                itemsInStock = itemsInStockHistory;
                                Serialize(itemsInStock, itemsInStockPath);
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
                            Delete(itemsInStock, userIndex);
                            return;
                    }
                }
            }
        }

    }
}