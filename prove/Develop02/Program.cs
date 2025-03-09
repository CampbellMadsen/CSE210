using System;
using System.Data;

class Program
{
    static void Main(string[] args)
    {
        Journal myJournal = new Journal();
        string number = ";";
        while (number != "5") {
            Console.WriteLine("1. New Entry\n2. View Journal\n3. Save to File\n4. Load from File\n5. Exit");
            number = Console.ReadLine();
            if (number == "1") {
                Entry myEntry = new Entry();
                myEntry.CreateEntry();
                myJournal.AddEntry(myEntry);
            } else if (number == "2") {
                myJournal.DisplayEntries();
            } else if (number == "3") {
                myJournal.CreateFile();
            } else if (number == "4") {
                myJournal.entries = myJournal.ReadFile(myJournal);
            }
        }
    }
}