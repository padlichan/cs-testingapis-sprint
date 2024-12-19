using Microsoft.AspNetCore.Mvc;
using TestingAPIS.Services;

namespace TestingAPIS.Controllers
{
    [Route("[controller]")]
    public class JokesController : ControllerBase
    {
        private readonly IJokeService _jokeService;

        public JokesController(IJokeService jokeService)
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
