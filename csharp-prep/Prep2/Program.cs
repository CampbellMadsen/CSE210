using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Prep2 World!");
        Console.Write("What is your grade percentage? ");
        string userInput = Console.ReadLine();
        int grade = int.Parse(userInput);
        var letter="";
        if (grade < 60) {
            letter = "F";
        } else if (grade < 70) {
            letter = "D";
        } else if (grade < 80) {
            letter = "C";
        } else if (grade < 90) {
            letter = "B";
        } else {
            letter = "A";
        }
        var symbol = "";
        if (grade >= 90){
            if (grade % 10 <3) {
                symbol = "-";
            }
            } else if (grade >= 60){
                if (grade % 10 <3) {
                    symbol = "-";
                } else if (grade % 10 >= 7){
                    symbol = "+";
                }
            }
        Console.WriteLine($"Your grade is {letter}{symbol}.");
        if (grade >= 70) {
            Console.WriteLine("You passed the class!");
        } else {
            Console.WriteLine("You did not pass the class.");
        }
    }
}