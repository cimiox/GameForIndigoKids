using System.Collections.ObjectModel;

namespace Model
{
    public class UniqueWords
    {
        public ObservableCollection<UniqueWord> Words { get; set; }

        public UniqueWord this[int index]
        {
            set
            {
                Words[index] = value;
            }
            get
            {
                return Words[index];
            }
        }

        public UniqueWords(ObservableCollection<UniqueWord> words)
        {
            Words = words;
        }
    }
}
