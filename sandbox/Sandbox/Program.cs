using System;
using System.Runtime.CompilerServices;


class Program {
    public static int AddNumbers(int x, int y) {
        return x + y;
    }
    static void Main(string[] args) {
        Circle myCircle = new Circle(10);
        myCircle.DisplayCircleArea();
        Cylinder myCylinder = new Cylinder(10,myCircle);
        double volume = myCylinder.GetVolume();
        Console.WriteLine($"the cylinder's volume is {volume}");
    }
}