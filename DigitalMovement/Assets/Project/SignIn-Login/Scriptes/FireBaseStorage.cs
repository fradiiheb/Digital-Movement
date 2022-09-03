using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Storage;
using System.IO;

public class FireBaseStorage : MonoBehaviour
{
     FirebaseStorage storage;
    StorageReference reference;
    public bool downloaded;
    // Start is called before the first frame update
    void Start()
    {
        storage = FirebaseStorage.DefaultInstance;
       // reference = storage.GetReferenceFromUrl("gs://quiz1-e2fcf.appspot.com/");
        Debug.Log(storage.RootReference);
    }
    public void UploadFile(string FileName)
    {
        reference = storage.RootReference.Child(FileName);
        //string localfile = "file://" + Application.streamingAssetsPath + "/"+ FileName + ".jpg";
        string localfile = Application.streamingAssetsPath + "/" + FileName;
        reference.PutFileAsync(localfile).ContinueWith(task =>
        {
            if (task.IsCompleted)
            {
                
                
                Debug.Log("Success");
            }
        });
    }
    public void GetFile(string FileName)
    {
        reference = storage.RootReference.Child(FileName);
        if (!Directory.Exists(Application.streamingAssetsPath ))
        {
            Directory.CreateDirectory(Application.streamingAssetsPath );
        }
        //  reference = storage.RootReference.Child("Hisokaaa.jpg");
        string localfile = "file://" + Application.streamingAssetsPath + "/"+FileName;
        reference.GetFileAsync(localfile).ContinueWith(task =>
        {
            if (task.IsCompleted)
            {
                downloaded = true;
                Debug.Log("Download Success");
            }
        });
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
