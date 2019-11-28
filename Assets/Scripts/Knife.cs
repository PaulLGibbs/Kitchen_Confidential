using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    public int damage = 2;
    public float speed = 15.0f;
    public float expirationTime;
    public Character sourcePlayer;

    public void Fire(Character source)
    {
        sourcePlayer = source;
        expirationTime = Time.time + 2.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= expirationTime)
        {
            Destroy(gameObject);
        }
        transform.position += -transform.right * Time.deltaTime * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyCharacter>().Damage(sourcePlayer, damage);
            Destroy(gameObject);
        }
        else if(collision.gameObject.tag == "LevelDesign")
        {
            Destroy(gameObject);
        }
    }
}
