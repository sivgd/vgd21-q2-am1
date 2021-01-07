using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snowball : MonoBehaviour
{

    public float survivalTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        survivalTime -= Time.deltaTime;
        if (survivalTime <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Tower" || collision.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
