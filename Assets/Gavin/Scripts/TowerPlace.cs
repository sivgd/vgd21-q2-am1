using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TowerPlace : MonoBehaviour
{
    public new Camera camera;

    public GameObject roughSlingShotTowerPrefab;
    public GameObject icicleTowerPrefab;
    public GameObject autoballerTowerPrefab;
    public GameObject slushapultTowerPrefab;

    public Transform towerParent;
    public Transform enemyParent;
    public Transform ammunitionParent;

    public Transform towerSelections;
    public Transform selectedTower;

    public Color canPlaceColor;
    public Color canNotPlaceColor;

    GameObject towerCurrentlyBeingDragged;
    // Start is called before the first frame update


    void Start()
    {
        towerCurrentlyBeingDragged = null;
    }

    // Update is called once per frame
    void Update()
    {
        /*
         * 
         * For debugging when placing isn't working for some reason. Don't know why I don't want to delete it but I refuse to
        if (Input.GetMouseButtonDown(0) && false)
        {
            Vector2 position = camera.ScreenToWorldPoint(Input.mousePosition);
            Vector2 offset = new Vector2(0, 0.5f);
            bool canPlace = CheckIfCanPlace(position);
            print(canPlace);

            if (canPlace)
            {
                GameObject tower = Instantiate(roughSlingShotTowerPrefab, position + offset, new Quaternion(), towerParent);
                tower.GetComponent<Tower>().enemyParent = enemyParent;
                tower.GetComponent<Tower>().ammunitionParent = ammunitionParent;
                CabbageCounter.cabbageAmount -= tower.GetComponent<Tower>().cost;
            }
        }*/

    }

    public bool CheckIfCanPlace(Vector2 position)
    {
        
        GameObject tower = null;
        switch (selectedTower.parent.tag)
        {
            case "SlingshotUI":
                tower = roughSlingShotTowerPrefab;
                break;
            case "IcicleUI":
                tower = icicleTowerPrefab;
                break;
            case "AutoballerUI":
                tower = autoballerTowerPrefab;
                break;
            case "SlushapultUI":
                tower = slushapultTowerPrefab;
                break;
        }

        //RaycastHit2D ray = Physics2D.Raycast(position, Vector2.zero);
        RaycastHit2D ray = Physics2D.BoxCast(position, new Vector2(1, 1.2f), 0, Vector2.zero);
        if (CabbageCounter.cabbageAmount < tower.GetComponent<Tower>().cost)
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

    

    public void OnBeginDrag(GameObject go)
    {

        Transform towerSprite = go.transform.GetChild(3).transform;
        selectedTower = towerSprite;

        Vector2 position = camera.ScreenToWorldPoint(Input.mousePosition);
        Vector2 offset = new Vector2(0, 0.5f);

        GameObject prefab = null;
        switch (go.tag)
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

        GameObject tower = Instantiate(prefab, position + offset, new Quaternion(), towerParent);
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

        towerCurrentlyBeingDragged = tower;


        //Hiding the tower UI and tinting
        GameObject towerSpr = go.transform.GetChild(3).gameObject;
        towerSpr.SetActive(false);
        GameObject tint = go.transform.GetChild(2).gameObject;
        tint.GetComponent<Image>().color = new Color(0, 0, 0, 0.5f);
        /*
        Transform towerSprite = go.transform.GetChild(3).transform;
        selectedTower = towerSprite;

        

        GameObject tower = null;
        switch (go.tag)
        {
            case "SlingshotUI":
                tower = roughSlingShotTowerPrefab;
                break;
            case "IcicleUI":
                tower = icicleTowerPrefab;
                break;
            case "AutoballerUI":
                tower = autoballerTowerPrefab;
                break;
            case "SlushapultUI":
                tower = slushapultTowerPrefab;
                break;
        }

        //Setting the range for when you drag the tower from the menu
        float range = tower.GetComponent<Tower>().range;
        GameObject rangeUI = towerSprite.GetChild(0).gameObject;
        rangeUI.GetComponent<RectTransform>().localScale = new Vector3(0.76f, 0.76f, 1);
        rangeUI.GetComponent<RectTransform>().sizeDelta = new Vector2(range * 100, range * 100);


        rangeUI.GetComponent<Image>().enabled = true;
        */
    }

    public void OnDrag()
    {
        Vector2 position = camera.ScreenToWorldPoint(Input.mousePosition);
        Vector2 offset = new Vector2(0, 0.5f);

        towerCurrentlyBeingDragged.transform.position = position;

        if (!CheckIfCanPlace(towerCurrentlyBeingDragged.transform.position))
        {
            towerCurrentlyBeingDragged.transform.GetChild(0).GetComponent<SpriteRenderer>().color = canNotPlaceColor;
        }
        else
        {
            towerCurrentlyBeingDragged.transform.GetChild(0).GetComponent<SpriteRenderer>().color = canPlaceColor;
        }
        /*
        //print("Dragging" + Time.deltaTime);
        //UI
        selectedTower.position = camera.ScreenToWorldPoint(Input.mousePosition);
        selectedTower.position = new Vector3(selectedTower.position.x, selectedTower.position.y, 0);

        if (!CheckIfCanPlace(selectedTower.position))
        {
            selectedTower.GetChild(0).GetComponent<Image>().color = canNotPlaceColor;
        }
        else
        {
            selectedTower.GetChild(0).GetComponent<Image>().color = canPlaceColor;
        }*/
    }

    public void OnEndDrag(GameObject go)
    {

        Vector2 position = camera.ScreenToWorldPoint(Input.mousePosition);
        Vector2 offset = new Vector2(0, 0.5f);
        bool canPlace = CheckIfCanPlace(position);

        if (canPlace)
        {
            //Re-enabling everything
            towerCurrentlyBeingDragged.GetComponent<Tower>().enabled = true;
            towerCurrentlyBeingDragged.GetComponent<CapsuleCollider2D>().enabled = true;
            towerCurrentlyBeingDragged.transform.GetChild(1).gameObject.SetActive(true);

            //Disabling the rangeUI
            towerCurrentlyBeingDragged.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
        }
        else
        {
            Destroy(towerCurrentlyBeingDragged);
        }

        towerCurrentlyBeingDragged = null;




        //Showing the tower ui and untinting
        GameObject towerSpr = go.transform.GetChild(3).gameObject;
        towerSpr.SetActive(true);
        GameObject tint = go.transform.GetChild(2).gameObject;
        tint.GetComponent<Image>().color = new Color(0, 0, 0, 0);
        /*
        Transform towerSprite = go.transform.GetChild(3).transform;
        towerSprite.localPosition = new Vector3(0, 0, 0);

        towerSprite.GetChild(0).GetComponent<Image>().enabled = false;

        //Placing tower stuff

        Vector2 position = camera.ScreenToWorldPoint(Input.mousePosition);
        Vector2 offset = new Vector2(0, 0.5f);
        bool canPlace = CheckIfCanPlace(position);

        if (canPlace)
        {
            GameObject prefab = null;
            switch (go.tag)
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

            GameObject tower = Instantiate(prefab, position + offset, new Quaternion(), towerParent);
            tower.GetComponent<Tower>().enemyParent = enemyParent;
            tower.GetComponent<Tower>().ammunitionParent = ammunitionParent;
        }
        */

    }

}
