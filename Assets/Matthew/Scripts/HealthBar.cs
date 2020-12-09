using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{

    public GameObject attachedEnemy;
    float currentHealth;
    float maxHealth;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        currentHealth = attachedEnemy.GetComponent<EnemyHealth>().health;
        maxHealth = attachedEnemy.GetComponent<EnemyHealth>().maxHealth;
        float healthPercentage = currentHealth / maxHealth;
        float enemyX = attachedEnemy.GetComponent<Transform>().position.x;
        float enemyY = attachedEnemy.GetComponent<Transform>().position.y;
        float enemyZ = attachedEnemy.GetComponent<Transform>().position.z;
        gameObject.transform.position = new Vector3(enemyX, enemyY + 5/4, enemyZ);
        gameObject.transform.localScale = new Vector3(healthPercentage, 0.25f, 1);
        
    }
}
