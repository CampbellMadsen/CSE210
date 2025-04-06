using System.Numerics;

abstract class ToneRow{
    protected List<int> _toneRow = new List<int>();
    protected List<int> _rhythmRow = new List<int>();
    public abstract void SetToneRow(ToneRowMatrix matrix, int i);
    public void CreateEmptyRow(){
        for (int i = 0; i < 12; i++){
            _toneRow.Add(13); // 13 doesn't correspond to any actual note, 
            // so no note gets chosen when generating the midi
            _rhythmRow.Add(i);
        }
    }
    public List<int> GetToneRow(){ //Commented stuff is for debug purposes
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