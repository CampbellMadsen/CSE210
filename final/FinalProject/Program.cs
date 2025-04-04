using System;
class Program
{
    static void Main(string[] args)
    {
        ToneRowMatrix matrix = new ToneRowMatrix();
        matrix.GetBaseRow();
        matrix.GenerateMatrix();
        matrix.DisplayMatrix();  
        matrix.MakeRows();
    }
}