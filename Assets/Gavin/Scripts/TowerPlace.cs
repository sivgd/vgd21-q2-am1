using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TowerPlace : MonoBehaviour
{
    public new Camera camera;
    public GameObject roughSlingShotTowerPrefab;
    public GameObject icicleTowerPrefab;
    public Transform towerParent;
    public Transform enemyParent;
    public Transform ammunitionParent;

    public Transform towerSelections;
    public Transform selectedTower;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
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
            }
        }

    }

    public bool CheckIfCanPlace(Vector2 position)
    {
        print("Check");
        RaycastHit2D ray = Physics2D.Raycast(position, Vector2.zero);
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

        //UI
        GameObject tint = go.transform.GetChild(2).gameObject;
        tint.GetComponent<Image>().color = new Color(0, 0, 0, 0.5f);

        Transform towerSprite = go.transform.GetChild(3).transform;
        selectedTower = towerSprite;

        float range = roughSlingShotTowerPrefab.GetComponent<Tower>().range;

        GameObject rangeUI = towerSprite.GetChild(0).gameObject;
        rangeUI.GetComponent<RectTransform>().localScale = new Vector2(range * 0.75f, range * 0.75f);

        GameObject tower = null;
        switch (go.tag)
        {
            case "SlingshotUI":
                tower = roughSlingShotTowerPrefab;
                break;
            case "IcicleUI":
                tower = icicleTowerPrefab;
                break;
        }


        rangeUI.GetComponent<RectTransform>().localScale = new Vector3(tower.GetComponent<Tower>().range, tower.GetComponent<Tower>().range, 1);
        rangeUI.GetComponent<Image>().enabled = true;
    }

    public void OnDrag()
    {
        //print("Dragging" + Time.deltaTime);
        //UI
        selectedTower.position = camera.ScreenToWorldPoint(Input.mousePosition);
        selectedTower.position = new Vector3(selectedTower.position.x, selectedTower.position.y, 0);
    }

    public void OnEndDrag(GameObject go)
    {

        //UI
        GameObject tint = go.transform.GetChild(2).gameObject;
        tint.GetComponent<Image>().color = new Color(0, 0, 0, 0);

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
            }

            GameObject tower = Instantiate(prefab, position + offset, new Quaternion(), towerParent);
            tower.GetComponent<Tower>().enemyParent = enemyParent;
            tower.GetComponent<Tower>().ammunitionParent = ammunitionParent;
        }

    }
    
}
