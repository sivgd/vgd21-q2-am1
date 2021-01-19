using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Hazards : MonoBehaviour
{
    //Snowstorm variables
    public static bool snowstorm;
    public int stormChance;
    public float ogStormTime;
    public static float stormTime;
    public float rangeMultiplier;
    

    //Avalanche variables
    public static bool avalanche;
    public int avalancheChance;
    public int minimumSnowballs;
    public int maximumSnowballs;
    public GameObject snowball;

    public GameObject indicator;

    public GameObject enemyParent;
    // Start is called before the first frame update
    void Start()
    {
        Tower.universalRangeMultiplier = 1f;
        avalanche = false;
        snowstorm = false;
        indicator.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        stormTime = ogStormTime;
    }

    // Update is called once per frame
    void Update()
    {
        int stormOrNah = Random.Range(1, stormChance + 1);
       
        if (stormOrNah == 1 && snowstorm == false && avalanche == false && enemyParent.transform.childCount > 0)
        {
            
            StartCoroutine(Snowstorm());
            return;
        }

        int avalancheOrNah = Random.Range(1, avalancheChance + 1);

        if (avalancheOrNah == 1 && avalanche == false && snowstorm == false && enemyParent.transform.childCount > 0)
        {

            StartCoroutine(Avalanche());
            return;
        }
        

        if (Input.GetKeyDown(KeyCode.S))
        {
            Vector2 pos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            var rot = Quaternion.Euler(0, 0, 0);
            Instantiate(snowball, pos, rot);
        }
    }

    IEnumerator Snowstorm()
    {
        snowstorm = true;
        Tower.universalRangeMultiplier = rangeMultiplier;
        
        indicator.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        
        yield return new WaitForSeconds(stormTime);
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
