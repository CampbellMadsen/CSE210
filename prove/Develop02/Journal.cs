using System.IO;
class Journal{
    public List<Entry> entries = new List<Entry>();
    public void AddEntry(Entry e){
        entries.Add(e);
    }
    public void DisplayEntries(){
        foreach (Entry e in entries) {
            e.DisplayEntry();
        }
    }
    public void CreateFile(){
        Console.Write("What is your filename? ");
        string filename = Console.ReadLine();
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (Entry e in entries) {
                outputFile.WriteLine(e.WriteEntry());
            }
        }
    }
    public List<Entry> ReadFile(Journal j) {
        j.entries.Clear();
        Console.Write("What is your filename? ");
        string filename = Console.ReadLine();
        string[] lines = System.IO.File.ReadAllLines(filename);
        foreach (string line in lines) {
            string[] parts = line.Split("☃");
            Entry newEntry = new Entry();
            newEntry.CreateEntryFromFile(parts[0],parts[1],parts[2]);
            newEntry.DisplayEntry();
            j.entries.Add(newEntry);
        }
        return j.entries;
    }
}