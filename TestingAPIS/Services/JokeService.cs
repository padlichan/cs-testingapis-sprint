﻿using TestingAPIS.Models;

namespace TestingAPIS.Services
{
    public interface IJokeService 
    {
        public IEnumerable<Joke> GetAllJokes();
        public Joke AddJoke(Joke joke);

        public bool DeleteJoke(int id);
    }
    public class JokeService : IJokeService
    {
        private readonly IJokeRepository _jokeRepository;

        public JokeService(IJokeRepository jokeRepository)
        {
            _jokeRepository = jokeRepository;
        }

        public IEnumerable<Joke> GetAllJokes()
        {
            return _jokeRepository.FindAllJokes();
        }

        public Joke AddJoke(Joke joke)
        {
            return _jokeRepository.AddJoke(joke);
        }

        public bool DeleteJoke(int id)
        {
            return _jokeRepository.DeleteJoke(id);
        }
    }
}
