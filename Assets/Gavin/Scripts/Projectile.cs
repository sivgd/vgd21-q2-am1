using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float damage;
    public float speed;

    public Vector2 dir = new Vector2(0, 0);

    private void Update()
    {
        transform.Translate(dir * Time.deltaTime * speed);
    }

}
