namespace Geometric_Shape_Manager;

public abstract class Shape : IShape
{
    public abstract double CalculateArea();
    public virtual void DisplayInfo() {}
}