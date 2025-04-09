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
    public void DisplaySpinner(int time){
        for (int i = 0; i < time; i++){
            Console.Write(_spinnerFrames[i % 3]);
            Thread.Sleep(400);
            Console.Write("\b");
        }
        Console.Write(" ");

    }
    public int GetSeconds(){
        return _seconds;
    }
    public virtual void RunActivity(){
        Console.WriteLine($"Wecome to the {_name} activity!\n");
        Console.WriteLine($"{_description}\n");
        Console.Write("How long, in seconds, would you like your session? ");
        _seconds = int.Parse(Console.ReadLine());
        Console.WriteLine("Get Ready...");
        DisplaySpinner(5);
    }
}