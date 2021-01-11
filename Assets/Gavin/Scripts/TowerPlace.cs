using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TowerPlace : MonoBehaviour
{
    public Camera camera;

    public GameObject farmerMenu;

    GameObject towerUI;

    public GameObject towerBeingPlaced;
    public bool isTowerBeingDragged;

    public Transform towerParent;
    public Transform enemyParent;
    public Transform ammunitionParent;

    public GameObject roughSlingShotTowerPrefab;
    public GameObject icicleTowerPrefab;
    public GameObject autoballerTowerPrefab;
    public GameObject slushapultTowerPrefab;

    public Color canPlaceColor;
    public Color canNotPlaceColor;

    public static int slingAmount;
    public static int autoAmount;
    public static int iceAmount;

    public static float increaseMultiplier;
    public void Start()
    {
        Tower.gameMaster = gameObject;
        Tower.universalRangeMultiplier = gameObject.GetComponent<Hazards>().rangeMultiplier;
        isTowerBeingDragged = false;
        slingAmount = 0;
        autoAmount = 0;
        iceAmount = 0;
        increaseMultiplier = 1.5f;
    }

    public void Update()
    {
        if(towerBeingPlaced != null && !isTowerBeingDragged)
        {
            Vector2 mousePosition = camera.ScreenToWorldPoint(Input.mousePosition);
            towerBeingPlaced.transform.position = mousePosition;

            if (Input.GetMouseButtonDown(0))
            {
                PlaceTower();
            }
        }else if (towerBeingPlaced != null && isTowerBeingDragged)
        {
            OnDrag();

            if (Input.GetMouseButtonUp(0))
            {
                OnEndDrag();
                towerUI = null;
            }
        }

    }
    public bool CheckIfCanPlace(Vector2 position)
    {
        

        //RaycastHit2D ray = Physics2D.Raycast(position, Vector2.zero);
        RaycastHit2D ray = Physics2D.BoxCast(position, new Vector2(1, 1.2f), 0, Vector2.zero);
        if (CabbageCounter.cabbageAmount < towerBeingPlaced.GetComponent<Tower>().actualCost)
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
            CabbageCounter.cabbageAmount -= towerBeingPlaced.GetComponent<Tower>().actualCost;
            if(towerBeingPlaced.GetComponent<Tower>().name == "Sling Shot")
            {
                slingAmount++;
                
                
            }
            else if (towerBeingPlaced.name == "AutoballerTowerStage1")
            {
                autoAmount++;
                
            }
            else if (towerBeingPlaced.name == "IcicleTowerStage1")
            {
                iceAmount++;
                

            }
        }
        else
        {
            Destroy(towerBeingPlaced);
        }

        towerBeingPlaced = null;



    }

    

    public void OnDrag()
    {


        Vector2 position = camera.ScreenToWorldPoint(Input.mousePosition);

        towerBeingPlaced.transform.position = position;

        towerBeingPlaced.GetComponent<Tower>().SetRangeUI();

        if (!CheckIfCanPlace(towerBeingPlaced.transform.position))
        {
            towerBeingPlaced.transform.GetChild(0).GetComponent<SpriteRenderer>().color = canNotPlaceColor;
        }
        else
        {
            towerBeingPlaced.transform.GetChild(0).GetComponent<SpriteRenderer>().color = canPlaceColor;
        }
    }

    public void OnEndDrag()
    {
       

        Vector2 position = camera.ScreenToWorldPoint(Input.mousePosition);

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
            CabbageCounter.cabbageAmount -= towerBeingPlaced.GetComponent<Tower>().actualCost;
            if (towerBeingPlaced.GetComponent<Tower>().towerName == "Sling Shot")
            {

                slingAmount++;
                slushapultTowerPrefab.GetComponent<Tower>().actualCost = Convert.ToInt32(Mathf.Pow(increaseMultiplier, slingAmount) * slushapultTowerPrefab.GetComponent<Tower>().actualCost);

            }
            else if (towerBeingPlaced.name == "AutoballerTowerStage1")
            {
                autoAmount++;
                autoballerTowerPrefab.GetComponent<Tower>().actualCost = Convert.ToInt32(Mathf.Pow(increaseMultiplier, autoAmount) * autoballerTowerPrefab.GetComponent<Tower>().actualCost);

            }
            else if (towerBeingPlaced.name == "IcicleTowerStage1")
            {
                iceAmount++;
                icicleTowerPrefab.GetComponent<Tower>().actualCost = Convert.ToInt32(Mathf.Pow(increaseMultiplier, iceAmount) * icicleTowerPrefab.GetComponent<Tower>().actualCost);

            }
        }
        else
        {
            Destroy(towerBeingPlaced);
        }

        towerBeingPlaced = null;




        //Showing the tower ui and untinting
        GameObject towerSpr = towerUI.transform.GetChild(1).gameObject;
        towerSpr.SetActive(true);
        GameObject tint = towerUI.transform.GetChild(2).gameObject;
        tint.GetComponent<Image>().color = new Color(0, 0, 0, 0);

        isTowerBeingDragged = false;
    }

    public void OnBeginDrag(GameObject towerUI1)
    {
        towerUI = towerUI1;

        farmerMenu.gameObject.SetActive(false);

        

        isTowerBeingDragged = true;

        GameObject prefab = null;
        switch (towerUI.tag)
        {
            case "SlingshotUI":
                prefab = roughSlingShotTowerPrefab;
                break;
            case "IcicleUI":
                prefab = icicleTowerPrefab;
                break;
            case "AutoballerUI":
                prefab = autoballerTowerPrefab;
                break;
            case "SlushapultUI":
                prefab = slushapultTowerPrefab;
                break;
        }


        Vector2 position = camera.ScreenToWorldPoint(Input.mousePosition);

        GameObject tower = Instantiate(prefab, position, new Quaternion(), towerParent);
        tower.GetComponent<Tower>().enemyParent = enemyParent;
        tower.GetComponent<Tower>().ammunitionParent = ammunitionParent;

        //Setting the RangeUI
        tower.GetComponent<Tower>().SetRangeUI();

        //Disabling everything not needed
        tower.GetComponent<Tower>().enabled = false;
        tower.GetComponent<CapsuleCollider2D>().enabled = false;
        tower.transform.GetChild(1).gameObject.SetActive(false);

        //Enabling the RangeUI
        tower.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;

        towerBeingPlaced = tower;



        //Hiding the tower UI and tinting
        GameObject towerSpr = towerUI.transform.GetChild(1).gameObject;
        towerSpr.SetActive(false);
        GameObject tint = towerUI.transform.GetChild(2).gameObject;
        tint.GetComponent<Image>().color = new Color(0, 0, 0, 0.2f);

        
    }
}
