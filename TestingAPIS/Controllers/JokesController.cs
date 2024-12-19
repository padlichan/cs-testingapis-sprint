using Microsoft.AspNetCore.Mvc;
using TestingAPIS.Services;

namespace TestingAPIS.Controllers
{
    [Route("[controller]")]
    [ApiController]
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

        [HttpPost]
        public IActionResult PostJoke(Joke joke)
        {
            if (string.IsNullOrEmpty(joke.PunchLine)) return BadRequest();
            return Ok(_jokeService.AddJoke(joke));
        }

        [HttpDelete("{id}")]

        public IActionResult DeleteJokeById(int id)
        {
             if(_jokeService.DeleteJoke(id)) return NoContent();
             return NotFound();
        }
    }
}
