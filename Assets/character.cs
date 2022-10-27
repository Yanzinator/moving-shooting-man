using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Bullet;

public class character : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    public float movementSpeed;
    public float rotationSpeed;
    public float shootingSpeed;
    public float bulletVelocity;
    public Sprite BulletSpr;


    void Start()
    {
        //Fetches the Rigidbody component you attach from your GameObject
        m_Rigidbody = GetComponent<Rigidbody>();
        //Sets the speed of the GameObject
        movementSpeed = 3.0f;
        rotationSpeed = 10.0f;
        //creates a gameobject for rotation
        GameObject rotationGoal = new GameObject("PlayerRotationGoal");
    }



    float rotationz;
    void Move()
    {
        int presses = 0;
        char direction = 'N';
        //rotates character
        //up
        if (Input.GetKey("w"))
        {

            //Rotates
            direction = 'U';
            rotationz = 0;
            presses++;
        }
        //down
        if (Input.GetKey("s"))
        {
            //Rotates
            if (presses == 0)
            {
                direction = 'D';
                rotationz = 180;
                presses++;
            }
            else
            {
                direction = 'N';
                presses--;
            }
        }
        //right
        if (Input.GetKey("a"))
        {

            //Rotates

            if (presses == 0)
            {
                rotationz = 90;
                direction = 'R';
            }
            else if (presses == 1)
            {
                if (direction == 'U')
                {
                    rotationz += 45;
                }
                else if (direction == 'D')
                {
                    rotationz -= 45;
                }
                else
                {
                    Debug.LogError("direction got fucked at right");
                }
            }
            else
            {
                Debug.LogError("Too many presses at right");
            }
            presses++;
        }
        //left
        if (Input.GetKey("d"))
        {
            //Rotates
            if (presses == 0)
            {
                rotationz = 270;
                presses++;
            }
            else if (presses == 1)
            {
                if (direction == 'N')
                {
                    presses--;
                    rotationz = 0;
                }
                else if (direction == 'U')
                {
                    rotationz -= 45;
                }
                else if (direction == 'D')
                {
                    rotationz += 45;
                }
                else
                {
                    Debug.LogError("direction got fucked at left with 1 press");
                }
            }
            else if (presses == 2)
            {
                if (direction == 'U')
                {
                    rotationz -= 45;
                }
                else if (direction == 'D')
                {
                    rotationz += 45;
                }
                else
                {
                    Debug.LogError("direction got fucked at left with 2 presses");
                }
            }
            else
            {
                Debug.LogError("too many presses at left");
            }

        }
        //Rotates the character based on movement
        GameObject rotationgoal = GameObject.Find("PlayerRotationGoal");
        rotationgoal.transform.eulerAngles = new Vector3(0, 0, rotationz);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotationgoal.transform.rotation, Time.deltaTime * rotationSpeed);

        //moves character
        if (presses != 0) {
            transform.position += transform.up * Time.deltaTime * movementSpeed;
        }

    }

    float cooldown = 100;
    void Shoot()
    {
        cooldown += Time.deltaTime;
        if (Input.GetKey("space") && cooldown >= shootingSpeed)
        {
            
            Bullet bullet = new Bullet();
            bullet.sprite = BulletSpr;
            bullet.xPosition = transform.position.x;
            bullet.yPosition = transform.position.y;
            bullet.Rotation = transform.eulerAngles.z;
            bullet.Velocity = bulletVelocity;
            bullet.team = 1;
            bullet.Create();
            
            cooldown = 0;
        }
    }

    
    void Update()
    {
        Move();
        Shoot();
    }
}
