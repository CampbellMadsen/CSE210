using System;
using System.Runtime.InteropServices.Marshalling;

class Program
{
    static void Main(string[] args)
    {
        string keepGoing = "";
        GoalList goals = new GoalList();
        while (keepGoing != "6"){
            goals.DisplayPoints();
            Console.Write("Menu Options:\n 1. Create New Goal\n 2. List Goals\n 3. Save Goals\n 4. Load Goals\n 5. Record Event\n 6. Quit\nSelect a choice from the menu: ");
            keepGoing = Console.ReadLine();
            if (keepGoing == "1"){
                Console.Write("The types of goals are:\n 1. Simple Goal\n 2. Eternal Goal\n 3. Checklist Goal\n");
                string goalType = Console.ReadLine();
                if (goalType == "1"){
                    Simple myGoal = new Simple();
                    myGoal.CreateGoal();
                    myGoal._goalType = 1;
                    goals.AddGoal(myGoal);
                } else if (goalType == "2"){
                    Eternal myGoal = new Eternal();
                    myGoal.CreateGoal();
                    myGoal._goalType = 2;
                    goals.AddGoal(myGoal);
                } else if (goalType == "3"){
                    Checklist myGoal = new Checklist();
                    myGoal.CreateGoal();
                    myGoal._goalType = 3;
                    goals.AddGoal(myGoal);
                }
            } else if (keepGoing == "2"){
                goals.DisplayGoals();
            } else if (keepGoing == "3"){
                goals.CreateFile();
            } else if (keepGoing == "4"){
                goals._goals = goals.ReadFile(goals);
            } else if (keepGoing == "5"){
                goals.DisplayUncompletedGoals();
            }
        }
    }
}