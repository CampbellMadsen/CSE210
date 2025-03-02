using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Prep3 World!");
        var keepGoing = "yes";
        while (keepGoing == "yes") {
        Random newRandomNumber = new Random();
        int MagicNumber = newRandomNumber.Next(1,100);
        var response = "no";
        int guessCounter = 0;
        while (response == "no") {
            Console.Write("What is your guess? ");
            string guessInput = Console.ReadLine();
            int guess = int.Parse(guessInput);
            guessCounter += 1;
            if (guess < MagicNumber) {
                Console.WriteLine("Higher");
            } else if (guess > MagicNumber) {
                Console.WriteLine("Lower");
            } else {
                Console.WriteLine($"You guessed it in {guessCounter} tries!");
                response = "yes";
            }
        }
        Console.Write("Do you want to keep going? ");
        keepGoing = Console.ReadLine();
        }
    }
}