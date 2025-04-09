using System.Diagnostics.Metrics;
using System.Reflection.PortableExecutable;

class Listing:Activity{
    public Listing():base("Listing","This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area."){
    }
    public override void RunActivity()
    {
        base.RunActivity();
        List<string> prompts = new List<string>{"Who are people that you appreciate?","What are personal strengths of yours?","Who are people that you have helped this week?","When have you felt the Holy Ghost this month?","Who are some of your personal heroes?"};
        Random rng = new Random();
        Console.WriteLine("List as many responses as you can to the following prompt:");
        Console.WriteLine($"--- {prompts[rng.Next(0,5)]} ---");
        Console.Write("You may begin in ");
        for (int i = 0; i < 5; i++){
            Console.Write(5-i);
            Thread.Sleep(1000);
            Console.Write("\b");
        }
        Console.WriteLine("\n \n");
        int seconds = GetSeconds();
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(seconds);
        int counter = 0;
        bool keepGoing = true;
        while (keepGoing){
            Console.Write(">");
            if (DateTime.Now > endTime){ // tried to make it so you can't extend the timer, but I wasn't able to figure it out
                keepGoing = false;
            } else {
                Console.ReadLine();
                counter++;
            }
        }
        Console.WriteLine($"You listed {counter} items!");
        Console.WriteLine($"\nWell done! You completed {seconds} seconds of the Listing activity!");
        DisplaySpinner(5);
    }
}