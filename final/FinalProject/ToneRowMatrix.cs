using System.Data;

class ToneRowMatrix{
    private List<int> _baseRow = new List<int>();
    private List<List<int>> _matrix = new List<List<int>>();
    private List<ToneRow> _midiDataRight = new List<ToneRow>();
    private List<ToneRow> _midiDataLeft = new List<ToneRow>();
    private MidiOutput _midiOutput = new MidiOutput();
    private static Random _rng = new Random();
    public void GetBaseRow(){
        int counter = 0;
        List<int> remaining = new List<int>();
        for (int i = 0; i < 12; i++){
            remaining.Add(AddNotes(i, 0));
        }
        while (counter < 12){ 
            Console.WriteLine("Add notes, or type 12 to generate a random matrix");
            Console.Write("Enter a note (Remaining: ");
            for (int i = 0; i < remaining.Count(); i++){
                if (i < remaining.Count()-1){
                    Console.Write($"{remaining[i]}  ");
                } else {
                    Console.Write($"{remaining[i]}): ");
                }
            }
            int input = int.Parse(Console.ReadLine());
            if (input >=0 && input < 12){
                if (_baseRow.Contains(input)){
                    Console.WriteLine("You have already used that note.");
                } else {
                    _baseRow.Add(input);
                    remaining.Remove(input);
                    counter++;
                } // extra inputs for debugging
            } else if (input == 13){ // type 13 at start for a list sorted 0-12
                _baseRow.Clear();
                for (int i = 0; i < 12; i++){
                    _baseRow.Add(AddNotes(i, 0));
                }
                counter = 12;
            } else if (input == 12){ // type 12 at start for a list sorted randomly
                _baseRow.Clear();
                for (int i = 0; i < 12; i++){
                    _baseRow.Add(AddNotes(i, 0));
                }
                var shuffledList = _baseRow.OrderBy(_ => _rng.Next()).ToList(); // this code taken directly from stackexchange
                _baseRow = shuffledList;
                counter = 12;
            } else {
                Console.WriteLine("That is not a valid pitch.");
            }
        }
    }
    public void GenerateMatrix(){
        _matrix.Add(_baseRow);
        for (int i = 0; i < 11; i++){
            List<int> newList = new List<int>();
            for (int j = 0; j < 12; j++){
                int x = -(_baseRow[i+1] - _baseRow[0]);
                newList.Add(AddNotes(_baseRow[j], x));
            }
            _matrix.Add(newList);
        }
    }
    public int AddNotes(int a, int b){ // adding 2 pitches has to give a number between 0 and 12
        int c = a + b;
        if (c > 11){
            return c - 12;
        } else if (c < 0){
            return c + 12;
        } else {
            return c;
        }
    }
    public void DisplayMatrix(){
        Console.WriteLine("Matrix Generated!");
        foreach (List<int> row in _matrix){
            for (int i = 0; i < 12; i++){
                if (row[i] == 11){
                    Console.Write($"[E] "); // I use E for 11 and T for 10 so they don't get confused with 1 and 0
                } else if (row[i] == 10){
                    Console.Write("[T] "); // it also makes it look nicer since its a monospace font
                } else {
                    Console.Write($"[{row[i]}] ");
                }
            }
            Console.WriteLine();
        }
    }
    public List<int> CreatePrime(int p){
        List<int> prime = new List<int>();
        foreach (List<int> list in _matrix){
            if (list[0] == p){
                prime = list;
            }
        }
        return prime;
    }
    public List<int> CreateRetrograde(int r){
        List<int> prime = CreatePrime(r);
        List<int> retrograde = new List<int>();
        int counter = 11;
        for (int i = 0; i<12; i++){
            retrograde.Add(prime[counter]); // I don't use list.reverse because it was managing to reverse the list in the matrix
            counter -= 1;
        }
        return retrograde;
    }
    public List<int> CreateInverse(int v){
        List<int> inverse = new List<int>();
        int w = 0;
        for (int i = 0; i < 12; i++){
            if (_matrix[0][i] == v){
                w = i;
            }
        }
        foreach (List<int> list in _matrix){ 
            inverse.Add(list[w]);
        }
        return inverse;
    }
    public List<int> CreateRetrogradeInverse(int ri){
        List<int> inverse = CreateInverse(ri);
        List<int> retrogradeInverse = new List<int>();
        int counter = 11;
        for (int i = 0; i<12; i++){
            retrogradeInverse.Add(inverse[counter]);
            counter -= 1;
        }
        return retrogradeInverse;
    }
    public void MakeRows(){
        string keepGoing = "";
        bool hand = true;
        int counter = 0;
        string handType;
        Console.WriteLine("Type C to create midi, X to quit, or Z to generate a random midi. (H for more info)");
        while (keepGoing.ToLower() != "x"){
            if (hand){
                handType = "right";
                counter++;
            } else {
                handType = "left";
            }
            Console.Write($"Choose row {counter} for {handType} hand ([P]rime, [I]nverse, [R]etrograde, [RI]nverse, [E]mpty): ");
            keepGoing = Console.ReadLine();
            if (keepGoing.ToLower() == "p"){
                Prime newRow = new Prime();
                MakeRow(newRow, hand);
                hand = !hand;
            } else if (keepGoing.ToLower() == "r"){
                Retrograde newRow = new Retrograde();
                MakeRow(newRow, hand);
                hand = !hand;
            } else if (keepGoing.ToLower() == "i"){
                Inverse newRow = new Inverse();
                MakeRow(newRow, hand);
                hand = !hand;
            } else if (keepGoing.ToLower() == "ri"){
                RetrogradeInverse newRow = new RetrogradeInverse();
                MakeRow(newRow, hand);
                hand = !hand;
            } else if (keepGoing.ToLower() == "c"){
                if (_midiDataRight.Count() == 0){ // if there is no data, the midi generator breaks without this logic
                        Prime newRow = new Prime();
                        newRow.CreateEmptyRow();
                        _midiDataRight.Add(newRow);
                    }
                foreach (ToneRow i in _midiDataRight){
                    i.GetToneRow();
                }
                _midiOutput.AddMidiDataRight(_midiDataRight);
                if (_midiDataLeft.Count() < _midiDataRight.Count()){ //generate empty left hand row if there isn't anything (prevents errors)
                    Prime newRow = new Prime();
                    newRow.CreateEmptyRow();
                    _midiDataLeft.Add(newRow);
                }
                foreach (ToneRow i in _midiDataLeft){
                    i.GetToneRow();
                }
                _midiOutput.AddMidiDataLeft(_midiDataLeft);
                keepGoing = "x";
                _midiOutput.GenerateMidi();
            } else if (keepGoing == "z"){
                keepGoing = "x";
                Random rnd = new Random();
                int number = 1;
                for (int h = 0; h < 6; h++){
                    if (number == 1){
                        Prime newRow = new Prime();
                        MakeRandomRow(newRow, hand, rnd, h);
                        hand = !hand;
                    } else if (number == 2){
                        Inverse newRow = new Inverse();
                        MakeRandomRow(newRow, hand, rnd, h);
                        hand = !hand;
                    } else if (number == 3){
                        Retrograde newRow = new Retrograde();
                        MakeRandomRow(newRow, hand, rnd, h);
                        hand = !hand;
                    } else {
                        RetrogradeInverse newRow = new RetrogradeInverse();
                        MakeRandomRow(newRow, hand, rnd, h);
                        hand = !hand;
                    }
                    number = rnd.Next(1,5);
                }
                _midiOutput.AddMidiDataRight(_midiDataRight);
                _midiOutput.AddMidiDataLeft(_midiDataLeft);
                _midiOutput.GenerateMidi();
            } else if (keepGoing.ToLower() == "e"){
                Prime newRow = new Prime();
                newRow.CreateEmptyRow();
                if (hand){
                    _midiDataRight.Add(newRow);
                } else {
                    _midiDataLeft.Add(newRow);
                }
                hand = !hand;
            } else if (keepGoing.ToLower() == "h"){ //music nerd info - this is somewhat simplified but hopefully it gets the point across!
                Console.WriteLine("This is my 12 tone total serialism midi generator.");
                Console.WriteLine("It is based on a method of composition developed by Pierre Boulez in the early 1950s.");
                Console.WriteLine("What is 12 tone serialism?");
                Console.WriteLine(" - It is a type of post-tonal music designed to give the composer full control.");
                Console.WriteLine(" - You start by creating a tone row - a list of all 12 pitches in any order.");
                Console.WriteLine(" - You then generate a matrix based on that tone row (don't worry about how)");
                Console.WriteLine(" - From the matrix, you can pick four types of tone rows:");
                Console.WriteLine("   - Prime (row), Inverse (column), Retrograde (reverse row), Retrograde Inverse (reverse column)");
                Console.WriteLine("   - The number of a row is determined by the leftmost or topmost pitch (p0 is not row 0,\n     it's the row that starts with 0)");
                Console.WriteLine(" - You pick a tone row and add it to the music.");
                Console.WriteLine(" - The result will sound very random, even more than if the notes are truly randomly generated");
                Console.WriteLine("This program takes 12 tone serialism a step further, with what is called Total Serialism.");
                Console.WriteLine("Not only are the pitches determined by the matrix, but the rhythms as well");
                Console.WriteLine("(Boulez took this even further, serializing things like dynamics and articulation.)");
                Console.WriteLine("My program gets the rhythms by taking the farthest and opposite row from the one that is chosen.");
                Console.WriteLine(" - For example, if its a Prime row, it will choose a Retrograde Inverse column starting 6 away.");
                Console.WriteLine("Once you're done choosing tone rows, this program will generate a midi using the DryWetMidi");
                Console.WriteLine(" library, and write it to myMidi.mid in the bin folder.");
                Console.WriteLine("This midi can be played back from any midi player, and even creates playable music if imported\n into a notation software like MuseScore!");
            }
        }
    }
    public void MakeRow(ToneRow newRow, bool hand){
        Console.Write("Pick a row (0-11): ");
        int input = int.Parse(Console.ReadLine());
        if (input >=0 && input < 12){
            newRow.SetToneRow(this, input);
            if (hand){
                _midiDataRight.Add(newRow);
            } else {
                _midiDataLeft.Add(newRow);
            }
            newRow.GetToneRow();
            newRow.GetRhythmRow();
        } else {
            Console.WriteLine("That is not a valid row.");
        }  
    }
    private void MakeRandomRow(ToneRow newRow, bool hand, Random rnd, int i){
        if (i == 0){ //The first row in the piece should be the first row in the matrix.
            newRow.SetToneRow(this, _matrix[0][0]);
        } else {
            newRow.SetToneRow(this, rnd.Next(0,12));
        }
        if (hand){
            _midiDataRight.Add(newRow);
        } else {
            _midiDataLeft.Add(newRow);
        }
    }
}