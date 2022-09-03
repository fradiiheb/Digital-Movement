using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowSnake : MonoBehaviour
{
    public List<Vector3> positionList;
    public int distance = 20;
    public GameObject petObject;
    private void Update()
    {
        if (petObject == null)
            return;
        // Pet following
        positionList.Add(transform.position);

        if (positionList.Count > distance)
        {
            positionList.RemoveAt(0);
            petObject.transform.position = positionList[0];
        }
    }

}