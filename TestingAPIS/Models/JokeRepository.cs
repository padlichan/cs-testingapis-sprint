using System.Text.Json;

namespace TestingAPIS.Models
{
    public interface IJokeRepository 
    {
        public IEnumerable<Joke> FindAllJokes();
        public Joke AddJoke(Joke joke);
        public bool DeleteJoke(int id);
    }
    public class JokeRepository : IJokeRepository
    {
        public IEnumerable<Joke> FindAllJokes()
        {
            var jokes = ReadData();
            return jokes;
        }

        public Joke AddJoke(Joke joke)
        {
            var jokes = FindAllJokes().ToList();
            joke.Id = jokes.Last().Id + 1;
            jokes.Add(joke);
            WriteData(jokes);
            return joke;
        }

        public bool DeleteJoke(int id)
        {
            var jokes = FindAllJokes().ToList();
            Joke? jokeToDelete = jokes.Where(j => j.Id == id).FirstOrDefault();

            if(jokeToDelete == null) return false;

            jokes.Remove(jokeToDelete);
            WriteData(jokes);
            return true;
        }

        private List<Joke> ReadData()
        {
            var jsonJokes = File.ReadAllText("Resources\\Jokes.json");
            var jokes = JsonSerializer.Deserialize<List<Joke>>(jsonJokes);
            if (jokes == null) return [];
            return jokes;
        }

        private void WriteData(List<Joke> jokes)
        {
            File.WriteAllText("Resources\\Jokes.json", JsonSerializer.Serialize(jokes));
        }
    }
}
