using Model;
using Model.Letters;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UniqueWordsFactory
{
    /// <summary>
    /// Отбирает уникальные слова из <paramref name="textAsset"/>
    /// </summary>
    /// <param name="textAsset">Текст для отбора слов</param>
    /// <param name="minWordsLength">Минимальная длина слова</param>
    /// <returns>Объект содержащий коллекцию уникальных слов</returns>
    public UniqueWords CreateUniqueWords(TextAsset textAsset, int minWordsLength)
    {
        var words = textAsset.text
            .Split(new char[] { ' ', '.', ',', ':', '!', '?', '\t', '\n', '\'', ';', '`', ')', '(', '\"' }, StringSplitOptions.RemoveEmptyEntries)
            .ToList();

        for (int i = 0; i < words.Count; i++)
        {
            words[i] = words[i].Trim();
            words[i] = words[i].ToLower();
            words[i] = words[i].Replace("-", "");
        }

        words = words.Where(x => x.Length >= minWordsLength).ToList();

        var uniqueWords = words
            .GroupBy(x => x)
            .Where(x => x.Count() == 1)
            .Select(x => new UniqueWord(new List<UniqueWordLetter>(x.Key.ToCharArray().Select(c => new UniqueWordLetter(c)))));

        //Random Sort
        System.Random random = new System.Random();
        uniqueWords = uniqueWords.OrderBy(x => random.Next()).ToList();

        return new UniqueWords(new System.Collections.ObjectModel.ObservableCollection<UniqueWord>(uniqueWords));
    }
}
