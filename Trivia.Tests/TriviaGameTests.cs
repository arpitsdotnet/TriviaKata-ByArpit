using System;
using Trivia.ConsoleUI;
using Xunit;

namespace Trivia.Tests
{
    public class TriviaGameTests
    {
        [Fact]
        public void IsPlayable_ShouldReturnsFalse_WhenNoPlayersAreAdded()
        {
            // Arrange
            var game = new Game();

            // Act
            var isPlayable = game.IsPlayable();

            // Assert
            Assert.False(isPlayable);

        }

        [Fact]
        public void IsPlayable_ShouldReturnsFalse_WhenLessThanTwoPlayersAreAdded()
        {
            // Arrange
            var game = new Game();
            game.Add("Foo");

            // Act
            var isPlayable = game.IsPlayable();

            // Assert
            Assert.False(isPlayable);
        }

        [Fact]
        public void IsPlayable_ShouldReturnsTrue_WhenMoreOrEqualToTwoPlayersAreAdded()
        {
            // Arrange
            var game = new Game();
            game.Add("Foo");
            game.Add("Bar");

            // Act
            var isPlayable = game.IsPlayable();

            // Assert
            Assert.True(isPlayable);
        }

        [Fact]
        public void HowManyPlayers_ShouldReturns0_WhenNoPlayersAreAdded()
        {
            // Arrange
            var game = new Game();

            // Act
            var noOfPlayers = game.HowManyPlayers();

            // Assert
            Assert.Equal(0, noOfPlayers);

        }

        [Fact]
        public void HowManyPlayers_ShouldReturns1_WhenOnePlayersAreAdded()
        {
            // Arrange
            var game = new Game();
            game.Add("Foo");

            // Act
            var noOfPlayers = game.HowManyPlayers();

            // Assert
            Assert.Equal(1, noOfPlayers);

        }

        [Fact]
        public void HowManyPlayers_ShouldReturns2_WhenTwoPlayersAreAdded()
        {
            // Arrange
            var game = new Game();
            game.Add("Foo");
            game.Add("Bar");

            // Act
            var noOfPlayers = game.HowManyPlayers();

            // Assert
            Assert.Equal(2, noOfPlayers);

        }
    }
}
