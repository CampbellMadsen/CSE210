using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job("microsoft", "fisherman", 1000, 2000);
        job1.display();
        Job job2 = new Job("microsoft", "super fisherman", -444, 6);

        Resume resume1 = new Resume("joe");
        resume1.AddJob(job1);
        resume1.AddJob(job2);
        resume1.Display();
    }
}