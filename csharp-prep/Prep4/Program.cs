using System;
using System.Collections.Generic;
using System.Data;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a list of numbers, type 0 when finished");
        List<int> numbers;
        numbers = new List<int>();
        var loop = "yes";
        int sum = 0;
        int counter = 0;
        int highest = -2147483648;
        int smallestPositive = 2147483647;
        while (loop == "yes") {
            Console.Write("Input a number: ");
            string input = Console.ReadLine();
            int number = int.Parse(input);
            if (number == 0) {
                loop = "no";
            } else {
                numbers.Add(number);
                sum += number;
                counter+=1;
                if (number > highest) {
                    highest = number;
                }
                if (number > 0 && number < smallestPositive) {
                    smallestPositive = number;
                }
            }
        }
        Console.WriteLine($"The sum is: {sum}");
        var average = sum/counter;
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {highest}");
        if (smallestPositive != 2147483647) {
            Console.WriteLine($"The smallest positive number is: {smallestPositive}");
        }
        numbers.Sort();
        Console.WriteLine("Sorted List:");
        foreach (int a in numbers) {
            Console.WriteLine(a);
        }
    }
}