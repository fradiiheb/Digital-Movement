using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointsColorHouse : MonoBehaviour
{
    [Range(0f,2f)]
    [SerializeField] private float waypointsSize = 1f;
    public bool endRoute = false;
    public bool swaped = false;
    public List<Transform> waypoints = new List<Transform>();
    public List<NextWayPointColorHouse> nextwaypoint = new List<NextWayPointColorHouse>();

    private void Awake()
    {
        
    }

    private void OnDrawGizmos()
    {
        foreach(Transform t in transform)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(t.position, waypointsSize);
             
        }
        Gizmos.color = Color.red;
        for (int i = 0; i < transform.childCount - 1; i++)
        {
            Gizmos.DrawLine(transform.GetChild(i).position, transform.GetChild(i+1).position);
        }

        Gizmos.DrawLine(transform.GetChild(transform.childCount - 1).position, transform.GetChild(0).position) ;
    }

    public Transform GetNextWaypoint(Transform currentWayPoint,int index)
    {
        Transform next;
        

        

        if (currentWayPoint == null )
        {
            nextwaypoint.Add(null);
            nextwaypoint[index] = transform.GetChild(0).gameObject.GetComponent<NextWayPointColorHouse>();

            
            return transform.GetChild(0);
        }

        
        if(nextwaypoint[index].nextWaypoint.Count == 0)
        {
            
            
            return transform.GetChild(0);
        }
        else
        if (nextwaypoint[index].dynamic)
        {
            
            if (!nextwaypoint[index].swap)
            {
                
                next = nextwaypoint[index].nextWaypoint[0];
                nextwaypoint[index] = nextwaypoint[index].nextWaypoint[0].gameObject.GetComponent<NextWayPointColorHouse>();
               
            }
            else
            {
                swaped = false;
                next = nextwaypoint[index].nextWaypoint[1];
                nextwaypoint[index] = nextwaypoint[index].nextWaypoint[1].gameObject.GetComponent<NextWayPointColorHouse>();
                

            }
        }else
        {
            Debug.Log("here");
            next = nextwaypoint[index].nextWaypoint[0];
            nextwaypoint[index] = nextwaypoint[index].nextWaypoint[0].gameObject.GetComponent<NextWayPointColorHouse>();
            

        }

        return next;

        

        
    }
}
