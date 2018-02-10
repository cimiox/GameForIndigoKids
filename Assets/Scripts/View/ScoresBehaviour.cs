using System.Collections;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Счетчик очков
/// </summary>
[RequireComponent(typeof(Text))]
public class ScoresBehaviour : MonoBehaviour
{
    public PlayerHandler PlayerHandler { get; set; }
    public Text ScoresText { get; set; }

    public IEnumerator Start()
    {
        yield return new WaitUntil(() => GameHandler.Instance.PlayerHandler != null);

        PlayerHandler = GameHandler.Instance.PlayerHandler;
        PlayerHandler.Player.PropertyChanged += Player_PropertyChanged;

        ScoresText = GetComponent<Text>();
        ScoresText.text = string.Format($"Scores: {PlayerHandler.Scores.ToString()}");
    }

    private void Player_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        switch (e.PropertyName)
        {
            case "Score":
                ScoresText.text = string.Format($"Scores: {PlayerHandler.Scores.ToString()}");
                break;
        }
    }
}
