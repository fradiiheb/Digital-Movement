using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ItemEmplacement : MonoBehaviour
{
     public Image icon;
    public Item item;
    public Image selectedImage;
    public GameObject BuyButton;
    public Text ItemPrice;
   private void Start()
    {
        selectedImage.enabled = false;

        if (item.Available)
        {
            SwitchAvailable();
            BuyButton.SetActive(false);
        }
        else
        {
            BuyButton.SetActive(true);
            ItemPrice.text = item.price + "";
        }
        if (item.Selected)
        {
            selectedImage.enabled = true;
            // GameManager.instance.MainModel = model;

        }
        
    }
    
    public void SwitchSlected()
    {
        item.Selected = !item.Selected;
        selectedImage.enabled = !selectedImage.enabled;
        /*if (item is CharacterModel)
            userVariables.CurrentModel = model;*/
        // GameManager.instance.MainModel = model;

    }
    public void SwitchAvailable()
    {
        BuyButton.SetActive(false);
        //icon.sprite = item.icon;
        GetComponent<Image>().sprite = item.icon;
        item.Available = true;

    }

    public void BuyItem()
    {
        if (ShopManager.instance.userScriptable.user.getTotalGold() > item.price)
        {
            SwitchAvailable();
            ShopManager.instance.userScriptable.user.TotalGold -= item.price;
            ShopManager.instance.TotalGoldText.text = "Gold= "+ShopManager.instance.userScriptable.user.TotalGold;
        }
        else
        {
            Debug.Log("you dont have Gold");

        }
    }
    public void UseSlot()
    {
        if (!item.Available)
        {
            return;
        }

        Debug.Log(item.GetType());
       
            foreach (ItemEmplacement myitem in ShopManager.instance.itemsSlots)
            {
            if (myitem.item.GetType() == item.GetType()) { 
               
            if (myitem.item != item) { 
            myitem.item.Selected = false;
            myitem.selectedImage.enabled = false;
                
            }
            }
        }
        

        SwitchSlected();
    }
}
