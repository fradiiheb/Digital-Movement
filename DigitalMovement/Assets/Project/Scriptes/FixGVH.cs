using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;

public class FixGVH : MonoBehaviour
{
    // Start is called before the first frame update
   public AssetList assets = new AssetList();
    void Start()
    {
      
        assets.Add(new Asset("ProjectSettings/GvhProjectSettings.xml"));
        Task t = UnityEditor.VersionControl.Provider.Checkout(assets, UnityEditor.VersionControl.CheckoutMode.Exact);
        t.Wait();
    }

   
}
