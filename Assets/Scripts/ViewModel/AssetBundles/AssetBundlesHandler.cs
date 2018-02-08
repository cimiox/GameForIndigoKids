﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class AssetBundlesHandler
{
    public AssetBundle AssetBundle { get; set; }

    [SerializeField]
    private string PathToBundle;

    public IEnumerator LoadAssetBundle()
    {
        using (WWW www = WWW.LoadFromCacheOrDownload(PathToBundle, 0))
        {
            yield return www;

            AssetBundle = www.assetBundle;
        }
    }
}
