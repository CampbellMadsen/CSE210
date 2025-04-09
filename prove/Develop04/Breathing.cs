class Breathing:Activity{
    public Breathing():base("Breathing","This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing."){

    }
    public override void RunActivity(){
        base.RunActivity();
        Console.Clear();
        int seconds = GetSeconds();
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(seconds);
        while (DateTime.Now < endTime){
            Console.Write("\n\nBreathe In...4");//I know this could be a function but I'm kinda in a rush
            Thread.Sleep(1000);
            Console.Write("\b");
            Console.Write("3");
            Thread.Sleep(1000);
            Console.Write("\b");
            Console.Write("2");
            Thread.Sleep(1000);
            Console.Write("\b");
            Console.Write("1");
            Thread.Sleep(1000);
            Console.Write("\b");
            Console.Write(" ");
            Console.Write("\n\nBreathe Out...6");
            Thread.Sleep(1000);
            Console.Write("\b");
            Console.Write("5");
            Thread.Sleep(1000);
            Console.Write("\b");
            Console.Write("4");
            Thread.Sleep(1000);
            Console.Write("\b");
            Console.Write("3");
            Thread.Sleep(1000);
            Console.Write("\b");
            Console.Write("2");
            Thread.Sleep(1000);
            Console.Write("\b");
            Console.Write("1");
            Thread.Sleep(1000);
            Console.Write("\b");
            Console.Write(" ");
        }
    Console.WriteLine($"\nWell done! You completed {seconds} seconds of the Breathing activity!");
    DisplaySpinner(5);
    }
}