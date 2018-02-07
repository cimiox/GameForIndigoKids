using Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniqueWordsFactory
{
    public UniqueWords CreateUniqueWords()
    {
        return new UniqueWords(new System.Collections.ObjectModel.ObservableCollection<UniqueWord>());
    }
}
