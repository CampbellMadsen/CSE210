using System;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        displayMessage();
        string name = promptUserName();
        int number = promptUserNumber();
        int square = squareNumber(number);
        displayResult(name, square);



        static void displayMessage() {
            Console.WriteLine("Welcome to the program!");
        }
        static string promptUserName(){
            Console.Write("What is your name? ");
            return Console.ReadLine();
        }
        static int promptUserNumber(){
            Console.Write("What is your favorite number? ");
            string input = Console.ReadLine();
            return int.Parse(input);
        }
        static int squareNumber(int number){
            return number * number;
        }
        static void displayResult(string name, int number){
            Console.WriteLine($"{name}, the square of your number is {number}.");
        }
    }
}