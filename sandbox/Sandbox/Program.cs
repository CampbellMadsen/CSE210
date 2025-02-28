using System;
using System.Runtime.CompilerServices;

class Program
{
    public static int AddNumbers(int x, int y){
        return x + y;
    }
    static void Main(string[] args)
    {
        // bool correctInput = false;
        // do{
        //     Console.Write("please input your age: ");
        //     int age = int.Parse(Console.ReadLine());
        //     if (age >= 0 && age < 120) {
        //         Console.WriteLine($"Your age is: {age}");
        //         correctInput=true;
        //     } else correctInput = false;
        // } while(!correctInput);

        // Random newRandomNumber = new Random();
        // int number = newRandomNumber.Next(1,1000);
        // Console.WriteLine($"{number}");

        int total = AddNumbers(100,200);
        Console.WriteLine($"{total}");
    }
}