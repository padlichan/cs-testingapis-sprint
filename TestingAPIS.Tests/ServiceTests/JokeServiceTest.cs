using TestingAPIS.Services;
using Moq;
using TestingAPIS.Models;
using FluentAssertions;

namespace TestingAPIS.Tests.ServiceTests
{
    public class JokeServiceTest
    {
        // Configure the required properties
        private JokeService jokeService;
        private Mock<IJokeRepository> mockJokeRepository;
        private Joke joke1 = new Joke
        {
            Id = 1,
            SetupLine = "Why don't skeletons fight each other?",
            PunchLine = "They don't have the guts.",
            Category = "Puns",
            IsFunny = true
        };
        private Joke joke2 = new Joke
        {
            Id = 2,
            SetupLine = "Why did the scarecrow win an award?",
            PunchLine = "Because he was outstanding in his field.",
            Category = "Wordplay",
            IsFunny = true
        };
        private Joke joke3 = new Joke
        {
            Id = 3,
            SetupLine = "Why don’t scientists trust atoms?",
            PunchLine = "Because they make up everything!",
            Category = "Science",
            IsFunny = true
        };
        private List<Joke> jokes = [];


        [SetUp]
        public void Setup()
        {
            // Instantiate the property values
            mockJokeRepository = new Mock<IJokeRepository>();
            jokeService = new JokeService(mockJokeRepository.Object);
        }

        [Test]
        public void GetAllJokes_ReturnsAllJokes()
        {
            // ARRANGE
            mockJokeRepository.Setup(x => x.FindAllJokes()).Returns(jokes);
            jokes.Add(joke1);
            jokes.Add(joke2);
            jokes.Add(joke3);

            // ACT
            var result = jokeService.GetAllJokes();

            // ASSERT
            Assert.That(result, Is.EquivalentTo(jokes));
        }

        [Test]
        public void PostJoke_ReturnsNewJokeWithIdAdded()
        {
            Joke expectedResult = new Joke
            {
                Id = 4,
                SetupLine = joke1.SetupLine,
                PunchLine = joke1.PunchLine,
                Category = joke1.Category,
                IsFunny = joke1.IsFunny
            };
            mockJokeRepository.Setup(m => m.AddJoke(joke1)).Returns(expectedResult);

            var result = jokeService.AddJoke(joke1);

            result.Should().Be(expectedResult);
        }

        [Test]
        public void PostJoke_InvokesModelWithCorrectArgumentOnce()
        {
            mockJokeRepository.Setup(m => m.AddJoke(joke1)).Returns(joke1);

            jokeService.AddJoke(joke1);

            mockJokeRepository.Verify(m => m.AddJoke(joke1), Times.Once);
        }

        [Test]
        public void DeleteJoke_ReturnTrue_ValidId()
        {
            int validId = 1;
            mockJokeRepository.Setup(m => m.DeleteJoke(validId)).Returns(true);

            var result = jokeService.DeleteJoke(validId);

            result.Should().BeTrue();
        }

        [Test]
        public void DeleteJoke_ReturnFalse_InvalidId()
        {
            int invalidId = 1;
            mockJokeRepository.Setup(m => m.DeleteJoke(invalidId)).Returns(false);

            var result = jokeService.DeleteJoke(invalidId);

            result.Should().BeFalse();
        }

        [Test]
        public void DeleteJoke_InvokesModelWithCorrectArgumentOnce()
        {
            int id = 1;
            mockJokeRepository.Setup(m => m.DeleteJoke(id)).Returns(true);

            jokeService.DeleteJoke(id);

            mockJokeRepository.Verify(m => m.DeleteJoke(id), Times.Once);
        }
        
    }
}
