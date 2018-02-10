using Model;
using Model.Letters;
using System.Linq;

/// <summary>
/// Инициализирует слово(которое нужно разгадать) и клавиатуру, а так же открытие букв в слове
/// </summary>
public class LevelHandler
{
    public delegate void LevelComplete(UniqueWord uniqueWord);
    public event LevelComplete OnLevelComplete;

    public delegate void OpenLetter(bool isOpened);
    public event OpenLetter OnOpenLetter;

    public UniqueWord UniqueWord { get; set; }
    public Alphabet Alphabet { get; set; }

    public LevelHandler(UniqueWord uniqueWord, Alphabet alphabet)
    {
        UniqueWord = uniqueWord;
        Alphabet = alphabet;
    }

    public void Intialize()
    {
        foreach (var item in Alphabet.Letters)
        {
            item.PropertyChanged += Item_PropertyChanged;
        }
    }

    private void Item_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if (e.PropertyName.Equals("IsClicked"))
        {
            if ((sender as KeybordLetter).IsClicked)
                OpenLetterInWord((sender as KeybordLetter));
        }
    }

    public void OpenLetterInWord(Letter letter)
    {
        var lettersInWord = UniqueWord.Word.Where(x => x.Character == letter.Character).ToList();

        if (UniqueWord.Word.FirstOrDefault(x => x.Character == letter.Character) != null)
        {
            for (int i = 0; i < lettersInWord.Count; i++)
                lettersInWord[i].IsOpen = true;

            if (UniqueWord.Word.All(x => x.IsOpen))
                OnLevelComplete?.Invoke(UniqueWord);

            OnOpenLetter?.Invoke(true);
        }
        else
            OnOpenLetter?.Invoke(false);
    }
}
