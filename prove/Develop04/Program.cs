using System;
using System.ComponentModel.Design;

class Program
{
    static void Main(string[] args)
    {
        string keepGoing = "";
        while (keepGoing != "4"){
            Console.WriteLine("MENU\n1. Breathing\n2. Reflecting\n3. Listing\n4. Quit");
            Console.Write("Select a choice from the menu: ");
            keepGoing = Console.ReadLine();
            if (keepGoing == "1"){
                Breathing myActivity = new Breathing();
                myActivity.RunActivity();
            } else if (keepGoing == "2"){
                Reflection myActivity = new Reflection();
                myActivity.RunActivity();
            } else if (keepGoing == "3"){
                Listing myActivity = new Listing();
                myActivity.RunActivity();
            } else {
                continue;
            }
            
        }
    }
}
    