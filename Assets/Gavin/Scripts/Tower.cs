using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Tower : MonoBehaviour
{
    public float projectileSpeed;
    public float shootingSpeed;
    public float shootingDamage;
    public float range;
    public int cost;

    public float switchTargetOffset;

    public bool testBool;

    public Transform enemyParent;
    public Transform ammunitionParent;

    public string towerName;

    public GameObject ammunition;

    float shootingCooldown = 0;

    private void Start()
    {
        transform.GetChild(0).localScale = new Vector3(range * 2, range * 2, 1);
    }

    public void Update()
    {
        //A line between tower and closest enemy for debugging target selection
        if (ClosestEnemy() != null)
        {
            //Debug.DrawLine(transform.position, ClosestEnemy().position);
        }
        if (shootingCooldown <= 0)
        {
            Shoot();
            shootingCooldown = shootingSpeed;
        } 
        shootingCooldown -= Time.deltaTime;
    }

    public void Place(Vector2 position)
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

        List<Transform> enemiesInRange = new List<Transform>();


        for(int i = 0;i< enemyParent.childCount; i++)
        {
            if(Vector2.Distance(enemyParent.GetChild(i).position, transform.position) < range)
            {
                enemiesInRange.Add(enemyParent.GetChild(i));
            }
        }

        if(enemiesInRange.Count == 0)
        {
            return null;
        }
        Transform closestEnemy = enemiesInRange[0];
        for (int i = 1; i < enemiesInRange.Count; i++)
        {
            Transform enemy = enemiesInRange[i];

            if (Vector2.Distance(enemy.position, transform.position) < Vector2.Distance(closestEnemy.position, transform.position))
            {
                closestEnemy = enemy;
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
        projectile.GetComponent<Projectile>().dir = (new Vector3(closestEnemy.x, closestEnemy.y, 0) - transform.position).normalized;

        //Transform movement mostly in projectile script though



        //Physics based movement
        /*projectile.GetComponent<Projectile>().damage = shootingDamage;
        projectile.transform.right = new Vector3(closestEnemy.x, closestEnemy.y, projectile.transform.position.z) - projectile.transform.position;

        projectile.GetComponent<Rigidbody2D>().AddForce(projectile.transform.right * projectileSpeed);*/

        StartCoroutine(DeleteObject(projectile, 5));
    }

    IEnumerator DeleteObject(GameObject gameObject, float time)
    {
        yield return new WaitForSeconds(time);

        Destroy(gameObject);
    }
}