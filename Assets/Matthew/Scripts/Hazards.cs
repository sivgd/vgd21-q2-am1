using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Hazards : MonoBehaviour
{
    //Snowstorm variables
    bool snowstorm;
    public int stormChance;
    public float stormTime;
    public float rangeMultiplier;
    public float ogRangeMultiplier;

    //Avalanche variables
    bool avalanche;
    public int avalancheChance;
    public int minimumSnowballs;
    public int maximumSnowballs;
    public GameObject snowball;

    public GameObject indicator;
    // Start is called before the first frame update
    void Start()
    {
        avalanche = false;
        snowstorm = false;
        indicator.gameObject.GetComponent<SpriteRenderer>().enabled = false;
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

        int avalancheOrNah = Random.Range(1, avalancheChance + 1);

        if (avalancheOrNah == 1 && avalanche == false)
        {

            Avalanche();
            return;
        }
        
    }

    IEnumerator Snowstorm()
    {
        snowstorm = true;
        rangeMultiplier = ogRangeMultiplier;
        
        indicator.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        yield return new WaitForSeconds(stormTime);
        
        indicator.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        rangeMultiplier = 1f;
        snowstorm = false;

    }

    void Avalanche()
    {
        avalanche = true;
        var rotation = Quaternion.Euler(0, 0, 0);
        var position = new Vector3(Random.Range(-15f, 12f), Random.Range(-10f, 6f), 0f);
        int snowballAmount = Random.Range(minimumSnowballs, maximumSnowballs);

        for (int i = 0; i < snowballAmount; i++)
        {
            GameObject snowballAccess = Instantiate(snowball, position, rotation);
            
        }

        avalanche = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
