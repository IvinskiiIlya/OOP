namespace Geometric_Shape_Manager;

public class Program
{
    public static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("1 - добавить круг\n2 - добавить прямоугольник\n3 - вывести информацию о фигурах в списке\n4 - вывести информацию о фигурах в очереди\n5 - вывести информацию о фигурах в стеке\n6 - выйти из программы");
            bool isNumber = int.TryParse(Console.ReadLine(), out int choise);

            if (isNumber)
            {
                Console.Clear();
                DataStructures ds = new DataStructures();
                switch (choise)
                {
                    case 1:
                        Console.WriteLine("Введите радиус круга:");
                        bool isRadius = double.TryParse(Console.ReadLine(), out double radius);
                        Shape circle = new Circle(radius);
                        
                        ds.AddToList(circle);
                        ds.AddToQueue(circle);
                        ds.AddToStack(circle);
                        Console.WriteLine("Круг добавлен");
                        break;
                    case 2:
                        Console.WriteLine("Введите ширину прямоугольника:");
                        bool isWidth = double.TryParse(Console.ReadLine(), out double width);
                        Console.WriteLine("Введите высоту прямоугольника:");
                        bool isHeight = double.TryParse(Console.ReadLine(), out double height);
                        Shape rectangle = new Rectangle(width, height);
                        
                        ds.AddToList(rectangle);
                        ds.AddToQueue(rectangle);
                        ds.AddToStack(rectangle);
                        Console.WriteLine("Прямоугольник добавлен");
                        break;
                    case 3:
                        ds.PrintListInfo();
                        break;
                    case 4:
                        ds.PrintQueueInfo();
                        break;
                    case 5:
                        ds.PrintStackInfo();
                        break;
                    case 6:
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}