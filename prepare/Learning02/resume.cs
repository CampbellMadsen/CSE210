class Resume {
    private string personName;
    private List<Job> jobs = new List<Job>();
    public Resume(string name){
        personName = name;
    }
    public void AddJob(Job job) {
        jobs.Add(job);
    }

    public void Display(){
        Console.WriteLine($"Name: {personName}");
        Console.WriteLine("Jobs:");
        foreach (Job a in jobs) {
            a.display();
        }
    }
}