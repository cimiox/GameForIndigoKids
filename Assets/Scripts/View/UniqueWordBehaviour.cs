using Model;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Обработчик слова которое нужно разгадать
/// </summary>
public class UniqueWordBehaviour : MonoBehaviour
{
    private UniqueWord uniqueWord;
    public UniqueWord UniqueWord
    {
        get { return uniqueWord; }
        set
        {
            if (value != uniqueWord)
            {
                uniqueWord = value;
                Initialize();
            }
        }
    }

    private string uniqueWordLetterPrefabPath = "UniqueWordLetter";
    private GameObject UniqueWordLetterPrefabPath
    {
        get
        {
            return Resources.Load<GameObject>(uniqueWordLetterPrefabPath);
        }
    }

    private void Initialize()
    {
        foreach (var item in UniqueWord.Word)
        {
            var keybordLetterGO = Instantiate(UniqueWordLetterPrefabPath, transform);
            keybordLetterGO.GetComponent<UniqueWordLetterBehaviour>().SetParameters(item);
        }
    }

    public void Refresh()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
    }
}
