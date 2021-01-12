using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float damage;
    public float speed;

    public bool isPiercing;
    public bool isAoe;

    public Vector2 dir = new Vector2(0, 0);

    private void Update()
    {
        transform.Translate(dir * Time.deltaTime * speed);
    }

    private void OnDestroy()
    {
    }

    public void DestroyProjectile()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
        gameObject.GetComponent<Projectile>().enabled = false;
        transform.GetComponent<ParticleSystem>().Stop();
        Destroy(gameObject, 3);
    }

}
