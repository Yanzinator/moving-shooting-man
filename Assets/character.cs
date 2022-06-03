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
    }

    void Move()
    {
        if (Input.GetKey("w"))
        {
            //Move the Rigidbody forwards constantly at speed you define (the blue arrow axis in Scene view)
            transform.position += transform.up * Time.deltaTime * movementSpeed;
        }

        if (Input.GetKey("s"))
        {
            //Move the Rigidbody backwards constantly at the speed you define (the blue arrow axis in Scene view)
            transform.position -= transform.up * Time.deltaTime * movementSpeed;
        }

        if (Input.GetKey("a"))
        {
            //Rotate the sprite about the Y axis in the positive direction
            transform.Rotate(new Vector3(0, 0, 5) * Time.deltaTime * rotationSpeed, Space.World);
        }

        if (Input.GetKey("d"))
        {
            //Rotate the sprite about the Y axis in the negative direction
            transform.Rotate(new Vector3(0, 0, -5) * Time.deltaTime * rotationSpeed, Space.World);
        }
    }

    float cooldown = 0;

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
