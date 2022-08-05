using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    public string[] NameSlot;
    public bool test;
    public DragDrop[] Items;
   
    public VerifDragDrop verifDragDrop;
    
    
    void Start()
    {
        Items = FindObjectsOfType<DragDrop>();
        verifDragDrop=FindObjectOfType<VerifDragDrop>();
    }
    public void OnDrop(PointerEventData eventData){
        //Debug.Log("OnDrop");
        eventData.pointerDrag.transform.SetParent(this.transform);
        eventData.pointerDrag.GetComponent<DragDrop>().InAHolder=true;
       // if(eventData.pointerDrag){
            //eventData.pointerDrag.GetComponent<RectTransform>().position = GetComponent<RectTransform>().position;
            foreach (string slot in NameSlot) {
                if (slot == eventData.pointerDrag.GetComponent<DragDrop>().name)
                {
                    eventData.pointerDrag.GetComponent<DragDrop>().inPos = true;
                    
                    eventData.pointerDrag.GetComponent<DragDrop>().item = this;
                }
            }
            test = true;
            
            //verifDragDrop.verif();
           
     //   }
    }
}
