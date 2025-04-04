class Note{
    private List<string> _notes = new List<string>();
    public void AddNote(string a){
        _notes.Add(a);
    }
    public string GetNotes(){
        return string.Join("", _notes);
    }
}