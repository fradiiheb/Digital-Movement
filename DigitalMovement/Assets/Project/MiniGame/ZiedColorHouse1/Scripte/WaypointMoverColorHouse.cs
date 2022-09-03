using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointMoverColorHouse : MonoBehaviour
{

    [SerializeField] private WayPointsColorHouse wayPoints;
    [SerializeField] private int color = 0;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float distanceThreshold = 0.1f;
    private GameMasterColorHouse gameMaster;
    private Transform currentWaypoint;
    private NextWayPointColorHouse nextwaypoint;
    public int index = 0;
    public bool level2 = false;
    private int range = 3;
    private new MeshRenderer renderer;
    public Color[] colors;
    


    void Start()
    {
        if (level2)
        {
            range = 5;
        }
        color = Random.Range(0, range);
        renderer = gameObject.GetComponent<MeshRenderer>();
        renderer.material.SetColor("_Color", colors[color]);
        

        wayPoints = GameObject.FindGameObjectWithTag("waypoints").GetComponent<WayPointsColorHouse>();
        gameMaster = GameObject.FindGameObjectWithTag("gamemaster").GetComponent<GameMasterColorHouse>();

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
            gameMaster.score +=1;
        }
        else
        {
            Debug.Log("Lost");
        }
       
    }

}
