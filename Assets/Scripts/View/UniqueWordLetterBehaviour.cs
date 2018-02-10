using Model.Letters;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Обработчик буквы которую нужно разгадать
/// </summary>
public class UniqueWordLetterBehaviour : MonoBehaviour
{
    private UniqueWordLetter UniqueWordLetter { get; set; }
    private Text CharacterText;

    public void SetParameters(UniqueWordLetter uniqueWordLetter)
    {
        UniqueWordLetter = uniqueWordLetter;
        UniqueWordLetter.PropertyChanged += UniqueWordLetter_PropertyChanged;
        CharacterText = GetComponentInChildren<Text>();
        CharacterText.text = UniqueWordLetter.Character.ToString();
        CharacterText.gameObject.SetActive(false);
    }

    private void UniqueWordLetter_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if (e.PropertyName.Equals("IsOpen"))
            CharacterText.gameObject.SetActive(UniqueWordLetter.IsOpen);
    }
}
