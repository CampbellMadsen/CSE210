using System;
using System.Runtime.CompilerServices;

class Circle {
    private double radius;
    public Circle(double r) {
        radius = r;
    }
    public double GetArea() {
        double area = Math.PI * radius * radius;
        return area;
    }
    public void DisplayCircleArea() {
        Console.WriteLine($"The area of the circle is {GetArea()}");
    }
    public void SetRadius (double r) {
        radius = r;
    }
}