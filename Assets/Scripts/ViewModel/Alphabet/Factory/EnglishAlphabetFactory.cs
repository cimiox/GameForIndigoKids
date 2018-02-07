using Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

public class EnglishAlphabetFactory : AlphabetFactory
{
    private readonly IEnumerable<char> Alphabet;

    public EnglishAlphabetFactory()
    {
        Alphabet = Enumerable.Range('a', 'z' - 'a' + 1).Select(c => (char)c);
    }

    public override Alphabet CreateAlphabet()
    {
        return new Alphabet(new ObservableCollection<Letter>(Alphabet.Select(x => new Letter(x))));
    }
}
