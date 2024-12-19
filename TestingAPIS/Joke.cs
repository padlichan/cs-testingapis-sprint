namespace TestingAPIS
{
    public class Joke
    {
        public int Id { get; set; }
        public string SetupLine { get; set; } = "";
        public string PunchLine { get; set; } = "";
        public string Category { get; set; } = "";
        public bool IsFunny { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}\nSetupLine: {SetupLine}\nPunchLine: {PunchLine}\nCategory: {Category}\nIsFunny: {IsFunny}";
        }
    }
}
