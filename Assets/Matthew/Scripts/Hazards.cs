using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Hazards : MonoBehaviour
{

    bool snowstorm;
    public int stormChance;
    public float ogStormTime;
    public float stormTime;
    public float rangeMultiplier;
   
    
    // Start is called before the first frame update
    void Start()
    {
        ogStormTime = stormTime;
    }

    // Update is called once per frame
    void Update()
    {
        int stormOrNah = Random.Range(1, stormChance + 1);
       
        if (stormOrNah == 1)
        {
            
            Snowstorm();
        }


        
    }


    void Snowstorm()
    {
        
        
        if (stormTime > 0)
        {
            rangeMultiplier = 0.5f;
            Debug.Log("Time: " + stormTime);

            stormTime -= Time.deltaTime;
            return;
        }
        stormTime = ogStormTime;
        rangeMultiplier = 1f;
    }
}
