using FluentAssertions;
using TestingAPIS.Models;

namespace TestingAPIS.Tests.ModelTests
{
    internal class JokeRepositoryTest
    {
        private JokeRepository jokeRepository;
        [SetUp]
        public void Setup()
        {
            jokeRepository = new JokeRepository();
        }

        [Test]
        public void AddTest_ReturnsNewJokeWithIdAdded()
        {
            //Arrangle
            Joke input = new Joke
            {
                Id = 1,
                SetupLine = "Why don't skeletons fight each other?",
                PunchLine = "They don't have the guts.",
                Category = "Puns",
                IsFunny = true
            };

            var expectedId = jokeRepository.FindAllJokes().Last().Id + 1;

            Joke expectedResult = new Joke
            {
                Id = expectedId,
                SetupLine = input.SetupLine,
                PunchLine = input.PunchLine,
                Category = input.Category,
                IsFunny = input.IsFunny
            };

            //Act

            var result = jokeRepository.AddJoke(input);
            result.Should().BeEquivalentTo(expectedResult);
        }
    }
}
