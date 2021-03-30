using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 [RequireComponent(typeof(Rigidbody2D))]
public class PlayerSlime : MonoBehaviour {

    Rigidbody2D RgBody2d;
    float inputX;
    float inputY;
    float speed = 5f;
    public int heath = 7;
    float scaleStep;
    Transform Btrf;
    Transform Ftrf;
   
    ShootingScript weapon;
     public float force = 5;
     public float minforce = 5;
     public float maxforce = 25f;

    Vector3 newScale, newPos;


    void Start () {
        Btrf = transform.GetChild(0);
        Ftrf = transform.GetChild(1);
        RgBody2d = GetComponent<Rigidbody2D>();
        weapon = GetComponent<ShootingScript>();
        scaleStep = (transform.localScale.x / heath) / 2;
        newScale = new Vector3(transform.localScale.x , transform.localScale.y, transform.localScale.z); // устанавливаем начальное значение
    }
	
	void Update () {
        Move();
        if(heath > 1) Shoot();
        // плавное уменьшение размеров (лицо меняет позицию, тело позицию и размер)
        if (Btrf.localScale.x > newScale.x) Btrf.localScale = new Vector3(Btrf.localScale.x - Time.deltaTime, Btrf.localScale.y - Time.deltaTime, Btrf.localScale.z);
        if (Btrf.localPosition.y > newPos.y) Btrf.localPosition = new Vector3(Btrf.localPosition.x, Btrf.localPosition.y - Time.deltaTime, Btrf.localPosition.z);
        if (Ftrf.localPosition.y > newPos.y) Ftrf.localPosition = new Vector3(Ftrf.localPosition.x, Ftrf.localPosition.y - Time.deltaTime, Ftrf.localPosition.z);
    }
    private void Shoot()
    {
        if (Input.GetMouseButton(0) & force < maxforce) force += 10 * Time.deltaTime;

        if (Input.GetMouseButtonUp(0))
        {
            weapon.Shoot(force);
            force = minforce;
            if(heath >1) heath--;
            if (Btrf.localScale.x > 0.5)
            {
                newScale = new Vector3(Btrf.localScale.x - scaleStep, Btrf.localScale.y - scaleStep, Btrf.localScale.z);
                newPos = new Vector3(Btrf.localPosition.x, Btrf.localPosition.y - scaleStep / 2, Btrf.localPosition.z);
            }

        }
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.A)) inputX = -1;
        else if (Input.GetKey(KeyCode.D)) inputX = 1;
        else inputX = 0;

        if (Input.GetKey(KeyCode.W)) inputY = 1;
        else if (Input.GetKey(KeyCode.S)) inputY = -1;
        else inputY = 0;

        RgBody2d.velocity = new Vector2(inputX * speed, inputY * speed);
    }

}
