using System.Numerics;

abstract class ToneRow{
    protected List<int> _toneRow = new List<int>();
    protected List<int> _rhythmRow = new List<int>();
    public abstract void SetToneRow(ToneRowMatrix matrix, int i);
    public void CreateEmptyRow(){
        for (int i = 0; i < 12; i++){
            _toneRow.Add(13);
            _rhythmRow.Add(i);
        }
    }
    public List<int> GetToneRow(){
        //     foreach (int j in _toneRow) {
        //     Console.Write($"{j},");
        // }
        // Console.WriteLine();
        return _toneRow;
    }
    public List<int> GetRhythmRow(){
        // foreach (int i in _rhythmRow) {
        //     Console.Write($"{i},");
        // }
        // Console.WriteLine();
        return _rhythmRow;
    }
}