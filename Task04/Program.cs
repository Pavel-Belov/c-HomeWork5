// Написать программу копирования массива

int[] CreateArray(int length, int minimum, int maximum)
{
    int[] array = new int[length];
    Random random = new Random();

    for (int i = 0; i < length; i++)
        array[i] = random.Next(minimum, maximum + 1);

    return array;
}

void PrintArray(int[] array)
{
    foreach (int element in array)
        Console.Write(element + " ");
    Console.WriteLine();
}

int[] CopyArray(int[] array)
{
    int[] copiedArray = array;
    return copiedArray;
}

int EnterValue(string message)
{
    Console.Write(message);
    return int.Parse(Console.ReadLine()!);
}

Console.Clear();

int length = EnterValue("Введите длину массива: ");
int minimum = EnterValue("Введите минимальное значение элемета массива: ");
int maximum = EnterValue("Введите максимальное значение элемента массива: ");

int[] array = CreateArray(length, minimum, maximum);
Console.Write("Исходый массив: ");
PrintArray(array);

int[] copiedArray = CopyArray(array);
Console.Write("Скопированный массив: ");
PrintArray(copiedArray);