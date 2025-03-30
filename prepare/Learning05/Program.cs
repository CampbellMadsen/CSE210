using System;

class Program
{
    static void Main(string[] args)
    {
        Square mySquare = new Square(4, "blue");
        Circle myCircle = new Circle(1, "red");
        Rectangle myRectangle = new Rectangle(4,5,"green");
        List<Shape> myList = new List<Shape>();
        myList.Add(mySquare);
        myList.Add(myRectangle);
        myList.Add(myCircle);
        foreach (Shape shape in myList){
            Console.WriteLine($"{shape.GetArea()}");
            Console.WriteLine($"{shape.GetColor()}");
        }
    }
}