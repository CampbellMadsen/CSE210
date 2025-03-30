using System.Diagnostics.Contracts;

class Fisherman: Person {
    private string _fishingRod;
    public Fisherman(string rod, string firstName, string lastName, int age): base(firstName, lastName, age){
        _fishingRod = rod;
    }
    public string GetFishermanInfo(){
        return $"{_fishingRod}, {GetPersonInfo()}";
    }
    public override string GetName()
    {
        return $"sergeant {base.GetName()}";
    }
    public override string GetHobbies()
    {
        return "fishing";
    }
}