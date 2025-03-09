using System.Data;

class Entry {
    private string prompt;
    private string text;
    private string date;
    public void CreateEntryFromFile(string date, string prompt, string text) {
        this.date = date;
        this.prompt = prompt;
        this.text = text;
    }
    public string GetDate(){
        DateTime theCurrentTime = DateTime.Now;
        string dateText = theCurrentTime.ToShortDateString();
        return dateText;
    }
    public void CreateEntry(){
        Prompt p = new Prompt();
        prompt = p.ChoosePrompt();
        text = Console.ReadLine();
        date = GetDate();
    }
        public void DisplayEntry(){
        Console.WriteLine($"{date} - {prompt}\n{text}");
    }
        public string WriteEntry(){
        return $"{date}☃{prompt}☃{text}";
    }
}