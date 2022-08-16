using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
public class LoadBundleFromassets : MonoBehaviour
{
    AssetBundle assetBundle;
   public string assetName;
    public string folderPath;


    // Start is called before the first frame update
    void Awake()
    {
        folderPath = Application.streamingAssetsPath + assetName;  //Get path of folder

    }
    void Start()
    {
        var myLoadedAssetBundle = AssetBundle.LoadFromFile(Path.Combine(Application.streamingAssetsPath, assetName));
        if (myLoadedAssetBundle == null)
        {
            Debug.Log("Failed to load AssetBundle!");
            return;
        }
        
        string[] scenes = myLoadedAssetBundle.GetAllScenePaths();
        foreach (string sceenName in scenes)
        {
            Debug.Log(Path.GetFileNameWithoutExtension(sceenName));
       //     prefab.onClick.AddListener(delegate { LoadASsetBundleScene(sceenName); });
        }
    }
    public void loadnow()
    {
        SceneManager.LoadScene("menuScene");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
