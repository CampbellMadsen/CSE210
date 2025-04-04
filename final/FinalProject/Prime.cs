class Prime:ToneRow{
    public override void SetToneRow(ToneRowMatrix matrix, int i)
    {
        _toneRow = matrix.CreatePrime(i);
        _rhythmRow = matrix.CreateRetrogradeInverse(matrix.AddNotes(i,6));
    }
}