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

        
        if (Random.Range(1, stormChance) == 1)
        {
            Snowstorm();
        }


        
    }


    void Snowstorm()
    {
        
        
        while (stormTime > 0)
        {
            Tower.universalRangeMultiplier = rangeMultiplier;
            

            stormTime -= Time.deltaTime;
        }
        stormTime = ogStormTime;
        Tower.universalRangeMultiplier = 1;
    }
}
