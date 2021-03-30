using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    public int heath = 7;
    float scaleStep;
    Vector3 newScale, newPos;
    Transform Btrf;
    Transform Ftrf;

    private void Start()
    {
        Btrf = transform.GetChild(0);
        Ftrf = transform.GetChild(1);
        scaleStep = (transform.localScale.x / heath) / 2;
        newScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }
    private void Update()
    {
        if (Btrf.localScale.x < newScale.x) Btrf.localScale = new Vector3(Btrf.localScale.x + Time.deltaTime, Btrf.localScale.y + Time.deltaTime, Btrf.localScale.z);
        if (Btrf.localPosition.y < newPos.y) Btrf.localPosition = new Vector3(Btrf.localPosition.x, Btrf.localPosition.y + Time.deltaTime, Btrf.localPosition.z);
        if (Ftrf.localPosition.y < newPos.y) Ftrf.localPosition = new Vector3(Ftrf.localPosition.x, Ftrf.localPosition.y + Time.deltaTime, Ftrf.localPosition.z);
    }
    private void OnTriggerEnter2D(Collider2D otherColl)
    {
        newScale = new Vector3(Btrf.localScale.x + scaleStep, Btrf.localScale.y + scaleStep, Btrf.localScale.z);
        newPos = new Vector3(Btrf.localPosition.x, Btrf.localPosition.y + scaleStep / 2, Btrf.localPosition.z);
    }
}
