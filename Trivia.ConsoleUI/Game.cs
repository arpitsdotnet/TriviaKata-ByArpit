using System;
using System.Collections.Generic;

namespace Trivia.ConsoleUI
{
    public class Game : IGame
    {
        private readonly List<Player> _players = new List<Player>();

        private readonly Questions _question;

        private int _currentPlayer;
        private bool _isGettingOutOfPenaltyBox;

        private readonly Action<string> _writeOut;

        public Game(Action<string> writeOut = null, Questions question = null)
        {
            _writeOut = writeOut ?? Console.WriteLine;
            _question = question ?? new Questions();
        }

        public bool IsPlayable() =>
            _players.Count >= 2;

        public void Add(string playerName)
        {
            _players.Add(new Player(playerName));
            _writeOut(playerName + " was added");
            _writeOut("They are player number " + _players.Count);
        }

        private Player CurrentPlayer() =>
            _players[_currentPlayer];

        private void MovePlayer(int roll) =>
            CurrentPlayer().Move(roll);

        private void MoveToNextPlayerAndAskQuestion(int roll)
        {
            MovePlayer(roll);

            _writeOut($"{CurrentPlayer().Name}'s new location is {CurrentPlayer().Place}");
            _writeOut($"The category is {_question.CurrentCategory(CurrentPlayer().Place)}");

            AskQuestion();
        }

        public void Roll(int roll)
        {
            _writeOut($"{CurrentPlayer().Name} is the current player");
            _writeOut($"They have rolled a {roll}");

            if (CurrentPlayer().IsInPaneltyBox)
            {
                if (roll % 2 == 0)
                {
                    _writeOut($"{CurrentPlayer().Name} is not getting out of the penalty box");
                    return;
                }

                CurrentPlayer().MoveOutFromPaneltyBox();
                _writeOut($"{CurrentPlayer().Name} is getting out of the penalty box");
            }

            MoveToNextPlayerAndAskQuestion(roll);
        }

        private void AskQuestion()
        {
            string question = _question.GenerateQuestion(CurrentPlayer().Place);

            _writeOut(question);
        }

        public bool WasCorrectlyAnswered()
        {
            var result = aaa();
            MoveToNextPlayer();
            return result;
        }

        private bool aaa()
        {
            //TODO : possible bug: Shouldn't you exit the panelty box.
            if (CurrentPlayer().IsInPaneltyBox == true)
            {
                return true;
            }

            CurrentPlayer().AddCoin();

            _writeOut("Answer was correct!!!!");
            _writeOut($"{CurrentPlayer().Name} now has {CurrentPlayer().Coins} Gold Coins.");

            return CurrentPlayer().DidPlayerWin();

        }

        public bool WrongAnswer()
        {
            CurrentPlayer().MoveToPaneltyBox();

            _writeOut("Question was incorrectly answered");
            _writeOut(CurrentPlayer().Name + " was sent to the penalty box");

            MoveToNextPlayer();
            return true;
        }

        private void MoveToNextPlayer()
        {
            _currentPlayer++;
            if (_currentPlayer == _players.Count) _currentPlayer = 0;
        }

    }

}
