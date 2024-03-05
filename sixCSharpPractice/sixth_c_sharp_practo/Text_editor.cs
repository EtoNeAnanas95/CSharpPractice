using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace sixth_c_sharp_practo
{
    public class TextEditor
    {
        string[] text;
        private int x;
        private int y;
        private string path;
        string extension;
        Figure figure = new Figure();

        public TextEditor(string path)
        {
            x = 0;
            y = 1;
            this.path = path;
            this.extension = Path.GetExtension(path).ToLower();

            switch (extension)
            {
                case ".txt":
                    this.text = File.ReadAllLines(path);
                    if (text.Length > 3)
                    {
                        Console.SetCursorPosition(0, 2);
                        int len = path.Length;
                        for (int i = 0; i < len; i++) Console.Write(" ");
                        Console.SetCursorPosition(0, 2);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Текстовый файл не соответсвует формату фигуры");
                        Console.SetCursorPosition(0, 12);
                        Console.ResetColor();
                        Environment.Exit(1);
                    }
                    else
                    {
                        try
                        {
                            this.figure.Name = this.text[0];
                            this.figure.Width = Convert.ToInt32(this.text[1]);
                            this.figure.Height = Convert.ToInt32(this.text[2]);
                        }catch (IndexOutOfRangeException) 
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.SetCursorPosition(0, 1);
                            Console.WriteLine("---------------------------------------------------------------------");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Текстовый файл не соответсвует формату фигуры");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.SetCursorPosition(0, 3);
                            Console.WriteLine("---------------------------------------------------------------------");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.SetCursorPosition(0, 5);
                            Console.WriteLine("Нажмите любую кнопку чтобы выйти");
                            ConsoleKey key = Console.ReadKey().Key;
                            Console.SetCursorPosition(0, 12);
                            Console.ResetColor();
                            Environment.Exit(1);
                        }

                    }
                    break;
                case ".json":
                    string json = File.ReadAllText(path);
                    this.figure = JsonConvert.DeserializeObject<Figure>(json);
                    break;
                case ".xml":
                    XmlSerializer serializer = new XmlSerializer(typeof(Figure));

                    using (FileStream fileStream = new FileStream(path, FileMode.Open))
                    {
                        this.figure = (Figure)serializer.Deserialize(fileStream);
                    }
                    break;
            }
        }
        public void Display()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("---------------------------------------------------------------------");
            Console.WriteLine($"Имя фигуры: {this.figure.Name}");
            Console.WriteLine($"Ширина фигуры: {this.figure.Width}");
            Console.WriteLine($"Высота фигуры: {this.figure.Height}");
            Console.WriteLine("---------------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Для выхода нажмите ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("ESCAPE");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Для сохранения нажмите ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("F1\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Для изменения текста нажмите ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("F2");
            Console.ResetColor();
        }


        public void Edit()
        {
            Console.Clear();
            Console.WriteLine("Выберети что вы хотите изменить");
            Console.WriteLine("1. Имя");
            Console.WriteLine("2. Ширина");
            Console.WriteLine("3. Высота");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("Введите новое имя: ");
                    this.figure.Name = Console.ReadLine();
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("Введите новую ширину: ");
                    this.figure.Width = Convert.ToInt32(Console.ReadLine());
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("Введите новую высоту: ");
                    this.figure.Height = Convert.ToInt32(Console.ReadLine());
                    break;
            }
        }
        public void Save()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Введите путь для сохранения (вместе с названием):");
            Console.WriteLine("-------------------------------------------------");
            Console.SetCursorPosition(0, 3);
            Console.WriteLine("-------------------------------------------------");
            Console.SetCursorPosition(0, 2);
            Console.ResetColor();
            string save_path = Console.ReadLine();
            string extension = Path.GetExtension(save_path).ToLower();



            switch (extension)
            {
                case ".txt":
                    using (StreamWriter outputFile = new StreamWriter(save_path))
                    {
                        foreach (string line in text)
                            outputFile.WriteLine(line);
                    }
                    break;
                case ".json":
                    string json = JsonConvert.SerializeObject(figure);
                    File.WriteAllText(save_path, json);
                    break;
                case ".xml":
                    XmlSerializer xml = new XmlSerializer(typeof(Figure));
                    using (FileStream fs = new FileStream(save_path, FileMode.OpenOrCreate))
                    {
                        xml.Serialize(fs, figure);
                    }
                    break;

            }
        }
    }
}
