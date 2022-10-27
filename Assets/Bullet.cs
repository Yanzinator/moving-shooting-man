using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet
{
    public float xPosition;
    public float yPosition;
    public float Rotation;
    public float Velocity;
    public Sprite sprite;
    public int team;



    // should be called once all variables are decided
    public void Create()
    {

        GameObject Bullet = new GameObject("Empty");

        SpriteRenderer spriteRenderer = Bullet.AddComponent(typeof(SpriteRenderer)) as SpriteRenderer;
        BulletBehavior script = Bullet.AddComponent(typeof(BulletBehavior)) as BulletBehavior;
        script.speed = Velocity;

        spriteRenderer.sprite = sprite;

        Bullet.transform.position = new Vector2(xPosition,yPosition);
        Bullet.transform.Rotate(0,0,Rotation);
        Bullet.transform.localScale = new Vector2(3, 3);
    }
}
