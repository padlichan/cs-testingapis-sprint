﻿using TestingAPIS.Services;
using Moq;
using TestingAPIS.Models;
using System.Drawing.Text;

namespace TestingAPIS.Tests.ServiceTests
{
    public class JokeServiceTest
    {
        // Configure the required properties
        private JokeService jokeService;
        private Mock<IJokeRepository> mockJokeRepository;
        private List<Joke> jokes = [];


        [SetUp]
        public void Setup()
        {
            // Instantiate the property values
            mockJokeRepository = new Mock<IJokeRepository>();
            jokeService = new JokeService(mockJokeRepository.Object);


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
        public void GetAllJokes_ReturnsAllJokes()
        {
            // ARRANGE
            mockJokeRepository.Setup(x => x.FindAllJokes()).Returns(jokes);

            // ACT
            var result = jokeService.GetAllJokes();

            // ASSERT
            Assert.That(result, Is.EquivalentTo(jokes));

        }
    }
}