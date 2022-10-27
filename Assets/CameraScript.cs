using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    public GameObject following;
    public float interested = 1f; //how interested the follower is in the thing it's following :)

    void LateUpdate()
    {
        Vector3 goal = following.transform.position;
        goal.z = transform.position.z;
        transform.position = Vector3.MoveTowards(transform.position, goal, interested);
    }

}
