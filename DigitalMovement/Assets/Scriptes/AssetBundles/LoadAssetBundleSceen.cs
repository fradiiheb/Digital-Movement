using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;
public class LoadAssetBundleSceen : MonoBehaviour
{
    public string url;
    [Header("UI Stuff")]
    public Transform rootContainer;
    public Button prefab;
    public Text labelText;
    AssetBundle assetBundle;
    IEnumerator Start()
    {
        WWW www = new WWW(url);
        yield return www;
        if (!string.IsNullOrEmpty(www.error))
        {
            Debug.LogError(www.error);
            yield break;
        }
        assetBundle = www.assetBundle;
        string[] scenes = assetBundle.GetAllScenePaths();
        foreach(string sceenName in scenes)
        {
            Debug.Log(Path.GetFileNameWithoutExtension(sceenName));
            prefab.onClick.AddListener(delegate { LoadASsetBundleScene(sceenName); });
        }
    }

    public void LoadASsetBundleScene(string ScenName)
    {
        SceneManager.LoadScene(ScenName);
        
    }
}
