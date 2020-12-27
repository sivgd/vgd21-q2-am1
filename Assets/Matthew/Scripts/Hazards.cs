using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazards : MonoBehaviour
{

    bool snowstorm;
    public int stormChance;
    public float stormTime;
    public float rangeMultiplier;
    public GameObject towerParent;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        
        if (Random.Range(1, 1) <= stormChance)
        {
            Snowstorm();
        }



    }


    void Snowstorm()
    {
        
        float originalRange = towerParent.GetComponentInChildren<Tower>().range;
        while (stormTime > 0)
        {
            
            towerParent.GetComponentInChildren<Tower>().range = originalRange * rangeMultiplier;

            stormTime -= Time.deltaTime;
        }

    }
}
