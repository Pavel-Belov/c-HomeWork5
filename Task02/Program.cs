// Показать числа Фибоначчи

Console.Clear();

Console.Write("Введите количество чисел Фибоначчи: ");
int count = int.Parse(Console.ReadLine()!);

int[] arrayFib = new int[count];
arrayFib[0] = 0;
arrayFib[1] = 1;

for (int i = 2; i <= arrayFib.Length - 1; i++)
{
    arrayFib[i] = arrayFib[i - 1] + arrayFib[i - 2];
}

Console.WriteLine($"Числа Фибоначчи: {String.Join(" ", arrayFib)}");