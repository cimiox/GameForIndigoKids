using Model;
using UnityEngine;

public class PlayerHandler : ScriptableObject
{
    [SerializeField, Tooltip("Стартовое количество попыток")]
    private int StartScores;
    [SerializeField, Tooltip("Минимальная длина слов")]
    private int MinWordsLength;

    public Player Player { get; set; }

    public int Scores
    {
        get
        {
            return Player.Score;
        }
        set
        {
            Player.Score = value;
        }
    }

    public UniqueWords UniqueWords
    {
        get
        {
            return Player.UniqueWords;
        }
    }

    public Alphabet Alphabet
    {
        get
        {
            return Player.Alphabet;
        }
    }

    public void Intialize(TextAsset textAsset)
    {
        var uniqueWordsFactory = new UniqueWordsFactory();
        var alphabetFactory = new EnglishAlphabetFactory();
        Player = new Player(StartScores, alphabetFactory.CreateAlphabet(), uniqueWordsFactory.CreateUniqueWords(textAsset, MinWordsLength));
    }
}
