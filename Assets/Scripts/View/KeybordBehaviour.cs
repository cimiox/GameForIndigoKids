using Model;
using UnityEngine;

/// <summary>
/// View для клавиатуры, обрабатывает инциализацию кнопок клавиатуры
/// </summary>
public class KeybordBehaviour : MonoBehaviour
{
    private Alphabet alphabet;
    public Alphabet Alphabet
    {
        get { return alphabet; }
        set
        {
            if (value != alphabet)
            {
                alphabet = value;
                Initialize();
            }
        }
    }

    private string keybordLetterPrefabPath = "KeybordLetter";
    private GameObject KeybordLetterPrefab
    {
        get
        {
            return Resources.Load<GameObject>(keybordLetterPrefabPath);
        }
    }

    private void Initialize()
    {
        foreach (var item in Alphabet.Letters)
        {
            var keybordLetter = Instantiate(KeybordLetterPrefab, transform);
            keybordLetter.GetComponent<KeybordLetterBehaviour>().SetParameters(item);
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
