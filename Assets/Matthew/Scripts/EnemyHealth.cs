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
    public int money;

    public GameObject farm;
    new Transform transform;

    private Vector3 currentPos;
    private Vector3 lastPos;

    public RuntimeAnimatorController attackAnimator;
    
    public float timeToDestroy;
    // Start is called before the first frame update
    void Start()
    {
        maxHealth = health;
        sr = GetComponent<SpriteRenderer>();
        originalColor = sr.color;
        transform = GetComponent<Transform>();
        
    }

    // Update is called once per frame
    void Update()
    {
        currentPos = transform.position;

        if (currentPos == lastPos)
        {
            StartCoroutine(Attack());
        }

        lastPos = currentPos;
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
            

            Destroy(gameObject);
            Waves.enemiesAlive--;
            CabbageCounter.cabbageAmount += money;
        }
    }

    void CheckHealth()
    {
        health -= bulletDamage;

        if (health <= 0)
        {
            Destroy(gameObject);
            Destroy(healthBar);
            CabbageCounter.cabbageAmount += money;
            Waves.enemiesAlive--;
        }
        
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

    IEnumerator Attack()
    {
        
        sr.flipX = true;
        GetComponent<Animator>().runtimeAnimatorController = attackAnimator;
        yield return new WaitForSeconds(timeToDestroy);
        farm.GetComponent<EnemyFarmCollision>().TakeDamage(damage);
        Destroy(gameObject);
        Destroy(healthBar);
        Waves.enemiesAlive--;
        
    }
}
