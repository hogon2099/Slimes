using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{
      
    public Rigidbody2D bullet;      // префаб нашей снаряда
    public Transform gunPoint;      // точка рождения
    float sin, cos, hypotenuse;
   
    public void Shoot(float force)
    {   
        var mousePosition = Input.mousePosition;     
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        hypotenuse = (Mathf.Sqrt(Mathf.Pow((mousePosition.x - gunPoint.position.x), 2) + Mathf.Pow((mousePosition.y - gunPoint.position.y), 2) ));
        sin = (mousePosition.y - gunPoint.position.y) / hypotenuse;
        cos = (mousePosition.x - gunPoint.position.x) / hypotenuse;
        
            Rigidbody2D clone = Instantiate(bullet, gunPoint.position, Quaternion.identity) as Rigidbody2D;
            clone.velocity = new Vector2(force * cos, force * sin);
        
    }
} 