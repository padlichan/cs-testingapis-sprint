using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingAPIS.Controllers;
using TestingAPIS.Services;

namespace TestingAPIS.Tests.ControllerTests
{
    internal class JokeControllerTest
    {
        private JokesController jokesController;
        private Mock<IJokeService> mockJokeService;
        private List<Joke> jokes = [];

        [SetUp]
        public void Setup()
        {
            mockJokeService = new Mock<IJokeService>();
            jokesController = new JokesController(mockJokeService.Object);

            Joke joke1 = new Joke
            {
                Id = 1,
                SetupLine = "Why don't skeletons fight each other?",
                PunchLine = "They don't have the guts.",
                Category = "Puns",
                IsFunny = true
            };
            Joke joke2 = new Joke
            {
                Id = 2,
                SetupLine = "Why did the scarecrow win an award?",
                PunchLine = "Because he was outstanding in his field.",
                Category = "Wordplay",
                IsFunny = true
            };
            Joke joke3 = new Joke
            {
                Id = 3,
                SetupLine = "Why don’t scientists trust atoms?",
                PunchLine = "Because they make up everything!",
                Category = "Science",
                IsFunny = true
            };

            jokes.Add(joke1);
            jokes.Add(joke2);
            jokes.Add(joke3);
        }

        [Test]
        public void Index_ReturnsAllJokeS()
        {
            //Arrange
            mockJokeService.Setup(m => m.GetAllJokes()).Returns(jokes);

            //Act
            var result = jokesController.Index();

            //Assert

            Assert.That(result, Is.EquivalentTo(jokes));

        }
    }
}
