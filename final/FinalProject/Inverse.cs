class Inverse:ToneRow{
    public override void SetToneRow(ToneRowMatrix matrix, int i)
    {
       _toneRow = matrix.CreateInverse(i);
       _rhythmRow = matrix.CreateRetrograde(matrix.AddNotes(i,6));
    }
}