
using UnityEngine;
[CreateAssetMenu(fileName = "New Item", menuName = "Shop/Item")]
public class Item : ScriptableObject
{
    new public string name = "New Item"; //new because every object have a variable named name so we overwite the old 
    public Sprite icon = null;
    public bool Available = false;
    public bool Selected = false;
    public int price;
    public GameObject selectedImage;
    public virtual void Use()
    {
        //use the item
        Debug.Log("Using " + name);
    }
}
