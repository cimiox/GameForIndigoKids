using Model;
using UnityEngine;

/// <summary>
/// ViewModel для Player, хранит в себе Player и стартовые значения
/// </summary>
public class PlayerHandler : ScriptableObject
{
    [Tooltip("Стартовое количество попыток")]
    public int StartAttempts;
    [SerializeField, Tooltip("Минимальная длина слов")]
    private int MinWordsLength;

    public Player Player { get; set; }

    public int Scores
    {
        get { return Player.Score; }
        set { Player.Score = value; }
    }

    public int Attempts
    {
        get { return Player.Attempts; }
        set { Player.Attempts = value; }
    }

    public UniqueWords UniqueWords
    {
        get { return Player.UniqueWords; }
    }

    public void Intialize(TextAsset textAsset)
    {
        var uniqueWordsFactory = new UniqueWordsFactory();

        Player = new Player(StartAttempts, 0, uniqueWordsFactory.CreateUniqueWords(textAsset, MinWordsLength));
    }
}
