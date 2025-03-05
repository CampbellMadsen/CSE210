using System;
using System.Drawing;
using System.Formats.Asn1;

class Cylinder {
    private double height;
    private Circle circle;
    public void SetHeight(double h) {
        height = h;
    }
    public void SetCircle(Circle c) {
        circle = c;
    }
    public double GetVolume() {
        double area = circle.GetArea();
        return area * height;
    }
    public Cylinder(double h, Circle c) {
        circle = c;
        height = h;
    }
}