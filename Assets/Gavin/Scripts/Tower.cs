using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Tower : MonoBehaviour
{
    protected int shootingSpeed;
    protected int shootingDamage;

    public virtual void Place(Vector2 position)
    {
        transform.SetPositionAndRotation(position, new Quaternion());
    }
}