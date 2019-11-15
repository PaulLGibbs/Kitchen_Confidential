using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacter : Character
{

    private Rigidbody2D body;

    private void Start()
    {
        hp = maxHP;
        body = GetComponent<Rigidbody2D>();
    }

    public override void OnDealDamage(Character target, int damage)
    {
        Debug.Log("Enemy trying to deal damage");
    }

    public override void OnDeath(Character source, int damage)
    {
        Destroy(gameObject);
    }

    public override void OnReceiveDamage(Character source, int damage)
    {
        Vector2 sourcePosition = source.gameObject.transform.position;
        Vector2 selfPosition = gameObject.transform.position;

        Vector2 force = new Vector2(sourcePosition.x - selfPosition.x, sourcePosition.y - selfPosition.y).normalized;

        Debug.Log(force);

        body.AddForce(-force*5.0f, ForceMode2D.Impulse);
        Debug.Log("Enemy received damage");
    }
}
