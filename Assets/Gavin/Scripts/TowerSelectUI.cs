using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerSelectUI : MonoBehaviour
{
    public new Camera camera;
    public Transform towerSelect;
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
            Vector2 offset = new Vector2(0, 0.5f);
            //print(canPlace);

            GameObject tower = GetTower(position);
            if(tower != null){

                Tower towerScript = tower.GetComponent<Tower>();
                //Got the tower now going to set the UI to match what the tower is
                print(tower.name);

                //Set the name of the tower
                towerSelect.GetChild(0).GetComponent<Text>().text = towerScript.towerName;


            }
        }
    }

    GameObject GetTower(Vector2 pos)
    {
        RaycastHit2D ray = Physics2D.Raycast(pos, Vector2.zero);
        if(ray.collider != null)
        {
            if(ray.collider.gameObject.tag == "TowerSelect")
            {
                return ray.collider.transform.parent.gameObject;
            }
        }
        return null;
    }
}
