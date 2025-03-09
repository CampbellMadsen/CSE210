using System.Runtime.InteropServices.Marshalling;

class Prompt {
    private List<string> promptList = new List<string>();
    public Prompt(){
        
    }
    private List<string> CreatePromptList() {
        promptList.Add("Who was the most interesting person I interacted with today?");
        promptList.Add("What was the best part of my day?");
        promptList.Add("How did I see the hand of the Lord in my life today?");
        promptList.Add("What was the strongest emotion I felt today?");
        promptList.Add("If I had one thing I could do over today, what would it be?");
        return promptList;
    }
    public string ChoosePrompt(){
        CreatePromptList();
        string prompt = "";
        Random newRandomNumber = new Random();
        int n = newRandomNumber.Next(1,5);
        for (int i = 0; i < 5; i++) {
            if (i == n){
                prompt = promptList[i];
            }
        }
        Console.WriteLine(prompt);
        return prompt;
    }
}