using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
public class ButtonSelectionTracker : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    public bool buttonPressed;


    public Vector2 startTouch, swipeDelta;
    public bool isDraging;
    public float Vertical, Horizontal;
    private Vector2 moveDirection = Vector2.zero;
    public float MouveSpeed;
    public RectTransform rectTransform;
    public Rigidbody2D rb2d;
    public void OnPointerDown(PointerEventData eventData)
    {
        buttonPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        buttonPressed = false;
    }
    private void Start() {
        rb2d=GetComponent<Rigidbody2D>();
        rectTransform=GetComponent<RectTransform>();
    }
    private void Update()
    {
        if(buttonPressed) {
              if (Input.touches.Length > 0)
                {
                  Horizontal = Input.touches[0].deltaPosition.normalized.x;
                  Vertical= Input.touches[0].deltaPosition.normalized.y;
                }
                 else
                 {
                    Horizontal = 0;
                    Vertical = 0;
                 }
            
            

                    if (Input.GetMouseButtonDown(0))
                    {
                        startTouch = Input.mousePosition;
                        isDraging = true;
                    }
                    else if (Input.GetMouseButtonUp(0))
                    {
                        isDraging = false;
                        // doubleTap = false;

                    }
                    if (isDraging)
                    {
                        Vector2 currentPos=Input.mousePosition;
                        swipeDelta = currentPos - startTouch;
                        Horizontal = swipeDelta.normalized.x;
                        Vertical = swipeDelta.normalized.y;

                    }
                    else
                    {
                        swipeDelta = Vector2.zero;
                        Horizontal = 0;
                        Vertical = 0;
                    }


           
            //just for test
                if (Input.GetAxis("Horizontal") != 0)
                {
                    Horizontal = Input.GetAxis("Horizontal");
                }
                if (Input.GetAxis("Vertical") != 0)
                {
                    Vertical = Input.GetAxis("Vertical");
                }



            //     moveDirection = new Vector2(Horizontal * horizontalSpeed, 0);
            // GetComponent<RectTransform>().anchoredPosition += moveDirection;
            // transform.Translate(moveDirection * Time.deltaTime);

            
        }
        else
        {
            Horizontal = 0;
            Vertical = 0;
        }
        /* Vector2 position = rectTransform.anchoredPosition;
            if(this.tag=="Horizontal")
            position.x += Horizontal*MouveSpeed * Time.deltaTime;
            if (this.tag == "Vertical")
            position.y += Vertical * MouveSpeed * Time.deltaTime;



        rectTransform.anchoredPosition = position;*/
        if (this.tag == "Horizontal")
            rb2d.velocity = new Vector2(Horizontal * MouveSpeed, 0);
        if (this.tag == "Vertical"){
            rb2d.velocity = new Vector2(0, Vertical * MouveSpeed);
        }
          
    }


}
