namespace TestingAPIS
{
    public class Joke
    {
        public int Id { get; set; }
        public string SetupLine { get; set; } = "";
        public string PunchLine { get; set; } = "";
        public string Category { get; set; } = "";
        public bool IsFunny { get; set; }
    }
}
