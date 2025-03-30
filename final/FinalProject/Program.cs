using System;

class Program
{
    static void Main(string[] args)
    {
        List<int> toneRow = new List<int>();
        for (int i = 0; i < 12; i++){
            toneRow.Add(i);
        }
        for (int i = 0; i < 12; i++){
            if (i == 11){
                Console.Write($"[E] ");
            } else if (i == 10){
                Console.Write("[T] ");
            } else {
                Console.Write($"[{toneRow[i]}] ");
            }
        }
    }
}