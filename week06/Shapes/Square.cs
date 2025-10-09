public class Square : Shape
{
    private double _side;

    // Constructor calls base constructor
    public Square(string color, double side) : base(color)
    {
        _side = side;
    }

    public override double GetArea()
    {
        return _side * _side;
    }
}
