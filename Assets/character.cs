using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    public float m_Speed;
    public float r_Speed;

    void Start()
    {
        //Fetch the Rigidbody component you attach from your GameObject
        m_Rigidbody = GetComponent<Rigidbody>();
        //Set the speed of the GameObject
        m_Speed = 3.0f;
        r_Speed = 10.0f;
    }

    void Update()
    {
        if (Input.GetKey("w"))
        {
            //Move the Rigidbody forwards constantly at speed you define (the blue arrow axis in Scene view)
            transform.position += transform.up * Time.deltaTime * m_Speed;
        }

        if (Input.GetKey("s"))
        {
            //Move the Rigidbody backwards constantly at the speed you define (the blue arrow axis in Scene view)
            transform.position -= transform.up * Time.deltaTime * m_Speed;
        }

        if (Input.GetKey("a"))
        {
            //Rotate the sprite about the Y axis in the positive direction
            transform.Rotate(new Vector3(0, 0, 5) * Time.deltaTime * r_Speed, Space.World);
        }

        if (Input.GetKey("d"))
        {
            //Rotate the sprite about the Y axis in the negative direction
            transform.Rotate(new Vector3(0, 0, -5) * Time.deltaTime * r_Speed, Space.World);
        }
    }
}
