using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Tower : MonoBehaviour
{
    public float projectileSpeed;
    public float shootingSpeed;
    public float shootingDamage;

    public Transform enemyParent;
    public Transform ammunitionParent;


    public GameObject ammunition;

    float shootingCooldown = 0;
    public void Update()
    {
        //A line between tower and closest enemy
        //Debug.DrawLine(transform.position, ClosestEnemy().position);
        if (shootingCooldown <= 0)
        {
            Shoot();
            shootingCooldown = shootingSpeed;
        }
        shootingCooldown -= Time.deltaTime;
    }

    public virtual void Place(Vector2 position)
    {
        transform.SetPositionAndRotation(position, new Quaternion());
    }

    Transform ClosestEnemy()
    {
        //gets and returns the closest enemy under the enemyParent
        if(enemyParent.childCount == 0)
        {
            return null;
        }
        Transform closestEnemy = enemyParent.GetChild(0);
        for (int i = 1; i < enemyParent.childCount; i++)
        {
            if(Vector2.Distance(enemyParent.GetChild(i).position, transform.position) < Vector2.Distance(closestEnemy.position, transform.position))
            {
                closestEnemy = enemyParent.GetChild(i);
            }

        }

        return closestEnemy;
    }

    void Shoot()
    {

        //Gets the closest enemy then turns the projectile then adds a force to push it in that direction
        Transform closestEnemyTransform = ClosestEnemy();
        if(closestEnemyTransform == null)
        {
            return;
        }
        Vector2 closestEnemy = closestEnemyTransform.position;


        GameObject projectile = Instantiate(ammunition, transform.position, new Quaternion(), ammunitionParent);
        projectile.GetComponent<Projectile>().damage = shootingDamage;
        projectile.transform.right = new Vector3(closestEnemy.x, closestEnemy.y, projectile.transform.position.z) - projectile.transform.position;

        projectile.GetComponent<Rigidbody2D>().AddForce(projectile.transform.right * projectileSpeed);

        StartCoroutine(DeleteObject(projectile, 3));
    }

    IEnumerator DeleteObject(GameObject gameObject, float time)
    {
        yield return new WaitForSeconds(time);

        Destroy(gameObject);
    }
}