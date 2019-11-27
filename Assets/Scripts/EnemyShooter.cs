using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public float shootCooldown = 2.0f;
    public GameObject shotPrefab;

    private float nextShootTime = 0.0f;


    private GameObject foundPlayer;

    // Start is called before the first frame update
    void Start()
    {
        foundPlayer = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= nextShootTime && foundPlayer)
        {
            Vector2 sourcePosition = transform.position;
            Vector2 playerPosition = foundPlayer.transform.position;
            float angle = Mathf.Atan2(playerPosition.x - sourcePosition.x, playerPosition.y - sourcePosition.y) * Mathf.Rad2Deg;
            angle += 90f;

            GameObject enemyShot = GameObject.Instantiate(shotPrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, -angle)));
            enemyShot.GetComponent<EnemyShot>().Fire(GetComponent<Character>());

            nextShootTime = Time.time + shootCooldown;
        }
    }
}
