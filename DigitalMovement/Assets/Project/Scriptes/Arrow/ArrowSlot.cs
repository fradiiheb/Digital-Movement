using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ArrowSlot : MonoBehaviour, IDropHandler
{
    public int answer = 1;
    private GameObject master;
    // private GameMaster gameMaster;
    public bool answertest = false;
    public bool soloSpot;
    public bool haveItem;
    private void Start()
    {
      //  master = GameObject.FindGameObjectWithTag("GameMaster");
        //  gameMaster = master.GetComponent<GameMaster>();

    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
        //if (eventData.pointerDrag != null) {
        if (soloSpot && haveItem == true)
        {
            eventData.pointerDrag.GetComponent<ArrowDragDrop>().done = false;
            return;
        }
            

            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            eventData.pointerDrag.GetComponent<ArrowDragDrop>().done = true;
            eventData.pointerDrag.GetComponent<ArrowDragDrop>().wasinslot = true;
            eventData.pointerDrag.GetComponent<ArrowDragDrop>().arrowSlot = this;
            if (eventData.pointerDrag.GetComponent<ArrowDragDrop>().answer == answer)
            {
                answertest = true;
            }
            else
            {
                answertest = false;
            }
        haveItem = true;
        //}
    }
}

    