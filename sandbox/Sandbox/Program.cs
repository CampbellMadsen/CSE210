using System;
using System.Runtime.CompilerServices;


class Program{

static void runSpinner(){
    int counter = 0;
    string spinnerString = "+-";
    while (counter < 100000) {
    Console.Write($"{spinnerString[counter%2]}");
    Console.Write("\b");
    Thread.Sleep(1);
    counter++;
}}
static void future(){
    DateTime now = DateTime.Now;
    DateTime future = now.AddSeconds(5);
    while (now < future) {
        Thread.Sleep(500);
        Console.WriteLine("waiting for the future");
        now = DateTime.Now;
    }
    Console.WriteLine("the futuer");
}
static void Main(string[] args)
    {
        Console.WriteLine("jey");
        future();
    }
}
