
int[] massive = new int[] { 12, 2, 0, -4, 5, 60, 7 };


int[] newmassive = massive.Where(item => item > 1).ToArray();

int i = 0;
Console.ForegroundColor = ConsoleColor.Green;
Console.Write("минимальные числа в массиве это -- ");
Console.ForegroundColor = ConsoleColor.Red;

foreach (int item in newmassive)
{
    Console.Write(newmassive[i]+ " "); ;
    i++;
}

Console.ResetColor();









