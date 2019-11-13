using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    public GameObject pivot;
    public GameObject area;
    public GameObject player;

    public float attackCooldown = 0.5f; // cooldown between attacks in seconds

    private float nextAttack = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
            Attack();

        Vector3 mouse = Input.mousePosition;
        mouse.z = 8.962891f;

        Vector2 mousePositionNormal = mouse;
        Vector2 playerPositionNormal = Camera.main.WorldToScreenPoint(player.transform.position);
        float angle = Mathf.Atan2( mousePositionNormal.x -playerPositionNormal.x,  mousePositionNormal.y - playerPositionNormal.y ) * Mathf.Rad2Deg;
        angle += 90f;

        pivot.transform.rotation = Quaternion.Euler(new Vector3(0, 0, -angle));
    }

    void Attack()
    {
        if (Time.time < nextAttack) return;

        Debug.Log("Attempting an attack");
        nextAttack = Time.time + attackCooldown;
    }
}
