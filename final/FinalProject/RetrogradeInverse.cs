class RetrogradeInverse:ToneRow{
    public override void SetToneRow(ToneRowMatrix matrix, int i)
    {
        _toneRow = matrix.CreateRetrogradeInverse(i);
        _rhythmRow = matrix.CreatePrime(matrix.AddNotes(i,6));
    }
}