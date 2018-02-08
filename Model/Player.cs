using System.ComponentModel;

namespace Model
{
    public class Player : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

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

        public Alphabet Alphabet { get; private set; }
        public UniqueWords UniqueWords { get; private set; }

        public Player(int score, Alphabet alphabet, UniqueWords uniqueWords)
        {
            Score = score;
            Alphabet = alphabet;
            UniqueWords = uniqueWords;
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
