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
    public int actualCost;
    public int ogCost;

    public float switchTargetOffset;

    public bool testBool;

    public Transform enemyParent;
    public Transform ammunitionParent;

    public GameObject nextStage;

    public static GameObject gameMaster;

    public GameObject nothing;

    public string towerName;
    public int stage;

    public GameObject ammunition;

    float shootingCooldown = 0;

    public bool isOgCostSet;

    public int targetMode;

    public char[] targetModes = { 'S', 'W', 'F', 'C', 'R' };
    public string[] targetModesNames;
    private void Awake()
    {
        ogCost = 0;
        SetActualCost();

    }
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
        
        if (nextStage != null)
        {
           
            float costOfTower = nextStage.GetComponent<Tower>().actualCost;
            if (CabbageCounter.cabbageAmount < costOfTower)
            {
                
                return;
            }

            GameObject newTower = Instantiate(nextStage, transform.position, new Quaternion(), transform.parent);
            newTower.GetComponent<Tower>().enemyParent = enemyParent;
            newTower.GetComponent<Tower>().ammunitionParent = ammunitionParent;
            CabbageCounter.cabbageAmount -= newTower.GetComponent<Tower>().actualCost;
            Destroy(gameObject);

        }
        else
        {
            print("No next stage");
        }



    }

    Transform TargetSelect(char targetMode)
    {
        //S = strongest/most health
        //W = weakest/lowest health
        //F = furthest
        //C = Closest
        //R = random
        if (targetMode == 'S')
        {
            return StrongestEnemy();
        }

        if (targetMode == 'W')
        {
            return WeakestEnemy();
        }

        if(targetMode == 'F')
        {
            return FurthestEnemy();
        }

        if (targetMode == 'C')
        {
            return ClosestEnemy();
        }

        if(targetMode == 'R')
        {
            return RandomEnemy();
        }

        return null;
    }



    Transform StrongestEnemy()
    {
        float currentRange = universalRangeMultiplier * range;

        //gets and returns the closest enemy under the enemyParent
        if (enemyParent.childCount == 0)
        {
            return null;
        }

        List<Transform> enemiesInRange = new List<Transform>();


        for (int i = 0; i < enemyParent.childCount; i++)
        {
            if (Vector2.Distance(enemyParent.GetChild(i).position, transform.position) < currentRange)
            {
                enemiesInRange.Add(enemyParent.GetChild(i));
            }
        }

        if (enemiesInRange.Count == 0)
        {
            return null;
        }

        //Where the actually target Selection happens above is just getting all in range
        Transform strongestEnemy = enemiesInRange[0];
        for (int i = 1; i < enemiesInRange.Count; i++)
        {
            Transform enemy = enemiesInRange[i];

            if (enemy.GetComponent<EnemyHealth>().health > strongestEnemy.GetComponent<EnemyHealth>().health)
            {
                strongestEnemy = enemy;
            }

        }

        return strongestEnemy;
    }

    Transform WeakestEnemy()
    {
        float currentRange = universalRangeMultiplier * range;

        //gets and returns the closest enemy under the enemyParent
        if (enemyParent.childCount == 0)
        {
            return null;
        }

        List<Transform> enemiesInRange = new List<Transform>();


        for (int i = 0; i < enemyParent.childCount; i++)
        {
            if (Vector2.Distance(enemyParent.GetChild(i).position, transform.position) < currentRange)
            {
                enemiesInRange.Add(enemyParent.GetChild(i));
            }
        }

        if (enemiesInRange.Count == 0)
        {
            return null;
        }

        //Where the actually target Selection happens above is just getting all in range
        Transform weakestEnemy = enemiesInRange[0];
        for (int i = 1; i < enemiesInRange.Count; i++)
        {
            Transform enemy = enemiesInRange[i];

            if (enemy.GetComponent<EnemyHealth>().health < weakestEnemy.GetComponent<EnemyHealth>().health)
            {
                weakestEnemy = enemy;
            }

        }

        return weakestEnemy;
    }

    Transform ClosestEnemy()
    {
        float currentRange = universalRangeMultiplier * range;

        //gets and returns the closest enemy under the enemyParent
        if (enemyParent.childCount == 0)
        {
            return null;
        }

        List<Transform> enemiesInRange = new List<Transform>();


        for (int i = 0; i < enemyParent.childCount; i++)
        {
            if (Vector2.Distance(enemyParent.GetChild(i).position, transform.position) < currentRange)
            {
                enemiesInRange.Add(enemyParent.GetChild(i));
            }
        }

        if (enemiesInRange.Count == 0)
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

    Transform FurthestEnemy()
    {
        float currentRange = universalRangeMultiplier * range;

        //gets and returns the closest enemy under the enemyParent
        if (enemyParent.childCount == 0)
        {
            return null;
        }

        List<Transform> enemiesInRange = new List<Transform>();


        for (int i = 0; i < enemyParent.childCount; i++)
        {
            if (Vector2.Distance(enemyParent.GetChild(i).position, transform.position) < currentRange)
            {
                enemiesInRange.Add(enemyParent.GetChild(i));
            }
        }

        if (enemiesInRange.Count == 0)
        {
            return null;
        }
        Transform furthestEnemy = enemiesInRange[0];
        for (int i = 1; i < enemiesInRange.Count; i++)
        {
            Transform enemy = enemiesInRange[i];

            if (Vector2.Distance(enemy.position, transform.position) > Vector2.Distance(furthestEnemy.position, transform.position))
            {
                furthestEnemy = enemy;
            }

        }

        return furthestEnemy;
    }

    Transform RandomEnemy()
    {
        float currentRange = universalRangeMultiplier * range;

        //gets and returns the closest enemy under the enemyParent
        if (enemyParent.childCount == 0)
        {
            return null;
        }

        List<Transform> enemiesInRange = new List<Transform>();


        for (int i = 0; i < enemyParent.childCount; i++)
        {
            if (Vector2.Distance(enemyParent.GetChild(i).position, transform.position) < currentRange)
            {
                enemiesInRange.Add(enemyParent.GetChild(i));
            }
        }

        if (enemiesInRange.Count == 0)
        {
            return null;
        }

        System.Random random = new System.Random((int) (Time.time * 1000));

        Transform randomEnemy = enemiesInRange[random.Next(0, enemiesInRange.Count)];

        return randomEnemy;
    }

    Transform FirstEnemy()
    {
        return null;
    }

    Transform LastEnemy()
    {
        return null;
    }
    void Shoot()
    {

        //Gets the closest enemy then turns the projectile then adds a force to push it in that direction
        if(targetMode >= targetModes.Length)
        {
            print("targetMode too big");
            return;
        }
        Transform targetedEnemyTransform = TargetSelect(targetModes[targetMode]);
        if(targetedEnemyTransform == null)
        {
            return;
        }
        Vector2 targetedEnemy = targetedEnemyTransform.position;


        GameObject projectile = Instantiate(ammunition, transform.position, new Quaternion(), ammunitionParent);
        projectile.GetComponent<Projectile>().damage = shootingDamage;
        projectile.GetComponent<Projectile>().dir = (new Vector3(targetedEnemy.x, targetedEnemy.y, 0) - transform.position).normalized;

        //Transform movement mostly in projectile script though

        if (towerName == "Sling Shot")
        {
            FindObjectOfType<SoundManager>().Play("Slingshot");
        }
        else if (towerName == "Icicle Launcher")
        {
            FindObjectOfType<SoundManager>().Play("Launcher");
        }
        else if (towerName == "Autoballer")
        {
            FindObjectOfType<SoundManager>().Play("Autoballer");
        }

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
        

        transform.GetChild(0).localScale = new Vector3(range * 2 * universalRangeMultiplier, range * 2 * universalRangeMultiplier, 1);
    }

    public void SetActualCost()
    {
        if(stage != 1)
        {
            return;
        }

        if(ogCost == 0 && !isOgCostSet && actualCost != 0)
        {
            isOgCostSet = true;
            ogCost = actualCost;

        }


        if (towerName == "Sling Shot")
        {
            actualCost = Convert.ToInt32(Mathf.Pow(TowerPlace.increaseMultiplier, TowerPlace.slingAmount) * ogCost);
        }
        else if (towerName == "Icicle Launcher")
        {
            actualCost = Convert.ToInt32(Mathf.Pow(TowerPlace.increaseMultiplier, TowerPlace.iceAmount) * ogCost);
        }
        else if (towerName == "Autoballer")
        {
            actualCost = Convert.ToInt32(Mathf.Pow(TowerPlace.increaseMultiplier, TowerPlace.autoAmount) * ogCost);
        }

        print("Slingam: " + TowerPlace.slingAmount + "; Increase: " + TowerPlace.increaseMultiplier + "; OGCost: " + ogCost + "; actualCost: " + actualCost);
    }
}