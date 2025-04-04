class Retrograde:ToneRow{
    public override void SetToneRow(ToneRowMatrix matrix, int i)
    {
        _toneRow = matrix.CreateRetrograde(i);
        _rhythmRow = matrix.CreateInverse(matrix.AddNotes(i,6));
    }
}