using System;
using System.Collections.Generic;
using System.Linq;

namespace Trivia.ConsoleUI
{
    public class Questions
    {
        private readonly LinkedList<string> _popQuestions = new LinkedList<string>();
        private readonly LinkedList<string> _scienceQuestions = new LinkedList<string>();
        private readonly LinkedList<string> _sportsQuestions = new LinkedList<string>();
        private readonly LinkedList<string> _rockQuestions = new LinkedList<string>();

        private readonly Dictionary<QuestionCategory, LinkedList<string>> questions = new Dictionary<QuestionCategory, LinkedList<string>>();

        public Questions()
        {
            for (var i = 0; i < 50; i++)
            {
                _popQuestions.AddLast("Pop Question " + i);
                _scienceQuestions.AddLast("Science Question " + i);
                _sportsQuestions.AddLast("Sports Question " + i);
                _rockQuestions.AddLast("Rock Question " + i);
            }

            questions.Add(QuestionCategory.Pop, _popQuestions);
            questions.Add(QuestionCategory.Science, _scienceQuestions);
            questions.Add(QuestionCategory.Sports, _sportsQuestions);
            questions.Add(QuestionCategory.Rock, _rockQuestions);
        }

        public string GenerateQuestion(int index)
        {
            string question = "";
            switch (CurrentCategory(index))
            {
                case QuestionCategory.Pop:
                    question = _popQuestions.First();
                    _popQuestions.RemoveFirst();
                    break;
                case QuestionCategory.Science:
                    question = _scienceQuestions.First();
                    _scienceQuestions.RemoveFirst();
                    break;
                case QuestionCategory.Sports:
                    question = _sportsQuestions.First();
                    _sportsQuestions.RemoveFirst();
                    break;
                case QuestionCategory.Rock:
                    question = _rockQuestions.First();
                    _rockQuestions.RemoveFirst();
                    break;
            }

            return question;
        }

        public enum QuestionCategory
        {
            Pop,
            Science,
            Sports,
            Rock
        }

        public QuestionCategory CurrentCategory(int index)
        {
            int modulo = index % 4;
            return modulo switch
            {
                0 => QuestionCategory.Pop,
                1 => QuestionCategory.Science,
                2 => QuestionCategory.Sports,
                3 => QuestionCategory.Rock,
                _ => throw new NotImplementedException($"Category for {modulo} is not implemented.")
            };
        }
    }
}
