using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointMover : MonoBehaviour
{

    [SerializeField] private WayPoints wayPoints;
    [SerializeField] private int color = 0;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float distanceThreshold = 0.1f;
    private Transform currentWaypoint;
    private NextWayPoint nextwaypoint;
    public int index = 0;
    private new MeshRenderer renderer;
    public GameMaster gameMaster;

    void Start()
    {
        gameMaster = FindObjectOfType<GameMaster>();
        color = Random.Range(0, 3);
        renderer = gameObject.GetComponent<MeshRenderer>();
        if (color == 0)
        {
            
            renderer.material.SetColor("_Color", Color.red);
        }
        else if(color == 1)
        {
            renderer.material.SetColor("_Color", Color.blue);
        }
        else
        {
            renderer.material.SetColor("_Color", Color.green);
        }

        wayPoints = GameObject.FindGameObjectWithTag("waypoints").GetComponent<WayPoints>();

        
        //Set initial position to first waypoint
        currentWaypoint = wayPoints.GetNextWaypoint(currentWaypoint,index);
        transform.position = currentWaypoint.position;


        //Set next waypoint target

        currentWaypoint = wayPoints.GetNextWaypoint(currentWaypoint,index);
        transform.LookAt(currentWaypoint);
       
    }

    
    void Update()
    {
        if (!wayPoints.endRoute) { 
        transform.position = Vector3.MoveTowards(transform.position, currentWaypoint.position,moveSpeed*Time.deltaTime);
        if(Vector3.Distance(transform.position, currentWaypoint.position) < distanceThreshold )
        {   
            currentWaypoint = wayPoints.GetNextWaypoint(currentWaypoint, index);
                if (!wayPoints.endRoute)
                {
                    transform.LookAt(currentWaypoint);
                }
        }
        }
        

    }

    public void End(int colorindex)
    {
        if(color == colorindex)
        {
            Debug.Log("Win");
            gameMaster.score += 10;
        }
        else
        {
            gameMaster.life -= 1;
            Debug.Log("Lost");
        }
        gameMaster.UpdateScoreandLife();
    }

}
