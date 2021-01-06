using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TowerPlace : MonoBehaviour
{
    public Camera camera;

    public GameObject towerBeingPlaced;

    public void Start()
    {
        Tower.gameMaster = gameObject;
        Tower.universalRangeMultiplier = gameObject.GetComponent<Hazards>().rangeMultiplier;
    }

    public void Update()
    {
        if(towerBeingPlaced != null)
        {
            Vector2 mousePosition = camera.ScreenToWorldPoint(Input.mousePosition);
            towerBeingPlaced.transform.position = mousePosition;

            if (Input.GetMouseButtonDown(0))
            {
                PlaceTower();
            }
        }

    }
    public bool CheckIfCanPlace(Vector2 position)
    {


        //RaycastHit2D ray = Physics2D.Raycast(position, Vector2.zero);
        RaycastHit2D ray = Physics2D.BoxCast(position, new Vector2(1, 1.2f), 0, Vector2.zero);
        if (CabbageCounter.cabbageAmount < towerBeingPlaced.GetComponent<Tower>().cost)
        {
            return false;
        }
        if (ray.collider == null)
        {
            return true;
        }
        if (ray.collider.name != "RoughMapCantPlaceArea" && ray.collider.tag != "Tower")
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void PlaceTower()
    {
        Vector2 position = camera.ScreenToWorldPoint(Input.mousePosition);
        Vector2 offset = new Vector2(0, 0.5f);
        bool canPlace = CheckIfCanPlace(position);

        if (canPlace)
        {
            //Re-enabling everything
            towerBeingPlaced.GetComponent<Tower>().enabled = true;
            towerBeingPlaced.GetComponent<CapsuleCollider2D>().enabled = true;
            towerBeingPlaced.transform.GetChild(1).gameObject.SetActive(true);

            //Disabling the rangeUI
            towerBeingPlaced.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;

            //Taking the cost of the tower from cabbage amount
            CabbageCounter.cabbageAmount -= towerBeingPlaced.GetComponent<Tower>().cost;
        }
        else
        {
            Destroy(towerBeingPlaced);
        }

        towerBeingPlaced = null;



    }
}
