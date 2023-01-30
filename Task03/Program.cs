// Написать программу масштабирования фигуры

//Тут для тех кто далеко улетел, чтобы задавались вершины фигуры списком (одной строкой)
//например: "(0,0) (2,0) (2,2) (0,2)"
//коэффициент масштабирования k задавался отдельно - 2 или 4 или 0.5
//В результате показать координаты, которые получатся.
//при k = 2 получаем "(0,0) (4,0) (4,4) (0,4)"

double[] ScaleFigure(double[] figure, double k)
{
    for (int i = 0; i < figure.Length; i++)
    {
        figure[i] *= k;
    }

    return figure;
}

Console.Clear();

Console.Write("Задайте ширину прямоугольника: ");
double.TryParse(Console.ReadLine().Replace('.', ','), out double width);
Console.Write("Задайте высоту прямоугольника: ");
double.TryParse(Console.ReadLine().Replace('.', ','), out double height);

int vertices = 4;
double[] rectangle = new double[vertices * 2];

rectangle[0] = 0;
rectangle[1] = 0;
rectangle[2] = width;
rectangle[3] = 0;
rectangle[4] = width;
rectangle[5] = height;
rectangle[6] = 0;
rectangle[7] = height;

Console.WriteLine("Вершины фигуры при условии, что первая точка лежит в (0, 0): ");
Console.Write($"({rectangle[0]}, {rectangle[1]}) ");
Console.Write($"({rectangle[2]}, {rectangle[3]}) ");
Console.Write($"({rectangle[4]}, {rectangle[5]}) ");
Console.WriteLine($"({rectangle[6]}, {rectangle[7]})");

Console.Write("Задайте коэффициент масштабирования k: ");
double.TryParse(Console.ReadLine().Replace('.', ','), out double k);

double[] scaledRectangle = ScaleFigure(rectangle, k);

Console.WriteLine($"Получаем вершины фигуры в масштабе k = {k}: ");
Console.Write($"({scaledRectangle[0]}, {scaledRectangle[1]}) ");
Console.Write($"({scaledRectangle[2]}, {scaledRectangle[3]}) ");
Console.Write($"({scaledRectangle[4]}, {scaledRectangle[5]}) ");
Console.WriteLine($"({scaledRectangle[6]}, {scaledRectangle[7]})");