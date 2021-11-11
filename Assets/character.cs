using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public float speed = 2f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w"))
        {
            transform.position += new Vector3( 0, speed * Time.deltaTime, 0);
        }
        if (Input.GetKey("s"))
        {
            transform.position -= new Vector3(0, speed / 2 * Time.deltaTime, 0);
        }

    }
}
