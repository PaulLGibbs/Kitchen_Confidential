using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour
{
    public int damage = 1;
    public float speed = 13.0f;
    public float expirationTime;
    public Character source;

    public void Fire(Character source)
    {
        this.source = source;
        expirationTime = Time.time + 2.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= expirationTime)
        {
            Destroy(gameObject);
        }
        transform.position += -transform.right * Time.deltaTime * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Player>().Damage(source, damage);
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "LevelDesign")
        {
            Destroy(gameObject);
        }
    }
}
