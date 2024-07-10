using System;
using System.Collections.Generic;
using Trivia.ConsoleUI;
using Xunit;
using FluentAssertions;

namespace Trivia.Tests
{
    public class TriviaGameTests
    {
        [Fact]
        // - Initially be Unplayable
        public void IsPlayable_ShouldReturnsFalse_WhenNoPlayersAreAdded()
        {
            // Arrange
            var sut = new Game();

            // Act
            var isPlayable = sut.IsPlayable();

            // Assert
            isPlayable.Should().BeFalse();
        }

        [Fact]
        // - Add a Player
        public void IsPlayable_ShouldReturnsFalse_WhenLessThanTwoPlayersAreAdded()
        {
            // Arrange
            const string playerName = "Foo";
            var log = new List<string>();
            var sut = new Game(log.Add);
            sut.Add(playerName);

            // Act
            var isPlayable = sut.IsPlayable();

            // Assert
            isPlayable.Should().BeFalse();
            log.Count.Should().Be(2);
            log[0].Should().Be($"{playerName} was added");
            log[1].Should().Be($"They are player number 1");
        }

        [Fact]
        // - Add two Players
        public void IsPlayable_ShouldReturnsTrue_WhenMoreOrEqualToTwoPlayersAreAdded()
        {
            // Arrange
            const string playerName1 = "Foo";
            const string playerName2 = "Bar";
            var log = new List<string>();
            var sut = new Game(log.Add);
            sut.Add(playerName1);
            sut.Add(playerName2);

            // Act
            var isPlayable = sut.IsPlayable();

            // Assert
            isPlayable.Should().BeTrue();
            log.Count.Should().Be(4);
            log[0].Should().Be($"{playerName1} was added");
            log[1].Should().Be($"They are player number 1");
            log[2].Should().Be($"{playerName2} was added");
            log[3].Should().Be($"They are player number 2");
        }

        [Fact]
        // - Add three Players
        public void IsPlayable_ShouldReturnsTrue_WhenMoreOrEqualToThreePlayersAreAdded()
        {
            // Arrange
            const string playerName1 = "Foo";
            const string playerName2 = "Bar";
            const string playerName3 = "FooBar";
            var log = new List<string>();
            var sut = new Game(log.Add);
            sut.Add(playerName1);
            sut.Add(playerName2);
            sut.Add(playerName3);

            // Act
            var isPlayable = sut.IsPlayable();

            // Assert
            isPlayable.Should().BeTrue();
            log.Count.Should().Be(6);
            log[0].Should().Be($"{playerName1} was added");
            log[1].Should().Be($"They are player number 1");
            log[2].Should().Be($"{playerName2} was added");
            log[3].Should().Be($"They are player number 2");
            log[4].Should().Be($"{playerName3} was added");
            log[5].Should().Be($"They are player number 3");
        }

        [Fact]
        public void HowManyPlayers_ShouldReturns0_WhenNoPlayersAreAdded()
        {
            // Arrange
            var sut = new Game();

            // Act
            var noOfPlayers = sut.HowManyPlayers();

            // Assert
            Assert.Equal(0, noOfPlayers);

        }

        [Fact]
        public void HowManyPlayers_ShouldReturns1_WhenOnePlayersAreAdded()
        {
            // Arrange
            var sut = new Game();
            sut.Add("Foo");

            // Act
            var noOfPlayers = sut.HowManyPlayers();

            // Assert
            Assert.Equal(1, noOfPlayers);

        }

        [Fact]
        public void HowManyPlayers_ShouldReturns2_WhenTwoPlayersAreAdded()
        {
            // Arrange
            var sut = new Game();
            sut.Add("Foo");
            sut.Add("Bar");

            // Act
            var noOfPlayers = sut.HowManyPlayers();

            // Assert
            Assert.Equal(2, noOfPlayers);

        }

        [Fact]
        public void HowManyPlayers_ShouldReturns3_WhenThreePlayersAreAdded()
        {
            // Arrange
            var sut = new Game();
            sut.Add("Foo");
            sut.Add("Bar");
            sut.Add("FooBar");

            // Act
            var noOfPlayers = sut.HowManyPlayers();

            // Assert
            Assert.Equal(3, noOfPlayers);

        }
    }
}
