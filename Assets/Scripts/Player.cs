using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{

    [Header("Attack properties")]
    public GameObject pivot;
    public GameObject area;
    public GameObject player;
    public float attackCooldown = 0.5f; // cooldown between attacks in seconds
    private float nextAttack = 0.0f;

    [Header("Movement properties")]
    public KeyCode leftKey = KeyCode.A;
    public KeyCode rightKey = KeyCode.D;
    public KeyCode upKey = KeyCode.W;
    public KeyCode downKey = KeyCode.S;
    public float speed = 3.0f;


    private Rigidbody2D body;

    // Start is called before the first frame update
    void Start()
    {
        hp = maxHP;
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
            Attack();
    }

    void FixedUpdate()
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

    void Attack()
    {
        if (Time.time < nextAttack) return;

        Debug.Log("Attempting an attack");
        nextAttack = Time.time + attackCooldown;

        Collider2D collider = area.GetComponent<Collider2D>();
        Collider2D[] colliders = new Collider2D[20];
        ContactFilter2D filter = new ContactFilter2D();
        collider.OverlapCollider(filter, colliders);

        foreach(Collider2D c in colliders)
        {
            if(c && c.gameObject && c.gameObject.tag == "Enemy")
            {
                EnemyCharacter enemy = c.gameObject.GetComponent<EnemyCharacter>();
                enemy.Damage(this, 1);
            }
        }
    }

    public override void OnReceiveDamage(Character source, int damage)
    {
        Debug.Log("Player receiving damage!");
    }

    public override void OnDealDamage(Character target, int damage)
    {
        Debug.Log("Player dealing damage!");
    }

    public override void OnDeath(Character source, int damage)
    {
        Debug.Log("Player dying!!!");
    }
}
