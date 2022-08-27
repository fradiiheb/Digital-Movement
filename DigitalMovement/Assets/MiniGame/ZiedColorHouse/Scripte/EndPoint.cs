using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPoint : MonoBehaviour
{
    WaypointMover waypointMover;
    private bool test;
    [SerializeField] private int color = 0;
    
    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("hello");
        test =  collision.gameObject.TryGetComponent<WaypointMover>(out waypointMover);
        if (test) { 
            waypointMover.End(color);
            Destroy(collision.gameObject);
            
        }
    }
}
