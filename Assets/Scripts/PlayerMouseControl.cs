using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouseControl : MonoBehaviour
{
    public GameObject pivot;
    
    void Start()
    {
        
    }
    void Update()
    {
        Vector3 mouse = Input.mousePosition;
        mouse.z = 8.962891f;

        Vector2 mousePositionNormal = mouse;
        Vector2 playerPositionNormal = Camera.main.WorldToScreenPoint(pivot.transform.position);
        float angle = Mathf.Atan2(mousePositionNormal.x - playerPositionNormal.x, mousePositionNormal.y - playerPositionNormal.y) * Mathf.Rad2Deg;
        angle += 90f;

        pivot.transform.rotation = Quaternion.Euler(new Vector3(0, 0, -angle));
    }
}
