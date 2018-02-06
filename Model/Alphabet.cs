using System.Collections.ObjectModel;

namespace Model
{
    public class Alphabet
    {
        public ObservableCollection<Letter> Letters { get; set; }

        public Letter this[int index]
        {
            set
            {
                Letters[index] = value;
            }
            get
            {
                return Letters[index];
            }
        }

        public Alphabet(ObservableCollection<Letter> letters)
        {
            Letters = letters;
        }
    }
}
