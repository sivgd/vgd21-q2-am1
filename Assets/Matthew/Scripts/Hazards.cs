using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Hazards : MonoBehaviour
{

    bool snowstorm;
    public int stormChance;
    
    public float stormTime;
    public float rangeMultiplier;
    public float ogRangeMultiplier;
   
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int stormOrNah = Random.Range(1, stormChance + 1);
       
        if (stormOrNah == 1 && snowstorm == false)
        {
            
            StartCoroutine(Snowstorm());
            return;
        }
        

        
    }

    IEnumerator Snowstorm()
    {
        snowstorm = true;
        rangeMultiplier = ogRangeMultiplier;
        Debug.Log("Start Wait");
        yield return new WaitForSeconds(stormTime);
        Debug.Log("End Wait");
        rangeMultiplier = 1f;
        snowstorm = false;

    }
}
