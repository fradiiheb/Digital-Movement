using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Birdy : MonoBehaviour
{
    public float launchPow;

    private Vector3 initialPosition;
    private bool launched=false;
    private bool touched = false;
    private float timer;
    private Rigidbody2D rig;
    private Vector3 line2, line3;
    public LineRenderer Trajectory;
    [SerializeField] private GameObject birdy;
    [SerializeField] private GameObject wrongPanel;
    [SerializeField] private GameObject correctPanel;
    


    private void Awake()
    {
        initialPosition = transform.position;
    }
    private void Update()
    {
        
        GetComponent<LineRenderer>().SetPosition(1,initialPosition);
        GetComponent<LineRenderer>().SetPosition(0,transform.position);
        //line2.x = Mathf.Abs(initialPosition.x);
        //line2.y = Mathf.Abs(initialPosition.y)/2 + Mathf.Abs(transform.position.y)/2;
        //GetComponent<LineRenderer>().SetPosition(2,line2);
        if (launched && GetComponent<Rigidbody2D>().velocity.magnitude <= 0.1 )
        {
            timer += Time.deltaTime;
        }

        if (transform.position.y > 33 ||
            transform.position.x > 38 ||
            transform.position.y < -29 ||
            transform.position.x < -33 ||
            timer > 3)
        {
            if (launched)
            {
                birdy.SetActive(false);
                birdy.GetComponent<Rigidbody2D>().gravityScale = 0;
                birdy.transform.position = initialPosition;
                launched = false;
                birdy.SetActive(true);
                transform.rotation = Quaternion.Euler(0, 0, 0);
                timer = 0;
                touched = false;
                wrongPanel.SetActive(false);
            }
        }
    }

    private void OnMouseDown()
    {
        Trajectory.enabled = true;
        if (!launched)
        {
            //birdy.GetComponent<Rigidbody2D>().gravityScale = 1;
            GetComponent<LineRenderer>().enabled = true;
            GetComponent<SpriteRenderer>().color = Color.red;
            birdy.GetComponent<Rigidbody2D>().simulated = false;
        }
    }

    private void OnMouseUp()
    {
        if (!launched)
        {
            GetComponent<SpriteRenderer>().color = Color.white;
            Vector2 directionToIitialPosition = initialPosition - transform.position;
            if (Vector3.Distance(transform.position, initialPosition) > 1f)
            {
                GetComponent<Rigidbody2D>().AddForce(directionToIitialPosition * launchPow);
                GetComponent<Rigidbody2D>().gravityScale = 1;
                GetComponent<LineRenderer>().enabled = false;
                Trajectory.enabled = false;
                birdy.GetComponent<Rigidbody2D>().simulated = true;
                launched = true;
            }
            else
            {
                birdy.GetComponent<Rigidbody2D>().gravityScale = 0;
                birdy.transform.position = initialPosition;
                Trajectory.enabled = false;
                launched = false ;
                birdy.GetComponent<Rigidbody2D>().simulated = true;
            }
     
        }
    }

    private void OnMouseDrag()
    {
        Trajectory.enabled = true;
        if (!launched)
        {
            Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(newPosition.x, newPosition.y);
            launched = false;
            
            float pullDistance = Vector3.Distance(newPosition, initialPosition);
            showTrajectory(newPosition , pullDistance);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Answer" && !touched)
        {
            collision.gameObject.SetActive(false);
            touched = true;
            wrongPanel.SetActive(true);
        }

        if (collision.gameObject.tag == "Correct Answer" && !touched)
        {
            touched = true;
            Debug.Log("Correct Answer");
            correctPanel.SetActive(true);
            launched = false;
        }
    }

    void showTrajectory(Vector3 newPos, float distance)
    {
        Vector3 diff = initialPosition -newPos;
        int segmentCount = 25;
        Vector2[] segments = new Vector2[segmentCount];
        segments[0] = newPos;

        Vector2 segVelocity = new Vector2(diff.x, diff.y) * launchPow/50;

        for (int i = 1; i< segmentCount; i++)
        {
            float timeCurve = (i * Time.fixedDeltaTime * 5);
            segments[i] = segments[0] + segVelocity * timeCurve + 0.5f * Physics2D.gravity * Mathf.Pow(timeCurve, 2);
        }
        Trajectory.positionCount = segmentCount;
        for (int j = 0; j<segmentCount ; j++)
        {
            Trajectory.SetPosition(j, segments[j]);
        }
    }
}
