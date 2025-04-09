class Reflection:Activity{
    public Reflection():base("Reflecting","This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life."){

    }
    public override void RunActivity()
    {
        base.RunActivity();
        Console.Clear();
        int seconds = GetSeconds();
        Console.WriteLine("Consider the following prompt:");
        List<string> prompts = new List<string>{"Think of a time when you stood up for someone else.","Think of a time when you did something really difficult.","Think of a time when you helped someone in need.","Think of a time when you did something truly selfless."};
        List<string> questions = new List<string>{"Why was this experience meaningful to you?","Have you ever done anything like this before?","How did you get started?","How did you feel when it was complete?","What made this time different than other times when you were not as successful?","What is your favorite thing about this experience?","What could you learn from this experience that applies to other situations?","How can you keep this experience in mind in the future?","What did you learn about yourself through this experience?"};
        Random rng = new Random();
        Console.WriteLine ($"--- {prompts[rng.Next(0,4)]} ---");
        Console.Write("You may begin in ");
        for (int i = 0; i < 5; i++){
            Console.Write(5-i);
            Thread.Sleep(1000);
            Console.Write("\b");
        }
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(seconds);
        while (DateTime.Now < endTime){
            Console.Write($"\n\n{questions[rng.Next(0,9)]}");
            DisplaySpinner(20);
        }
        Console.WriteLine($"\nWell done! You completed {seconds} seconds of the Reflection activity!");
        DisplaySpinner(5);
    }
}