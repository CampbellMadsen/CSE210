class Job {
    private string companyName;
    private string jobTitle;
    private int startYear;
    private int endYear;
    public Job(string company, string title, int start, int end) {
        companyName = company;
        jobTitle = title;
        startYear = start;
        endYear = end;
    }
    public void display() {
        Console.WriteLine($"{jobTitle} ({companyName}), {startYear}-{endYear}");
    }
}