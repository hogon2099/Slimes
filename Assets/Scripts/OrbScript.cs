using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbScript : MonoBehaviour {

    CircleCollider2D crcColl;
    float counter;
    private void Start()
    {
        crcColl =  GetComponent<CircleCollider2D>();
        crcColl.enabled = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.isTrigger)
        Destroy(gameObject, 0.2f);
    }
    private void Update()
    {
        counter += Time.deltaTime;
        if (counter > 0.3) crcColl.enabled = true;
    }
}
