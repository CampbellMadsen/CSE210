using System;

class Program
{
    static void Main(string[] args)
    {
        Fraction myFraction = new Fraction();
        myFraction.SetBottom(4);
        myFraction.SetTop(2);
        myFraction.GetFractionString();
        myFraction.GetDecimalValue();
    }
}