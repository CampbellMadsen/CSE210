using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Composing;
using Melanchall.DryWetMidi.Interaction;
using System.Reflection.PortableExecutable;
class MidiOutput{
    private List<int> _notesRight = new List<int>();
    private List<int> _notesLeft = new List<int>();
    private List<int> _rhythmsRight = new List<int>();
    private List<int> _rhythmsLeft = new List<int>();
    private List<Note> _noteList = new List<Note>();
    public void AddMidiDataRight(List<ToneRow> rows){
        foreach (ToneRow row in rows){
            foreach (int note in row.GetToneRow()){
                _notesRight.Add(note);
            }
            foreach (int rhythm in row.GetRhythmRow()){
                _rhythmsRight.Add(rhythm + 1);
            }
        }
    }
    public void AddMidiDataLeft(List<ToneRow> rows){
        foreach (ToneRow row in rows){
            foreach (int note in row.GetToneRow()){
                _notesLeft.Add(note);
            }
            foreach (int rhythm in row.GetRhythmRow()){
                _rhythmsLeft.Add(rhythm + 1);
            }
        }
    }
    private void SetNoteList(){
        _noteList.Clear();
        for (int i = 0; i < _notesRight.Count(); i++){    
            Note newNote = new Note();
            _noteList.Add(newNote);
        }
    }
    private void CreateMidiData(List<int> notes, List<int> rhythms){
        for (int currentIndex = 0; currentIndex < notes.Count(); currentIndex++){ //iterate through a tone row
            for (int j = 0; j < notes.Count(); j++){ //determine which note is being played
                if (notes[currentIndex] == j){
                    for (int k = 1; k < rhythms[currentIndex] + 1; k++){//determine length of notes
                        if (rhythms[currentIndex] == 1){//logic to determine held notes
                            _noteList[j].AddNote("|");
                        } else if (rhythms[currentIndex] != 1 && k == 1){
                            _noteList[j].AddNote("[");
                        } else if (k == rhythms[currentIndex] && k != 1){
                            _noteList[j].AddNote("]");
                        } else {
                            _noteList[j].AddNote("=");
                        }
                    }
                } else {
                    for (int k = 1; k < rhythms[currentIndex] + 1; k++){
                        _noteList[j].AddNote("=");
                    }
                }
            }
        }
    }
    public void GenerateMidi(){
        SetNoteList();
        CreateMidiData(_notesRight,_rhythmsRight);
        List<string> noteStrings = new List<string>{"","","","","","","","","","","","","","","","","","","","","","","",""};
        for (int i = 0; i < 12; i++){
            noteStrings[i] = _noteList[i].GetNotes();
            // Console.WriteLine(i);
            // Console.WriteLine(noteStrings[i]);
        }
        SetNoteList();
        CreateMidiData(_notesLeft, _rhythmsLeft);
        for (int i = 0; i < 12; i++){
            noteStrings[i+12] = _noteList[i].GetNotes();
            // Console.WriteLine(i+12);
            // Console.WriteLine(noteStrings[i+12]);
        }
        Pattern pattern1 = new PatternBuilder()
        .SetNoteLength(MusicalTimeSpan.Sixteenth)
        .Anchor()
        // DryWetMidi has a piano roll editor, which converts strings into music.
        // All of the logic above generates strings for each individual note
        // = - don't play
        // | - short note
        // [ - start held note
        // ] - end held note
        .PianoRoll(@$"
            C4   {noteStrings[0]}
            C#4  {noteStrings[1]}
            D4   {noteStrings[2]}
            D#4  {noteStrings[3]}
            E4   {noteStrings[4]}
            F4   {noteStrings[5]}
            F#4  {noteStrings[6]}
            G4   {noteStrings[7]}
            G#4  {noteStrings[8]}
            A4   {noteStrings[9]}
            A#4  {noteStrings[10]}
            B4   {noteStrings[11]}") //Creates right hand midi data
        .Build();
        TrackChunk trackChunk1 = pattern1.ToTrackChunk(TempoMap.Default);
        Pattern pattern2 = new PatternBuilder()
        .SetNoteLength(MusicalTimeSpan.Sixteenth)
        .PianoRoll(@$"
            C3   {noteStrings[12]}
            C#3  {noteStrings[13]}
            D3   {noteStrings[14]}
            D#3  {noteStrings[15]}
            E3   {noteStrings[16]}
            F3   {noteStrings[17]}
            F#3  {noteStrings[18]}
            G3   {noteStrings[19]}
            G#3  {noteStrings[20]}
            A3   {noteStrings[21]}
            A#3  {noteStrings[22]}
            B3   {noteStrings[23]}")//creates left hand midi data
        .Build();
        TrackChunk trackChunk2 = pattern2.ToTrackChunk(TempoMap.Default);
        MidiFile midifile = new MidiFile(trackChunk1, trackChunk2);
        midifile.Write("myMidi.mid", true);
        Console.WriteLine("\nFile Created!\n");
    }
}