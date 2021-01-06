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

    public GameObject nextStage;

    public static GameObject gameMaster;

    public string towerName;
    public int stage;

    public GameObject ammunition;

    float shootingCooldown = 0;

    public static float universalRangeMultiplier;
    private void Start()
    {
        SetRangeUI();
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

    public void Upgrade()
    {
        print("Upgrade");
        if (nextStage != null)
        {
            float costOfTower = nextStage.GetComponent<Tower>().cost;
            if (CabbageCounter.cabbageAmount <= costOfTower)
            {
                print("Not enough money");
                return;
            }

            GameObject newTower = Instantiate(nextStage, transform.position, new Quaternion(), transform.parent);
            newTower.GetComponent<Tower>().enemyParent = enemyParent;
            newTower.GetComponent<Tower>().ammunitionParent = ammunitionParent;
            CabbageCounter.cabbageAmount -= newTower.GetComponent<Tower>().cost;
            Destroy(gameObject);

        }
        else
        {
            print("No next stage");
        }



    }

    Transform ClosestEnemy()
    {
        float currentRange = universalRangeMultiplier * range;

        //gets and returns the closest enemy under the enemyParent
        if(enemyParent.childCount == 0)
        {
            return null;
        }

        List<Transform> enemiesInRange = new List<Transform>();


        for(int i = 0;i< enemyParent.childCount; i++)
        {
            if(Vector2.Distance(enemyParent.GetChild(i).position, transform.position) < currentRange * universalRangeMultiplier)
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

    public void SetRangeUI()
    {
        print("Range: " + range);
        print("Uni range: " + universalRangeMultiplier);
        transform.GetChild(0).localScale = new Vector3(range * 2 * universalRangeMultiplier, range * 2 * universalRangeMultiplier, 1);
    }

}