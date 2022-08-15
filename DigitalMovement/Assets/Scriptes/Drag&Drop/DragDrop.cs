using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas canvas;
    public bool inPos = false;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    public string name;
    public ItemSlot item;
    public Transform ParentHolder;
    public bool InAHolder=false;
    public Vector3 InitialPosition;
    Vector3 mousepos;
    private void Awake(){
        rectTransform = GetComponent<RectTransform>();
        InitialPosition=GetComponent<RectTransform>().anchoredPosition;
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData){
       // Debug.Log("OnBeginDrag");
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData){
       // Debug.Log("OnDrag");
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
       
        if (item != null)
        {
            item.test = false;
            item = null;
        }
        inPos = false;
        InAHolder=false;
        this.transform.SetParent(ParentHolder);
    }

    public void OnEndDrag(PointerEventData eventData){
       // Debug.Log("OnEndDrag");
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
        if (!inPos)
        {
            rectTransform.anchoredPosition = InitialPosition;
        /*    rectTransform.anchorMin = new Vector2(0, 0);
            rectTransform.anchorMax = new Vector2(1, 1);*/
        }

    }

    public void OnPointerDown(PointerEventData eventData){
       // Debug.Log("OnPointerDown");
    }
}