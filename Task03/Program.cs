// Написать программу масштабирования фигуры

//Тут для тех кто далеко улетел, чтобы задавались вершины фигуры списком (одной строкой)
//например: "(0,0) (2,0) (2,2) (0,2)"
//коэффициент масштабирования k задавался отдельно - 2 или 4 или 0.5
//В результате показать координаты, которые получатся.
//при k = 2 получаем "(0,0) (4,0) (4,4) (0,4)"

int EnterInt(string message)
{
    Console.Write(message);
    return int.Parse(Console.ReadLine()!);
}

string EnterString(string message)
{
    Console.WriteLine(message);
    return Console.ReadLine()!;
}

double EnterK(string message)
{
    Console.Write(message);
    return double.Parse(Console.ReadLine().Replace('.', ','));
}

void CreateRandomShape(int vertices, double[] shape)
{
    Random random = new Random();

    for (int i = 0; i < shape.Length; i++)
    {
        shape[i] = random.Next(10);
        // проверяем, нет ли точно такой же вершины из уже созданных
        // проверка начинается когда создана вторая вершина
        if (i > 1 && i % 2 != 0)
        {
            // если x,y-координаты вершины равны x,y-координатам какой-либо из уже созданных,
            // то генерируем новые координаты для текущей вершины
            for (int j = 1; j <= i - 2; j++)
            {
                while(shape[j] == shape[i] && shape[j - 1] == shape[i - 1])
                {
                    shape[i] = random.Next(10);
                    shape[i - 1] = random.Next(10);
                }
            }
        }
    }
}

double[] CreateShapeFromString(string shape)
{
    // в данном методе преобразовываем введённые координаты вершин
    // в массив из числовых координат, где чётные элементы - x-координаты вершин,
    // а нечётные - y-координаты вершин
    shape = shape.Replace("(", "").Replace(")", "").Replace(",", "").Replace(" ", "");
    double[] resultFigure = new double[shape.Length];

    for (int i = 0; i < shape.Length; i++)
        resultFigure[i] = double.Parse(shape[i].ToString());
    return resultFigure;
}

double[] SearchShapeCenter(double[] shape)
{
    // В данном методе находим центр фигуры,
    // для этого вписываем фигуру в прямоугольник
    // и находим его центр
    double minX = shape[0];
    double minY = shape[1];
    double maxX = shape[0];
    double maxY = shape[1];

    for (int i = 0; i < shape.Length; i += 2)
    {
        if (i % 2 == 0)
        {
            if (shape[i] < minX)
                minX = shape[i];
            if (shape[i] > maxX)
                maxX = shape[i];
        }
        else
        {
            if (shape[i] < minY)
                minY = shape[i];
            if (shape[i] > maxY)
                maxY = shape[i];
        }
    }

    double centerX = maxX - ((maxX - minX) / 2);
    double centerY = maxY - ((maxY - minY) / 2);
    return new double[2]{centerX, centerY};
}

void ScaleShape(double[] shape, double k)
{
    // Данный метод масштабирует фигуру с центром масштабирования в начале координат (0,0)
    for (int i = 0; i < shape.Length; i++)
        shape[i] *= k;
}

double[] MoveScaledShape(double[] scaledShape, double[] shapeCenter, double[] scaledShapeCenter)
{
    // а данном методе мы перемещаем вершины отмасштабированной из центра координат фигуры
    // в центр изначальной фигуры, и получаем координаты вершин отмасштабированной фигуры
    // будьте внимательны, данный метод вызывается после метода ScaleShape()
    double stepX = scaledShapeCenter[0] - shapeCenter[0];
    double stepY = scaledShapeCenter[1] - shapeCenter[1];

     for (int i = 0; i < scaledShape.Length; i += 2)
     {
        scaledShape[i] -= stepX;
     }

     for (int i = 1; i < scaledShape.Length; i += 2)
     {
        scaledShape[i] -= stepY;
     }

     return scaledShape;
}

void PrintShape(double[] shape)
{
    // данный метов выводи в консоль вершины фигуры в виде (x1,y1) (x2,y2) ... (xn,yn)
    for (int i = 0; i < shape.Length; i ++)
    {
        if (i % 2 == 0)
            Console.Write($"({shape[i].ToString().Replace(',', '.')},");
        else
            Console.Write($"{shape[i].ToString().Replace(',', '.')}) ");
    }
    Console.WriteLine();
}

Console.Clear();
Console.WriteLine("Выьерите вариант решения:");
Console.WriteLine("Введите 1. Если хотите, чтобы вершины фигуры генерировались случайным образом");
Console.WriteLine("Введите 2. Если хотите вручную ввести координаты вершин фигуры");
int solution = EnterInt("Выбор варианта решения: ");

if (solution == 1)
{
    // задаём количество вершин для фигуры
    int vertices = EnterInt("Задайте количество вершин фигуры: ");
    double[] shape = new double[vertices * 2];
    // генерируем фигуру со случайными вершинами
    // в чётные элементы массива записываются x-координаты вершин
    // в нечётные элементы массива записываются y-координаты вершин
    CreateRandomShape(vertices, shape);
    Console.WriteLine("Вершины случайон сгенерированной фигуры: ");
    PrintShape(shape);
    // находим центр фигуры
    double[] centerOfShape = SearchShapeCenter(shape);
    // задаём коэффициент масштабирования
    double k = EnterK("Задайте коэффициент масштабирования k: ");
    // масштабируем фигуру, масштабирование фигуры происходит из центра координат (0,0)
    ScaleShape(shape, k);
    // находим центр отмасштабированной фигуры
    double[] centerOfScaledShape = SearchShapeCenter(shape);
    // перемещаем отмасштабированную из центра координат фигуру в центр изначальной фигуры
    // и рассчитываем вершины отмасштабированной фигуры
    double[] scaledShape = MoveScaledShape(shape, centerOfShape, centerOfScaledShape);
    Console.WriteLine($"Получаем вершины фигуры в масштабе k = {k}: ");
    PrintShape(scaledShape);
}
else if (solution == 2)
{
    // вручную задаём вершины фигуры в виде (x1,y1) (x2,y2) ... (xn,yn)
    string figureStr = EnterString("Введите координаты вершин фигуры в виде (x1,y1) (x2,y2) ... (xn,yn): ");
    // преобразовываем эти вершины из string в double
    // в чётные элементы массива записываются x-координаты вершин
    // в нечётные элементы массива записываются y-координаты вершин
    double[] shape = CreateShapeFromString(figureStr);
    Console.WriteLine("Вершины заданной фигуры: ");
    PrintShape(shape);
    // находим центр фигуры
    double[] centerOfShape = SearchShapeCenter(shape);
    // задаём коэффициент масштабирования
    double k = EnterK("Задайте коэффициент масштабирования k: ");
    // масштабируем фигуру, масштабирование фигуры происходит из центра координат (0,0)
    ScaleShape(shape, k);
    // находим центр отмасштабированной фигуры
    double[] centerOfScaledShape = SearchShapeCenter(shape);
    // перемещаем отмасштабированную из центра координат фигуру в центр изначальной фигуры
    // и рассчитываем вершины отмасштабированной фигуры
    double[] scaledShape = MoveScaledShape(shape, centerOfShape, centerOfScaledShape);
    Console.WriteLine($"Получаем вершины фигуры в масштабе k = {k}: ");
    PrintShape(scaledShape);
}
else
{
    Console.WriteLine("Ошибка! Вы не выбрали вариант решения задачи. Введите либо 1, либо 2");
    Console.ReadLine();
}