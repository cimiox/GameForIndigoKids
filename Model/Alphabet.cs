using Model.Letters;
using System.Collections.ObjectModel;

namespace Model
{
    public class Alphabet
    {
        public ObservableCollection<KeybordLetter> Letters { get; set; }

        public KeybordLetter this[int index]
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

        public Alphabet(ObservableCollection<KeybordLetter> letters)
        {
            Letters = letters;
        }
    }
}
