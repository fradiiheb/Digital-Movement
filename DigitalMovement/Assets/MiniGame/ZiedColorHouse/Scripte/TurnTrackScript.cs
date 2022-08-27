using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnTrackScript : MonoBehaviour
{
    public bool rotationchanged = false;
    public bool swap = false;

    public WayPoints wayPoints;


    public Sprite[] sprites;
    public Vector3[] positions;
    public Vector3[] rotations;
    public NextWayPoint wayPoint;
    
    public int currentSpriteIndex = 0;

    public void Awake()
    {
        wayPoints = GameObject.FindGameObjectWithTag("waypoints").GetComponent<WayPoints>();
    }


    private void OnMouseDown()
    {
        
        if (!swap)
        {
            swap = true;
            //wayPoints.swaped = true;
            wayPoint.swap = true;
            currentSpriteIndex = 1;
        }
        else
        {
            
            swap = false;
            wayPoint.swap = false;
            //wayPoints.swaped = false;
            currentSpriteIndex = 0;
        }
      

        gameObject.GetComponent<SpriteRenderer>().sprite = sprites[currentSpriteIndex];
        transform.localPosition = positions[currentSpriteIndex];

        if (rotationchanged)
        {
    
            transform.eulerAngles = rotations[currentSpriteIndex];
        }
    }
}
