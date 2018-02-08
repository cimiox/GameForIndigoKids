using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public PlayerHandler PlayerHandler;

    [SerializeField]
    private AssetBundlesHandler assetBundleHandler;

    public IEnumerator Start()
    {
        yield return StartCoroutine(assetBundleHandler.LoadAssetBundle());
        PlayerHandler.Intialize(assetBundleHandler.AssetBundle.LoadAllAssets<TextAsset>().First());
    }
}
