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
            

            if(collision.name == "roughSlingShotTowerStage1(Clone)" || collision.name == "roughSlingShotTowerStage2(Clone)" || collision.name == "roughSlingShotTowerStage3(Clone)")
            {
                TowerPlace.slingAmount--;
            }
            else if (collision.name == "AutoballerTowerStage1(Clone)" || collision.name == "AutoballerTowerStage2(Clone)" || collision.name == "AutoballerTowerStage3(Clone)")
            {
                TowerPlace.autoAmount--;
            }
            else if (collision.name == "IcicleTowerStage1(Clone)" || collision.name == "IcicleTowerStage2(Clone)" || collision.name == "IcicleTowerStage3(Clone)")
            {
                TowerPlace.iceAmount--;
            }
        }
        if(collision.tag == "Tower")
        {
            FindObjectOfType<SoundManager>().Play("TowerBlowUp");
        }
        else if(collision.tag == "Enemy")
        {
            FindObjectOfType<SoundManager>().Play("EnemySplat");
        }
    }
}
