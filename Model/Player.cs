namespace Model
{
    public class Player
    {
        public int Score { get; set; }
        public Alphabet Alphabet { get; set; }
        public UniqueWords UniqueWords { get; set; }

        public Player(int score, Alphabet alphabet, UniqueWords uniqueWords)
        {
            Score = score;
            Alphabet = alphabet;
            UniqueWords = uniqueWords;
        }
    }
}
