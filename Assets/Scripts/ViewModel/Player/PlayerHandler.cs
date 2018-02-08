using Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : ScriptableObject
{
    [SerializeField, Tooltip("Стартовое количество попыток")]
    private int StartScores;
    [SerializeField, Tooltip("Минимальная длина слов")]
    private int MinWordsLength;

    public Player Player { get; set; }

    public void Intialize(TextAsset textAsset)
    {
        var uniqueWordsFactory = new UniqueWordsFactory();
        var alphabetFactory = new EnglishAlphabetFactory();
        Player = new Player(StartScores, alphabetFactory.CreateAlphabet(), uniqueWordsFactory.CreateUniqueWords(textAsset, MinWordsLength));
    }
}
