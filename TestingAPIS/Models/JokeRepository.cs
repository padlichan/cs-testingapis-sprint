using System.Text.Json;

namespace TestingAPIS.Models
{
    public interface IJokeRepository 
    {
        public IEnumerable<Joke> FindAllJokes();
        public Joke AddJoke(Joke joke);
    }
    public class JokeRepository : IJokeRepository
    {
        public IEnumerable<Joke> FindAllJokes()
        {
            var jsonJokes = File.ReadAllText("Resources\\Jokes.json");
            var jokes = JsonSerializer.Deserialize<List<Joke>>(jsonJokes);
            return jokes;
        }

        public Joke AddJoke(Joke joke)
        {
            var jokes = FindAllJokes().ToList();
            joke.Id = jokes.Last().Id + 1;
            jokes.Add(joke);
            File.WriteAllText("Resources\\Jokes.json", JsonSerializer.Serialize(jokes));
            return joke;
        }
    }
}
