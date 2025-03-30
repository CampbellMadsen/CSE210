using System.ComponentModel.DataAnnotations;

class GoalList{
    public List<Goal> _goals = new List<Goal>();
    private double _points;
    public void AddGoal(Goal goal){
        _goals.Add(goal);
    }
    public void DisplayGoals(){
            Console.WriteLine();
        for(int i = 0; i < _goals.Count(); i++){
            Console.Write($"{i+1}. ");
            Console.WriteLine(_goals[i].DisplayGoal());
        }
    }
    public void DisplayUncompletedGoals(){
        Console.WriteLine("Your goals are:");
        List<Goal> myList = new List<Goal>();
        int h = 1;
        for(int i = 0; i < _goals.Count(); i++){
            if (_goals[i].GetCheck() == false) {
                Console.Write($"{h}. ");
                _goals[i].DisplayGoalLite();
                myList.Add(_goals[i]);
                h++;
            }
        }
        Console.Write("Which goal did you accomplish? ");
        int choice = int.Parse(Console.ReadLine())-1;
        if (choice < myList.Count()&&choice>=0){ //makes it so if you go to record a goal but there are no goals listed, it doesn't just kill the program
            myList[choice].CompleteGoal();
            _points += myList[choice].AwardPoints();
        }
    }
    public void DisplayPoints(){
        Console.WriteLine($"\nYou have {_points} points.\n");
    }
    public void CreateFile(){
        Console.Write("What is your filename? ");
        string filename = Console.ReadLine();
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine(_points);
            foreach (Goal g in _goals) {
                outputFile.WriteLine(g.WriteGoal());
            }
        }
    }
    public virtual List<Goal> ReadFile(GoalList g) {
        g._goals.Clear();
        Console.Write("What is your filename? ");
        string filename = Console.ReadLine();
        string[] lines = System.IO.File.ReadAllLines(filename);
        g._points = double.Parse(lines[0]);
        for (int i = 1; i <= lines.Length-1; i++) {
            string line = lines[i];
            string[] parts = line.Split("☃");
            if (int.Parse(parts[0]) == 1){
                Simple newGoal = new Simple();
                newGoal.CreateGoalFromFile(int.Parse(parts[0]),parts[1],parts[2],double.Parse(parts[3]), parts[4]);
                g._goals.Add(newGoal);
            } else if (int.Parse(parts[0]) == 2){
                Eternal newGoal = new Eternal();
                newGoal.CreateGoalFromFile(int.Parse(parts[0]),parts[1],parts[2],double.Parse(parts[3]), parts[4]);
                g._goals.Add(newGoal);
            } else if (int.Parse(parts[0]) == 3){
                Checklist newGoal = new Checklist();
                newGoal.CreateGoalFromFile(int.Parse(parts[0]), parts[1], parts[2], double.Parse(parts[3]), parts[4]);
                newGoal.CreateChecklistFromFile(int.Parse(parts[5]), int.Parse(parts[6]), double.Parse(parts[7]));
                g._goals.Add(newGoal);
            }
        }
        return g._goals;
    }
}