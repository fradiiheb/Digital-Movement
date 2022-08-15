using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI.Extensions;
public class ArrowDragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    public float arrowheadSize;
    Vector2 startPosition, mouseWorld;
    GameObject arrow;
    public bool done = false;
    public bool wasinslot = false;
    public UILineRenderer arrowLine;
    List<Vector2> pointList = new List<Vector2>();
    public int answer = 1;
    public Canvas canvas;
    public ArrowSlot arrowSlot = null;
    public CanvasGroup[] canvasGroups;
     private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    //    canvasGroups = FindObjectsOfType<CanvasGroup>();

    }

    private void Start()
    {
        //arrow = GameObject.FindGameObjectWithTag("Arrow");
        //arrowLine = arrow.GetComponent<UILineRenderer>();
        mouseWorld = new Vector3();
        arrowheadSize = 0.08f;
        startPosition = rectTransform.anchoredPosition;
       

    
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (arrowSlot != null)
        {
            arrowSlot.answertest = false;
            arrowSlot = null;
        }
      //  Debug.Log("OnBeginDrag");
      foreach(CanvasGroup canv in canvasGroups)
        {
            canv.alpha = .6f;
            canv.blocksRaycasts = false;
        }
       // canvasGroup.alpha = .6f;
       // canvasGroup.blocksRaycasts = false;

        pointList.Clear();
    }

    public void OnDrag(PointerEventData eventData)
    {
      //  Debug.Log("OnDrag");
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        arrowLine.enabled = true;
        DrawArrow(eventData);

    }

    public void OnEndDrag(PointerEventData eventData)
    {
      //  Debug.Log("OnEndDrag");
        /*canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;*/
        foreach (CanvasGroup canv in canvasGroups)
        {
            canv.alpha = 1;
            canv.blocksRaycasts = true;
        }
        if (!done)
        {
            InitArrow();
            return;

        }

        done = false;
        pointList[1] = rectTransform.anchoredPosition;
        arrowLine.Points = pointList.ToArray();


    }

    public void OnPointerDown(PointerEventData eventData)
    {
       // Debug.Log("OnPointerDown");
    }



    public void DrawArrow(PointerEventData eventData)
    {
        mouseWorld = rectTransform.anchoredPosition;


        if (pointList.Count < 1)
        {
            pointList.Add(startPosition);
            arrowLine.Points = pointList.ToArray();
            pointList.Add(mouseWorld);
            return;
        }

        pointList[1] = mouseWorld;
        arrowLine.Points = pointList.ToArray();


        //float percentSize = (float)(arrowheadSize / Vector3.Distance(startPosition, mouseWorld));
        //Vector2 point = startPosition;

    }

    public void InitArrow()
    {
        rectTransform.anchoredPosition = startPosition;
        pointList.Clear();
        arrowLine.enabled = false;
    }
}

