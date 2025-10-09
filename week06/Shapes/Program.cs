using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {

        List<Shape> shapes = new List<Shape>();

        shapes.Add(new Square("Red", 4));
        shapes.Add(new Rectangle("Blue", 5, 6));
        shapes.Add(new Circle("Green", 3));

        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"The {shape.GetColor()} shape has an area of {shape.GetArea():F2}");
        }
    }
}
