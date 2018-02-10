using System.Collections;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Счетчик для оставшихся попыток
/// </summary>
[RequireComponent(typeof(Text))]
public class AttemptsBehaviour : MonoBehaviour
{
    public PlayerHandler PlayerHandler { get; set; }
    public Text AttemptsText { get; set; }

    public IEnumerator Start()
    {
        yield return new WaitUntil(() => GameHandler.Instance.PlayerHandler != null);

        PlayerHandler = GameHandler.Instance.PlayerHandler;
        PlayerHandler.Player.PropertyChanged += Player_PropertyChanged;

        AttemptsText = GetComponent<Text>();
        AttemptsText.text = string.Format($"Attempts: {PlayerHandler.Attempts.ToString()}");
    }

    private void Player_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        switch (e.PropertyName)
        {
            case "Attempts":
                AttemptsText.text = string.Format($"Attempts: {PlayerHandler.Attempts.ToString()}");
                break;
        }
    }
}
