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
        Debug.Log(stormOrNah);
        Debug.Log(Random.Range(1f, 2f));
        if (stormOrNah == 1)
        {
            Debug.Log("We're trying");
            Snowstorm();
        }


        
    }


    void Snowstorm()
    {
        
        
        while (stormTime > 0)
        {
            Tower.universalRangeMultiplier = rangeMultiplier;
            Debug.Log("Currently Storming");

            stormTime -= Time.deltaTime;
        }
        stormTime = ogStormTime;
        Tower.universalRangeMultiplier = 1;
    }
}
