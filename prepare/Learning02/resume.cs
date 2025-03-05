class Resume {
    private string name;
    private List<Job> jobs = new List<Job>();
    public Resume(string name){
        name = this.name;
    }
    public void AddJob(Job job) {
        jobs.Add(job);
    }
    public void Display(){
        Console.WriteLine($"Name: {name}");
        Console.WriteLine("Jobs:");
        foreach (Job a in jobs) {
            a.display();
        }
    }
}