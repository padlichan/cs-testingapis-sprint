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

        [Test]
        public void DeleteJoke_ReturnTrue_ValidId()
        {
            //This relies on the repo having at least one joke
            int validId = jokeRepository.FindAllJokes().First().Id;
            var result = jokeRepository.DeleteJoke(validId);
            result.Should().BeTrue();
        }

        [Test]
        public void DeleteJoke_ReturnFalse_InvalidId()
        {
            //This relies on not having a joke with Id = 999
            int invalidId = 999;
            var result = jokeRepository.DeleteJoke(invalidId);
            result.Should().BeFalse();
        }

        [Test]
        public void DeleteJoke_DeletesJoke()
        {
            int validId = 1;

            jokeRepository.DeleteJoke(validId);
            bool existsJoke = jokeRepository.FindAllJokes().Any(j => j.Id == validId);
            existsJoke.Should().BeFalse();
        }

    }
}
