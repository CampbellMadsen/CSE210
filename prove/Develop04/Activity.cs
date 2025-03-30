class Activity{
    private string _name;
    private string _description;
    private int _seconds;
    private string _spinnerFrames = "\\-/";
    public void SetName(string choice){
        _name = choice;
    }
    public Activity(string name, string desc){
        _name = name;
        _description = desc;
    }
    public void DisplaySpinner(){
        Console.WriteLine("Get Ready...");
        for (int i = 0; i < 15; i++){
            Console.Write(_spinnerFrames[i % 3]);
            Thread.Sleep(750);
            Console.Write("\b");
        }

    }
    public void RunActivity(){
        Console.WriteLine($"Wecome to the {_name} activity!\n");
        Console.WriteLine($"{_description}\n");
        Console.Write("How long, in seconds, would you like your session? ");
        _seconds = int.Parse(Console.ReadLine());
        DisplaySpinner();
    }
}