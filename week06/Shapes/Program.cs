using System;

public abstract class Shape
{
    public abstract double Area();
}

public class Rectangle : Shape
{
    private readonly double width;
    private readonly double height;

    public Rectangle(double width, double height)
    {
        this.width = width;
        this.height = height;
    }

    public override double Area()
    {
        return width * height;
    }
}

public class Circle : Shape
{
    private readonly double radius;

    public Circle(double radius)
    {
        this.radius = radius;
    }

    public override double Area()
    {
        return Math.PI * radius * radius;
    }
}

public class Program
{
    public static void Main()
    {
        Shape[] shapes =
        {
            new Rectangle(4, 5),
            new Circle(3),
            new Rectangle(2, 6)
        };

        foreach (Shape shape in shapes)
        {
            Console.WriteLine(shape.Area());
        }
    }
}
