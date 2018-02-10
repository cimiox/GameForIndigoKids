using UnityEditor;

public class BuildAssetBundles
{
    /// <summary>
    /// Создает assetBundle по заданному пути
    /// </summary>
    [MenuItem("Window/Build AssetBundles")]
    private static void CreateAssetBundles()
    {
        string path = EditorUtility.SaveFolderPanel("Create AssetBundles", "", "");
        if (!string.IsNullOrEmpty(path))
        {
            UnityEditor.BuildPipeline.BuildAssetBundles(path, BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows);
        }
    }
}
