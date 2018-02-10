using System.ComponentModel;

namespace Model
{
    public class Player : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int attempts;
        public int Attempts
        {
            get { return attempts; }
            set
            {
                attempts = value;
                OnPropertyChanged("Attempts");
            }
        }


        private int score;
        public int Score
        {
            get { return score; }
            set
            {
                score = value;
                OnPropertyChanged("Score");
            }
        }

        public UniqueWords UniqueWords { get; private set; }

        public Player(int attempts, int score, UniqueWords uniqueWords)
        {
            Attempts = attempts;
            Score = score;
            UniqueWords = uniqueWords;
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
