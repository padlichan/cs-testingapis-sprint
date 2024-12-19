using TestingAPIS.Models;

namespace TestingAPIS.Services
{
    public class JokeService
    {
        private readonly JokeRepository _jokeRepository = new JokeRepository();
        public IEnumerable<Joke> GetAllJokes()
        {
            return _jokeRepository.FindAllJokes();
        }
    }
}
