using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShopManager : MonoBehaviour
{
    #region Singleton
    // we create this to not evrytime we need inventory we make FindObjectOfType<Inventory> that gona be hevy 
    public static ShopManager instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More then one instance of ShopManager found");
            return;
        }
        instance = this;
    }
    #endregion

    public List<Item> items;
    public List<ItemEmplacement> itemsSlots;
    public Transform parent; 
    public GameObject ItemButton;
    public UserScriptableObject userScriptable;
    public Text TotalGoldText;
    void Start()
    {
        TotalGoldText.text= "Gold= " + userScriptable.user.TotalGold;

        InstansiateAllItem();


    }
    public void InstansiateHats()
    {
        removeAllChilldrens();
        
        foreach (Item item in items)
        {
            if (item is Hats)
            {
                GameObject slotItem = Instantiate(ItemButton, parent);
                slotItem.GetComponent<ItemEmplacement>().item = item;
                itemsSlots.Add(slotItem.GetComponent<ItemEmplacement>());
            }
        }
    }
    public void InstansiatePants()
    {
        removeAllChilldrens();

        foreach (Item item in items)
        {
            if (item is Pants)
            {
                GameObject slotItem = Instantiate(ItemButton, parent);
                slotItem.GetComponent<ItemEmplacement>().item = item;
                itemsSlots.Add(slotItem.GetComponent<ItemEmplacement>());
            }
        }
    }
    public void InstansiateAllItem()
    {
        removeAllChilldrens();
        foreach (Item item in items)
        {
            GameObject slotItem = Instantiate(ItemButton, parent);
            slotItem.GetComponent<ItemEmplacement>().item = item;
            // slotItem.GetComponent<Image>().sprite = item.icon;
            itemsSlots.Add(slotItem.GetComponent<ItemEmplacement>());
        }
    }
    public void removeAllChilldrens()
    {
        itemsSlots.Clear();
        foreach (Transform child in parent)
        {
            GameObject.Destroy(child.gameObject);
        }
    }

    
}
