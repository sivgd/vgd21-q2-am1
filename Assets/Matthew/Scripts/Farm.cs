﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farm : MonoBehaviour
{

    public GameObject farm;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            
            farm.GetComponent<EnemyFarmCollision>().TakeDamage(collision.GetComponent<EnemyHealth>().damage);
        }
    }
}
