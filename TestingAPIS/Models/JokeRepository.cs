﻿using System.Text.Json;

namespace TestingAPIS.Models
{
    public interface IJokeRepository { public IEnumerable<Joke> FindAllJokes(); }
    public class JokeRepository : IJokeRepository
    {
        public IEnumerable<Joke> FindAllJokes()
        {
            var jsonJokes = File.ReadAllText("Resources\\Jokes.json");
            var jokes = JsonSerializer.Deserialize<List<Joke>>(jsonJokes);
            return jokes;
        }
    }
}
