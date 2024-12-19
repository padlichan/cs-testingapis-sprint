using TestingAPIS.Models;

namespace TestingAPIS.Services
{
    public class JokeService
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
