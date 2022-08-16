#if UNITY_EDITOR
using UnityEditor;


public class CreateAssetBundle 
{
    [MenuItem("Assets/Build AssetsBundle")]
    static void BuildAll()
    {
    #if UNITY_EDITOR
        BuildPipeline.BuildAssetBundles("AssetBundle", BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows);
    #endif
    }
}
#endif