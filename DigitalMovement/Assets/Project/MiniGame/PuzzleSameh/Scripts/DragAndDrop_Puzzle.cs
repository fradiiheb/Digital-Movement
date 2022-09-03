using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop_Puzzle : MonoBehaviour
{
    private Vector3 _righPosition;
    private Vector3 _theRandomPosition;
    private Vector3 _dragOffset;
    private Camera _cam;
    public Vector2 max,min;
    [SerializeField] private float _speed = 10;

    void Awake() {
        _cam = Camera.main;
        max.x=9.2f;
        max.y=2.5f;
        min.y=-7.5f;
        min.y=-9.2f;
    }

    void Start(){
        _righPosition = transform.position;
        transform.position = new Vector3(Random.Range(1.5f,7f),Random.Range(1.5f,-6f));
        _theRandomPosition=transform.position;
    }

    void OnMouseDown() {
        _dragOffset = transform.position - GetMousePos();
        
    }
    void OnMouseUp(){
        if (Vector3.Distance(transform.position,_righPosition)<0.5f)
        {
            transform.position=_righPosition;     
            return;       
        }
        if(transform.position.x>max.x||transform.position.y>max.y||transform.position.y<min.y||transform.position.x<min.x){
            transform.position=_theRandomPosition;
        }
    }
    void OnMouseDrag() {
        transform.position = Vector3.MoveTowards(transform.position, GetMousePos() + _dragOffset, _speed * Time.deltaTime) ;
       
    }

    Vector3 GetMousePos() {
        var mousePos = _cam.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        return mousePos;
    }

    void Update(){
        
        
    }

}
