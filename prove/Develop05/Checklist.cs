using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;

class Checklist:Goal{
    private int _times;
    private int _counter;
    private double _bonusPoints;
    public override void CompleteGoal()
    {
        _counter++;
        if (_counter == _times){
            SetCheck();
        }
    }
    public override void CreateGoal()
    {
        base.CreateGoal();
        Console.Write("How many times does this goal need to be accomplished for a bonus? ");
        _times = int.Parse(Console.ReadLine());
        Console.Write("What is the bonus for accomplishing it that many times? ");
        _bonusPoints = int.Parse(Console.ReadLine());
        _counter = 0;
    }
    public override string DisplayGoal()
    {
        string baseString = base.DisplayGoal();
        return $"{baseString} -------- Currently Completed: {_counter}/{_times}";
    }
    public override double AwardPoints()
    {
        if (_counter == _times){
            double totalPoints = _bonusPoints + JustGivePoints();
            Console.WriteLine($"Congratulations! You earned {totalPoints} points!");
            return totalPoints;
        } else {
            return base.AwardPoints();
        }
    }
    public override string WriteGoal()
    {
        string baseString = base.WriteGoal();
        return $"{baseString}☃{_times}☃{_counter}☃{_bonusPoints}";
    }

    public void CreateChecklistFromFile(int a, int b, double c){
        _times = a;
        _counter = b;
        _bonusPoints = c;
    }
}