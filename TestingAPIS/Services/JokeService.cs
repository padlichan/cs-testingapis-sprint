using TestingAPIS.Models;

namespace TestingAPIS.Services
{
    public interface IJokeService { public IEnumerable<Joke> GetAllJokes(); }
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
    }
}
