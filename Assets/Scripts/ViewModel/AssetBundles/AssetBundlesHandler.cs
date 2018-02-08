using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetBundlesHandler
{
    public AssetBundle AssetBundle { get; set; }

    public IEnumerator LoadAssetBundle(string pathToBundle)
    {
        using (WWW www = WWW.LoadFromCacheOrDownload(pathToBundle, 0))
        {
            yield return www;

            AssetBundle = www.assetBundle;
        }
    }
}
