using System.ComponentModel.Design.Serialization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.Marshalling;

class Goal{
    private string _name;
    private string _desc;
    private double _points;
    private string _check;
    public int _goalType;
    public virtual void CreateGoal(){
        Console.Write("What is the name of your goal? ");
        _name = Console.ReadLine();
        Console.Write("Write a short description of your goal: ");
        _desc = Console.ReadLine();
        Console.Write("What is the amount of points associated with your goal? ");
        _points = int.Parse(Console.ReadLine());
        _check = "[ ]";
    }
    public void SetCheck(){
        _check = "[X]";
    }
    public virtual double AwardPoints(){
        Console.WriteLine($"Congratulations! You earned {_points} points!");
        return _points;
    }
    public double JustGivePoints(){
        return _points;
    }
    public bool GetCheck(){
        if(_check == "[X]"){
            return true;
        } else {
            return false;
        }
    }
    public virtual void CompleteGoal(){

    }
    public virtual string DisplayGoal(){
        return $"{_check} {_name} ({_desc})";
    }
    public void DisplayGoalLite(){
        Console.WriteLine(_name);
    }
    public virtual string WriteGoal(){
        return $"{_goalType}☃{_name}☃{_desc}☃{_points}☃{_check}";
    }
    public void CreateGoalFromFile(int z, string a, string b, double c, string d){
        _goalType = z;
        _name = a;
        _desc = b;
        _points = c;
        _check = d;
    }
}