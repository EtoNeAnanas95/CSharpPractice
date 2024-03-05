using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class ExplorerEditor
    {
        public static void CreateDirectory(FileSystemInfo directory)
        {
            Console.Clear();
            Console.WriteLine("Введите название папки: ");
            string directoryName = Console.ReadLine();
            string directoryPath = Path.Combine(directory.FullName, directoryName);
            Directory.CreateDirectory(directoryPath);
        }

        public static void CreateFile(FileSystemInfo directory)
        {
            Console.Clear();
            Console.WriteLine("Введите название файла(вместе с его типом): ");
            string fileName = Console.ReadLine();
            string directoryPath = Path.Combine(directory.FullName, fileName);
            File.Create(directoryPath);
        }

        public static void Delete(FileSystemInfo objectForDelete)
        {
            if (objectForDelete is DirectoryInfo) Directory.Delete(objectForDelete.FullName);
            else if (objectForDelete is FileInfo) File.Delete(objectForDelete.FullName);
        }

        public static void OpenFile(FileInfo file)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = file.FullName,
                WorkingDirectory = null,
                UseShellExecute = true
            };

            try
            {
                Process.Start(startInfo);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        public static void OpenFolder(DirectoryInfo mainDirectory)
        {
            int wait;
            do
            {
                Console.Clear();
                FileSystemInfo[] items = mainDirectory.GetFileSystemInfos();

                function.PrintHat(mainDirectory.Name);
                int i = 4;
                foreach (var item in items)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.SetCursorPosition(128, i);
                    Console.Write("|");
                    Console.ResetColor();
                    Console.SetCursorPosition(0, i);
                    Console.Write($"  {item.Name}");
                    function.PrintSpace(item);
                    Console.WriteLine(item.CreationTime);
                    i++;
                }
                wait = Menu.ArrowMenuMain(mainDirectory);
            }
            while (wait != -1);
        }

        public static void Open(FileSystemInfo item)
        {
            if (item is DirectoryInfo directory) OpenFolder(directory);
            else if (item is FileInfo file) OpenFile(file);
        }
    }
}
