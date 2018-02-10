using Model;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// Регулирует весь процесс игры от начала, до конца игры (ViewModel, хоть и наследуется от MonoBehaviour)
/// Как вариант, можно разделить на View и ViewModel, но эта реализация проще и удобнее
/// </summary>
public class GameHandler : MonoBehaviour
{
    public delegate void GameEnd(bool isWin);
    public static event GameEnd OnGameEnd;

    private static GameHandler instance;
    public static GameHandler Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameHandler>();

                if (instance == null)
                {
                    GameObject go = new GameObject("GameHandler");
                    instance = go.AddComponent<GameHandler>();
                }
            }

            return instance;
        }
    }

    public PlayerHandler PlayerHandler;

    [SerializeField]
    private AssetBundlesHandler assetBundleHandler;
    [SerializeField]
    private KeybordBehaviour keybordBehaviour;
    [SerializeField]
    private UniqueWordBehaviour uniqueWordBehaviour;

    public Stack<LevelHandler> LevelHandlers { get; set; }

    private void Awake()
    {
        StartCoroutine(Intialize());
    }

    private void OnDestroy()
    {
        instance = null;
        OnGameEnd = null;
    }

    private IEnumerator Intialize()
    {
        yield return StartCoroutine(assetBundleHandler.LoadAssetBundle());

        PlayerHandler.Intialize(assetBundleHandler.AssetBundle.LoadAllAssets<TextAsset>().First());
        PlayerHandler.Player.PropertyChanged += Player_PropertyChanged;

        assetBundleHandler.AssetBundle.Unload(this);

        LevelHandlers = new Stack<LevelHandler>(GetLevels(PlayerHandler.UniqueWords.Words.ToList()));

        if (LevelHandlers.Count == 0)
        {
            OnGameEnd?.Invoke(true);
            yield break;
        }

        LoadLevel(LevelHandlers.Pop());
    }

    private void Player_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if (e.PropertyName.Equals("Attempts"))
        {
            if (PlayerHandler.Attempts < 0)
                OnGameEnd?.Invoke(false);
        }
    }

    private IEnumerable<LevelHandler> GetLevels(List<UniqueWord> words)
    {
        var levels = new List<LevelHandler>();
        var englishAlphabetFactory = new EnglishAlphabetFactory();

        foreach (var item in words)
        {
            var level = new LevelHandler(item, englishAlphabetFactory.CreateAlphabet());
            level.OnLevelComplete += Level_OnLevelComplete;
            levels.Add(level);
        }

        return levels;
    }

    private void Level_OnLevelComplete(UniqueWord uniqueWord)
    {
        PlayerHandler.UniqueWords.Words.Remove(uniqueWord);

        PlayerHandler.Scores += PlayerHandler.Attempts;
        PlayerHandler.Attempts = PlayerHandler.StartAttempts;

        if (LevelHandlers.Count == 0)
        {
            OnGameEnd?.Invoke(true);
            return;
        }

        LoadLevel(LevelHandlers.Pop());
    }

    public void LoadLevel(LevelHandler level)
    {
        uniqueWordBehaviour.Refresh();
        keybordBehaviour.Refresh();

        level.Intialize();

        uniqueWordBehaviour.UniqueWord = level.UniqueWord;
        keybordBehaviour.Alphabet = level.Alphabet;

        level.OnOpenLetter += Level_OnOpenLetter;
    }

    private void Level_OnOpenLetter(bool isOpened)
    {
        if (!isOpened)
            PlayerHandler.Attempts -= 1;
    }
}
