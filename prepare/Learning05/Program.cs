using System;
class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapeList = new List<Shape>();

        Square purpleSquare = new Square("Purple", 4);
        shapeList.Add(purpleSquare);

        Rectangle orangeRectangle = new Rectangle("Orange", 3, 6);
        shapeList.Add(orangeRectangle);

        Circle yellowCircle = new Circle("Yellow", 2);
        shapeList.Add(yellowCircle);

        foreach (Shape shape in shapeList)
        {
            string shapeColor = shape.GetColor();

            double shapeArea = shape.GetArea();

            Console.WriteLine($"The {shapeColor} shape has an area of {shapeArea}.");
        }
    }
}
