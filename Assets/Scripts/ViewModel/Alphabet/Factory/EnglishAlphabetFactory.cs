using Model;
using Model.Letters;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

/// <summary>
/// Фабрика для Английского алфавита
/// </summary>
public class EnglishAlphabetFactory : AlphabetFactory
{
    private readonly IEnumerable<char> Alphabet;

    public EnglishAlphabetFactory()
    {
        Alphabet = Enumerable.Range('a', 'z' - 'a' + 1).Select(c => (char)c);
    }

    public override Alphabet CreateAlphabet()
    {
        return new Alphabet(new ObservableCollection<KeybordLetter>(Alphabet.Select(x => new KeybordLetter(x))));
    }
}
