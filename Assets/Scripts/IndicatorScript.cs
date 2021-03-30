using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicatorScript : MonoBehaviour {
 
    public Transform indicator;
    private Transform innerCirce, clone;
    PlayerSlime slime;
    [SerializeField] float maxScale, minScale, curScale;
    [SerializeField] float step = 0;
    float forceCurLevel, wantedScale;

    [ContextMenu("Reset")]
    void Reset()
    {
        indicator.localScale = new Vector3(0.5f, 0.5f, 0);
        indicator.GetChild(0).localScale = new Vector3(2, 2, 0);
        indicator.GetChild(1).localScale = new Vector3(1, 1, 0);
    }
    // Use this for initialization

    void Start() {
        slime = GetComponent<PlayerSlime>();       
        maxScale = indicator.GetChild(0).localScale.x;
        minScale = indicator.GetChild(1).localScale.x;
    }

    void DrawIndicator()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            clone = Instantiate(indicator, new Vector3(mousePos.x, mousePos.y, 0), Quaternion.identity);
            clone.position = new Vector3(mousePos.x, mousePos.y, 0);
            innerCirce = clone.GetChild(1);
            curScale = innerCirce.localScale.x;
            forceCurLevel = ((slime.force - slime.minforce) / (slime.maxforce - slime.minforce)); // например 0.4 от максимума силы
            wantedScale = ((maxScale - minScale) * forceCurLevel + minScale); // прибавляем minScale, чтобы увеличивалось от начального размера, а не от 0
            step = (wantedScale - curScale);
        }

        if (Input.GetMouseButton(0) & curScale < maxScale)
        {
            innerCirce.localScale = new Vector3(innerCirce.localScale.x + step, innerCirce.localScale.y + step, innerCirce.localScale.z);
            innerCirce.rotation = new Quaternion(innerCirce.rotation.x, innerCirce.rotation.y, innerCirce.rotation.z + step, innerCirce.rotation.w);
        }

        if (Input.GetMouseButtonUp(0) || slime.heath < 1) Destroy(clone.gameObject);
      

    }
    void Update() {
        DrawIndicator();
    }
    
}
