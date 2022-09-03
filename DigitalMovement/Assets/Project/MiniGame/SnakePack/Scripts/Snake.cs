using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Snake : MonoBehaviour
{
    // Global Variables used in the Snake file :
    private Vector2 _direction=Vector2.right;
     [SerializeField]private List<Transform> _segments = new List<Transform>();
    public Transform SegmentPrefab;
    public int InitialSize = 3;
    [SerializeField] private SwipeMobile control;
    public float speed;

   
    private void Start()
    {
        ResetState();
    }
    private void Update()
    {
        SnakeMouvement();
    }
    private void FixedUpdate()
    {
       /* for (int i=_segments.Count-1 ; i > 0 ; i--)
        {
            _segments[i].position = _segments[i - 1].position;
        }*/
        this.transform.position=  new Vector3(
            this.transform.position.x+(_direction.x*speed * Time.deltaTime),
            this.transform.position.y+(_direction.y* speed * Time.deltaTime),
            0.0f
        );

         
       
    }
    public void SnakeMouvement()
    {
        if (/*Input.GetKeyDown(KeyCode.Z)*/ control.VerticalSwipe > 0)
        {
            _direction = Vector2.up ;
        }
        else if (/*Input.GetKeyDown(KeyCode.S)*/ control.VerticalSwipe < 0)
        {
            _direction = Vector2.down;
        }
        else if (/*Input.GetKeyDown(KeyCode.D)*/ control.HorizontalSwipe > 0)
        {
            _direction = Vector2.right;
        }
        else if (/*Input.GetKeyDown(KeyCode.Q)*/ control.HorizontalSwipe < 0)
        {
            _direction = Vector2.left;
        }
    }
    public void Grow()
    {
        Transform segment = Instantiate(this.SegmentPrefab);
        segment.position = _segments[_segments.Count - 1].position;
        _segments.Add(segment);
        _segments[_segments.Count - 2].GetComponent<FollowSnake>().petObject = segment.gameObject;
    }
    public void ResetState()
    {
        for (int i = 1 ; i < _segments.Count ; i++)
        {
            Destroy(_segments[i].gameObject);
        }
        _segments.Clear();
        _segments.Add(this.transform);

        for (int i = 1 ; i < this.InitialSize; i++ )
        {
            Transform segment = Instantiate(this.SegmentPrefab);
             // segment.GetComponent<FollowSnake>().speed = speed;
            _segments.Add(segment);
        }
        
        // Reseting the snake head to the midle of the screen :
        this.transform.position = Vector3.zero;
        StartCoroutine(createFollow());
    }
    IEnumerator createFollow()
    {
        yield return new WaitForSeconds(0.3f);
        for (int i = 0; i < _segments.Count-1; i++)
        {
            Debug.Log("i befor" + i);
            _segments.ElementAt(i).GetComponent<FollowSnake>().petObject = _segments.ElementAt(i + 1).gameObject;
            Debug.Log("i after" + i);
        }
    }
    void forfollow()
    {
       
    }
    private void OnTriggerEnter2D(Collider2D collided_Obj)
    {
        if (collided_Obj.tag == "Food")
        {
            Grow();
        }else if (collided_Obj.tag == "Obstacle")
        {
           // ResetState();
        }
    }
}
