using Model.Letters;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Обработчик для нажатий кнопки в клавиатуре
/// </summary>
[RequireComponent(typeof(Button))]
public class KeybordLetterBehaviour : MonoBehaviour
{
    public KeybordLetter KeybordLetter { get; set; }

    public void SetParameters(KeybordLetter keybordLetter)
    {
        KeybordLetter = keybordLetter;
        KeybordLetter.PropertyChanged += KeybordLetter_PropertyChanged;
        GetComponentInChildren<Text>().text = KeybordLetter.Character.ToString();
        GetComponent<Button>().onClick.AddListener(() => KeybordLetter.IsClicked = true);
    }

    private void KeybordLetter_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if (e.PropertyName.Equals("IsClicked"))
            gameObject.SetActive(!KeybordLetter.IsClicked);
    }
}

