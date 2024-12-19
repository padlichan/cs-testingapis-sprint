﻿using FluentAssertions;
using Moq;
using TestingAPIS.Controllers;
using TestingAPIS.Services;

namespace TestingAPIS.Tests.ControllerTests
{
    internal class JokeControllerTest
    {
        private JokesController jokesController;
        private Mock<IJokeService> mockJokeService;
        private List<Joke> jokes = [];
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

        [SetUp]
        public void Setup()
        {
            mockJokeService = new Mock<IJokeService>();
            jokesController = new JokesController(mockJokeService.Object);
        }

        [Test]
        public void Index_ReturnsAllJokeS()
        {
            //Arrange
            jokes.Add(joke1);
            jokes.Add(joke2);
            jokes.Add(joke3);
            mockJokeService.Setup(m => m.GetAllJokes()).Returns(jokes);

            //Act
            var result = jokesController.Index();

            //Assert

            Assert.That(result, Is.EquivalentTo(jokes));
        }
        [Test]
        public void PostJoke_InvokesServiceWithCorrectArgument()
        {
            //Arrange
            
            mockJokeService.Setup(m => m.AddJoke(joke1)).Returns(joke1);

            //Act 
            jokesController.PostJoke(joke1);
            mockJokeService.Verify(m => m.AddJoke(joke1), Times.Once);
        }

        [Test]
        public void PostJoke_ReturnsNewJokeWithIdAdded()
        {
            //Arrange
            Joke expectedResult = new Joke
            {
                Id = 4,
                SetupLine = joke1.SetupLine,
                PunchLine = joke1.PunchLine,
                Category = joke1.Category,
                IsFunny = joke1.IsFunny
            };
            mockJokeService.Setup(m => m.AddJoke(joke1)).Returns(expectedResult);

            //Act
            var result = jokesController.PostJoke(joke1);

            //Assert
            result.Should().Be(expectedResult);

        }
    }
}
