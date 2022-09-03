using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPointColorHouse : MonoBehaviour
{
    WaypointMoverColorHouse waypointMover;
    private bool test;
    [SerializeField] private int color = 0;
    
    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("hello");
        test =  collision.gameObject.TryGetComponent<WaypointMoverColorHouse>(out waypointMover);
        if (test) { 
            waypointMover.End(color);
            Destroy(collision.gameObject);
            
        }
    }
}
