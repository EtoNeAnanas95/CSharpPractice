using static System.Console;

namespace ConsoleApp1.main
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CursorVisible = false;
            authorization.chekExistNeededFiles();
            authorization.Authorization();
            ReadLine();
        }
    }
}