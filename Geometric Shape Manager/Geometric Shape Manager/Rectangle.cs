namespace Geometric_Shape_Manager;

public class Rectangle : Shape
{
    public double Width { get; set; }
    public double Height { get; set; }
    
    public Rectangle(double width, double height)
    {
        Width = width;
        Height = height;
    }

    public override double CalculateArea()
    {
        return Width * Height;
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Прямоугольник с шириной {Width} и высотой {Height} имеет площадь: {CalculateArea()}");
    }
}