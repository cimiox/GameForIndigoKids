using Model.Letters;
using System.Collections.Generic;

namespace Model
{
    public class UniqueWord
    {
        public List<UniqueWordLetter> Word { get; set; }

        public UniqueWord(List<UniqueWordLetter> word)
        {
            Word = word;
        }
    }
}
