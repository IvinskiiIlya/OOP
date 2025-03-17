namespace Geometric_Shape_Manager;

public class DataStructures
{
    public List<Shape> FigureList { get; set; }
    private Queue<Shape> FigureQueue { get; set; }
    private Stack<Shape> FigureStack { get; set; }

    public DataStructures()
    {
        FigureList = new List<Shape>();
        FigureQueue = new Queue<Shape>();
        FigureStack = new Stack<Shape>();
    }
    
    public void AddToList(Shape shape)
    {
        FigureList.Add(shape);
    }

    public void AddToQueue(Shape shape)
    {
        FigureQueue.Enqueue(shape);
    }

    public void AddToStack(Shape shape)
    {
        FigureStack.Push(shape);
    }
    
    public void PrintListInfo()
    {
        Console.WriteLine("Фигуры в списке:");
        foreach (var shape in FigureList)
            shape.DisplayInfo();
    }

    public void PrintQueueInfo()
    {
        Console.WriteLine("Фигуры в очереди:");
        foreach (var shape in FigureQueue)
            shape.DisplayInfo();
    }

    public void PrintStackInfo()
    {
        Console.WriteLine("Фигуры в стеке:");
        foreach (var shape in FigureStack)
            shape.DisplayInfo();
    }
}