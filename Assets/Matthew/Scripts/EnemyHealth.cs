using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    public float health;
    public float damage;
    float bulletDamage;
    public GameObject cabbageCounter;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "TowerProjectile")
        {
            bulletDamage = collision.GetComponent<Projectile>().damage;
            CheckHealth();
            Destroy(collision.gameObject);
        }
    }

    void CheckHealth()
    {
        health -= bulletDamage;

        if (health <= 0)
        {
            Destroy(gameObject);
            cabbageCounter.GetComponent<CabbageCounter>().cabbageAmount += 100;
        }
    }
}
