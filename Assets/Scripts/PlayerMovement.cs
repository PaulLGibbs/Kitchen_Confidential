using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public KeyCode leftKey = KeyCode.A;
    public KeyCode rightKey = KeyCode.D;
    public KeyCode upKey = KeyCode.W;
    public KeyCode downKey = KeyCode.S;

    public float speed = 3.0f;


    private Rigidbody2D body;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float vx = 0.0f;
        float vy = 0.0f;

        if (Input.GetKey(leftKey))
            vx = -speed;
        if (Input.GetKey(rightKey))
            vx = speed;
        if (Input.GetKey(upKey))
            vy = speed;
        if (Input.GetKey(downKey))
            vy = -speed;

        body.velocity = new Vector2(vx, vy);
    }
}
