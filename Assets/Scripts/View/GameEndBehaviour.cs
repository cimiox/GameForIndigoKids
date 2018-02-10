using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Обрабатывает событие окончания игры
/// </summary>
public class GameEndBehaviour : MonoBehaviour
{
    public Text EndText { get; set; }

    private void Start()
    {
        EndText = GetComponentInChildren<Text>();
        GameHandler.OnGameEnd += GameHandler_OnGameEnd;
        gameObject.SetActive(false);
    }

    private void GameHandler_OnGameEnd(bool isWin)
    {
        gameObject.SetActive(true);
        StartCoroutine(OnGameEnd(isWin));
    }

    private IEnumerator OnGameEnd(bool isWin)
    {
        EndText.text = isWin ? "You win!" : "You lose";

        yield return new WaitForSeconds(3);

        SceneManager.LoadScene(0);
    }
}
