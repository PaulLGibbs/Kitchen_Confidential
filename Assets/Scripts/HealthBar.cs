using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public GameObject subject;
    public GameObject healthBar;
    public ObjectHealth health;
    private float healthPercent;
    public Vector3 respawnPoint;

    public void Kill()
    {
        subject.transform.position = respawnPoint;
        health.health = health.maxHealth;
    }

    // Start is called before the first frame update
    void Start()
    {
        health = subject.GetComponent<ObjectHealth>();
        healthPercent = health.health / health.maxHealth;
        transform.position = new Vector3(subject.transform.position.x - 1, subject.transform.position.y + 1, transform.position.z);
        respawnPoint = subject.gameObject.transform.position;
        //Debug.Log(healthPercent);
    }

    // Update is called once per frame
    void Update()
    {
        healthPercent = health.health / health.maxHealth;
        //Debug.Log(healthPercent);
        transform.position = new Vector3(subject.transform.position.x, subject.transform.position.y + 1, transform.position.z);
        if(healthPercent >= 0)
        {
            healthBar.transform.localScale = new Vector2((transform.localScale.x * (healthPercent)), transform.localScale.y);
        }
        if(healthPercent <= 0)
        {
            if(subject.gameObject.name != "Player")
            {
                Destroy(subject);
                Destroy(gameObject);
            }
            else
            {
                Kill();
            }
        }
    }


}
