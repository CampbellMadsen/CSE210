class Program {
    public static void Main(string[] args){
        Fisherman myfisherman = new Fisherman("john", "john", "john", 3);
        Console.WriteLine($"{myfisherman.GetName()}");
    }
    
}