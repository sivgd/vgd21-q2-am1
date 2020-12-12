using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerSelectUI : MonoBehaviour
{
    public new Camera camera;
    public Transform towerSelect;
    public Transform towerSelections;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            

            Vector2 position = camera.ScreenToWorldPoint(Input.mousePosition);

            GameObject tower = GetTower(position);
            if(tower != null){

                if (tower.tag == "Tower")
                {
                    towerSelect.gameObject.SetActive(true);
                    towerSelections.gameObject.SetActive(false);

                    Tower towerScript = tower.GetComponent<Tower>();
                    //Got the tower now going to set the UI to match what the tower is
                    print(tower.name);

                    //Set the name of the tower
                    towerSelect.GetChild(0).GetComponent<Text>().text = towerScript.towerName;
                    //Set the damage of the tower
                    towerSelect.GetChild(2).GetComponent<Text>().text = towerScript.shootingDamage.ToString();
                }


            }
            else
            {
                towerSelect.gameObject.SetActive(false);
                towerSelections.gameObject.SetActive(true);
            }
        }
    }

    GameObject GetTower(Vector2 pos)
    {
        RaycastHit2D ray = Physics2D.Raycast(pos, Vector2.zero);
        if(ray.collider != null)
        {
            if(ray.collider.gameObject.tag == "TowerSelect" || ray.collider.gameObject.tag == "UI")
            {
                return ray.collider.transform.parent.gameObject;
            }
        }
        print(null);
        return null;
    }
}
