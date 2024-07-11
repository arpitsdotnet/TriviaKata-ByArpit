namespace Trivia.ConsoleUI
{
    public class Player
    {
        public string Name { get; private set; }
        public int Place { get; private set; } = 0;
        public int Coins { get; private set; } = 0;
        public bool IsInPaneltyBox { get; private set; } = false;

        public Player(string name)
        {
            Name = name;
        }
        public void Move(int roll)
        {
            Place += roll;
            //Reset Place When Place Exedded 12
            //if (Place >= 12)
            //    Place = 0;
            Place %= 12;
        }

        public void AddCoin()
        {
            Coins++;
        }

        public void MoveToPaneltyBox()
        {
            IsInPaneltyBox = true;
        }

        public void MoveOutFromPaneltyBox()
        {
            IsInPaneltyBox = false;
        }

        public bool DidPlayerWin()
        {
            return !(Coins == 6);
        }
    }

}
