using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Tower : MonoBehaviour
{
    protected int shootingSpeed;
    protected int shootingDamage;

    public Transform enemyParent;

    public void Update()
    {
        Debug.DrawLine(transform.position, ClosestEnemy().position);
    }

    public virtual void Place(Vector2 position)
    {
        transform.SetPositionAndRotation(position, new Quaternion());
    }

    Transform ClosestEnemy()
    {
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
}