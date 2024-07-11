namespace Trivia.ConsoleUI
{
    public interface IGame
    {
        void Add(string playerName);
        bool IsPlayable();
        void Roll(int roll);
        bool WasCorrectlyAnswered();
        bool WrongAnswer();
    }
}