using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using AnotherFileBrowser.Windows;
using System;
using UnityEngine.Networking;
using System.IO;
public class UploadImage : MonoBehaviour
{
    public RawImage rawImage;
    public string imagename;
    public Texture2D urwTexture;
    public FireBaseStorage fireBaseStorage;
    public UserFireBase userFireBase;
   public void OpenFileBrowser()
    {
        var BP = new BrowserProperties();
        BP.filter= "Image files(*.*) | *.*";
        BP.filterIndex = 0;
        new FileBrowser().OpenFileBrowser(BP, path =>
        {
            StartCoroutine(LoadImage(path));
        });
    }

    IEnumerator LoadImage(string path)
    {
        using (UnityWebRequest uwr= UnityWebRequestTexture.GetTexture(path))
        {
            yield return uwr.SendWebRequest();
            if(uwr.result== UnityWebRequest.Result.ProtocolError||uwr.result==UnityWebRequest.Result.ConnectionError)
           // if (uwr.isHttpError||uwr.isNetworkError)
            {
                Debug.Log(uwr.error);
            }
            else
            {
                urwTexture = DownloadHandlerTexture.GetContent(uwr);
                rawImage.texture = urwTexture;

               
                // string filePath = System.IO.Path.Combine(Application.streamingAssetsPath, name);
                //File.WriteAllBytes(filePath, databytes);
                   
               

            }
        }
    }

   public void SaveImage(string UserName)
    {
        //string name = "screen" + DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") + ".png";
        string name = UserName + ".png";
        Byte[] databytes = urwTexture.EncodeToPNG(); 
        string localfile =  Application.streamingAssetsPath + "/" + name;
        //File.WriteAllBytes(Application.dataPath+"/../"+name, databytes);
        // File.WriteAllBytes(Application.dataPath + "/Images/" + name, databytes);
        File.WriteAllBytes(localfile, databytes);
        Debug.Log("image Saved");
        userFireBase.OnSubmit();
        fireBaseStorage.UploadFile(name);
    }
    
}
