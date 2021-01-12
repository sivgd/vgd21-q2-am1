using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Hazards : MonoBehaviour
{
    //Snowstorm variables
    public static bool snowstorm;
    public int stormChance;
    public static float stormTime;
    public float rangeMultiplier;
    

    //Avalanche variables
    public static bool avalanche;
    public int avalancheChance;
    public int minimumSnowballs;
    public int maximumSnowballs;
    public GameObject snowball;

    public GameObject indicator;
    // Start is called before the first frame update
    void Start()
    {
        Tower.universalRangeMultiplier = 1f;
        avalanche = false;
        snowstorm = false;
        indicator.gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        int stormOrNah = Random.Range(1, stormChance + 1);
       
        if (stormOrNah == 1 && snowstorm == false && avalanche == false)
        {
            
            StartCoroutine(Snowstorm());
            return;
        }

        int avalancheOrNah = Random.Range(1, avalancheChance + 1);

        if (avalancheOrNah == 1 && avalanche == false && snowstorm == false)
        {

            StartCoroutine(Avalanche());
            return;
        }
        
    }

    IEnumerator Snowstorm()
    {
        snowstorm = true;
        Tower.universalRangeMultiplier = rangeMultiplier;
        
        indicator.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        print("123456");
        yield return new WaitForSeconds(stormTime);
        print("SDKLFJHLKSDJFHKLSJDFHL");
        indicator.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        Tower.universalRangeMultiplier = 1f;
        snowstorm = false;

    }

    IEnumerator Avalanche()
    {
        avalanche = true;
        var rotation = Quaternion.Euler(0, 0, 0);
        
        int snowballAmount = Random.Range(minimumSnowballs, maximumSnowballs);

        for (int i = 0; i < snowballAmount; i++)
        {
            var position = new Vector3(Random.Range(-15f, 12f), Random.Range(-10f, 6f), 0f);
            GameObject snowballAccess = Instantiate(snowball, position, rotation);
            yield return new WaitForSeconds(0.2f);
        }

        avalanche = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
