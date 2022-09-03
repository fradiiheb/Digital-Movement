using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
public class ShowProfile : MonoBehaviour
{
    public UserScriptableObject userScriptable;
    public Text Nom;
    public Text Niveau;
    public Text Telephone;
    public Text Email;
    public Text Gouvernorat;
    public Text Ville;
    public Text School;
    public string Photo;
    public Texture2D urwTexture;
    public RawImage rawImage;

    public FireBaseStorage fireBaseStorage;

    void Start()
    {
        Nom.text = userScriptable.user.Nom+" "+userScriptable.user.Prenom;
        Niveau.text = userScriptable.user.Niveau;
        Telephone.text = userScriptable.user.Telephone;
        Email.text = userScriptable.user.Email;
        Gouvernorat.text = userScriptable.user.Gouvernorat;
        Ville.text = userScriptable.user.Ville;
        School.text = userScriptable.user.School;
        bool b = File.Exists(Application.streamingAssetsPath +"/"+ userScriptable.user.Photo);
        if (b == true)
        {
            urwTexture = textureFromStreamingAssets(userScriptable.user.Photo);
            rawImage.texture = urwTexture;
        }
        else 
        {
            fireBaseStorage.GetFile(userScriptable.user.Photo);
            Debug.Log("file not found");
            // rawImage.texture = urwTexture;
            StartCoroutine(waitForDownload());
        }

        
    }
    bool doneDownload()
    {
        if (fireBaseStorage.downloaded)
            return true;
        else return false;
               
    }
    IEnumerator waitForDownload()
    {
        yield return new WaitUntil(doneDownload);
        urwTexture = textureFromStreamingAssets(userScriptable.user.Photo);
        rawImage.texture = urwTexture;
    }

   
    public  Texture2D textureFromStreamingAssets(string texName)
    {
       
        
        string imageFile = Application.streamingAssetsPath + "/" + texName;
        
        byte[] pngBytes = System.IO.File.ReadAllBytes(imageFile);
        Texture2D tex = new Texture2D(2, 2);
        ImageConversion.LoadImage(tex, pngBytes);
        return tex;
       
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
