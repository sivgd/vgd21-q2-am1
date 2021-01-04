using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float flashTime;
    public float health;
    public float maxHealth;
    public int damage;
    float bulletDamage;
    public GameObject cabbageCounter;
    SpriteRenderer sr;
    Color originalColor;
    public GameObject healthBar;
    // Start is called before the first frame update
    void Start()
    {
        maxHealth = health;
        sr = GetComponent<SpriteRenderer>();
        originalColor = sr.color;
        
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
            
            Flash();
            if (collision.gameObject.name =="IcicleAmmun(Clone)")
            {
                return;
            }
            Destroy(collision.gameObject);
        }
        if (collision.tag == "Farm")
        {
            collision.GetComponent<Farm>().farmHealth -= damage;

            Destroy(gameObject);
        }
    }

    void CheckHealth()
    {
        health -= bulletDamage;

        if (health <= 0)
        {
            Destroy(gameObject);
            Destroy(healthBar);
            CabbageCounter.cabbageAmount += 100;
            Waves.enemiesAlive--;
        }
        Debug.Log(health);
    }

    void Flash()
    {
        sr.color = Color.grey;
        Invoke("EndFlash", flashTime);

    }
    void EndFlash()
    {
        sr.color = originalColor;
    }
}
