namespace Geometric_Shape_Manager;

public class Circle : Shape
{
    public double Radius { get; set; }

    public Circle(double radius)
    {
        Radius = radius;
    }

    public override double CalculateArea()
    {
        return Math.PI * Math.Pow(Radius, 2);
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Круг с радиусом {Radius} имеет площадь: {CalculateArea()}");
    }
}