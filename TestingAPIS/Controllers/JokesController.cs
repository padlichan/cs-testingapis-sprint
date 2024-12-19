using Microsoft.AspNetCore.Mvc;
using TestingAPIS.Services;

namespace TestingAPIS.Controllers
{
    [Route("[controller]")]
    public class JokesController : ControllerBase
    {
        private readonly JokeService _jokeService;

        public JokesController(JokeService jokeService)
        {
            _jokeService = jokeService;
        }
        [HttpGet]
        public IEnumerable<Joke> Index()
        {
            return _jokeService.GetAllJokes();
        }
    }
}
