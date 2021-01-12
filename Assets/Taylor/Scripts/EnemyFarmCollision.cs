using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyFarmCollision : MonoBehaviour
{
    public int maxFarmHealth = 1000;
    public int currentFarmHealth;

    public FarmHealthBar farmHealthBar;

    // Start is called before the first frame update
    void Start()
    {
        currentFarmHealth = maxFarmHealth;
        farmHealthBar.SetHealth(maxFarmHealth);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collisionInfo)
    {

        if (collisionInfo.collider.tag == "Standard")
        {
            TakeDamage(20);
        }

        if (collisionInfo.collider.tag == "Speed")
        {
            TakeDamage(40);
        }

        if (collisionInfo.collider.tag == "Hulk")
        {
            TakeDamage(80);
        }
    }

    public void TakeDamage(int damage)
    {
        currentFarmHealth -= damage;

        farmHealthBar.SetHealth(currentFarmHealth);

        if (currentFarmHealth == 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}