// Найти точку пересечения двух прямых заданных уравнением y = k1 * x + b1, y = k2 * x + b2, b1 k1 и b2 и k2 заданы

Console.Clear();

Console.Write("Введите k1: ");
int k1 = int.Parse(Console.ReadLine()!);
Console.Write("Введите b1: ");
int b1 = int.Parse(Console.ReadLine()!);
Console.Write("Введите k2: ");
int k2 = int.Parse(Console.ReadLine()!);
Console.Write("Введите b2: ");
int b2 = int.Parse(Console.ReadLine()!);

//-- данный блок для удовста чтения формул прямых в консоли
string b1Sign = "";
string b2Sign = "";
int b1ConsoleWrite = b1;
int b2ConsoleWrite = b2;

if (b1 > 0)
{
    b1Sign = "+";
}
else
{
    b1Sign = "-";
    b1ConsoleWrite = -b1;
}

if (b2 > 0)
{
    b2Sign = "+";
}
else
{
    b2ConsoleWrite = -b2;
    b2Sign = "-";
}
//-- конец блока

// прямые пересекаются в точке, если k1 не равно k2, иначе они параллельны
int xCross = 0;
int yCross = 0;

if (k1 != k2)
{
    xCross = (b2 - b1) / (k1 - k2);
    yCross = (k1 * b2 - b1 * k2) / (k1 - k2);
    Console.WriteLine($"Прямые y = {k1} * x {b1Sign} {b1ConsoleWrite} и y = {k2} * x {b2Sign} {b2ConsoleWrite} пересекаются в точке ({xCross}, {yCross})");
}
else
{
    if (b1 == b2)
        Console.WriteLine($"Прямые y = {k1} * x {b1Sign} {b1ConsoleWrite} и y = {k2} * x {b2Sign} {b2ConsoleWrite} совпадают");
    else
        Console.WriteLine($"Прямые y = {k1} * x {b1Sign} {b1ConsoleWrite} и y = {k2} * x {b2Sign} {b2ConsoleWrite} параллельны и не пересекаются");
}