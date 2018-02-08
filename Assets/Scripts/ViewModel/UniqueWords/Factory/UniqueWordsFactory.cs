using Model;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UniqueWordsFactory
{
    public UniqueWords CreateUniqueWords(TextAsset textAsset, int minWordsLength)
    {
        var words = textAsset.text
            .Split(' ', '.', ',', ':', '!', '?', '\t')
            .Where(x => x.Length >= minWordsLength)
            .ToList();
        words.ForEach(x => x = x.Trim());
        words.ForEach(x => x = x.ToLower());
        var uniqueWords = words.GroupBy(x => x).Where(x => x.Count() == 1).Select(x => new UniqueWord(x.Key));

        return new UniqueWords(new System.Collections.ObjectModel.ObservableCollection<UniqueWord>(uniqueWords));
    }
}
