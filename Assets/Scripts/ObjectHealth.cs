using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHealth : MonoBehaviour
{
    public float health; //percentage of health
    public float maxHealth = 100.0f;
    private bool hit = false;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.localScale = new Vector2((transform.localScale.x * (health / maxHealth)), transform.localScale.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Damage" || collision.gameObject.tag == "Enemy" && !hit)
        {
            health -= 10;
            hit = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        hit = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Fire")
        {
            health -= 5; 
        }
    }
}
