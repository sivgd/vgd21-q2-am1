using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TowerInfo : MonoBehaviour
{
    public Camera camera;

    public GameObject towerInfo;
    public TowerUpgradeButtonScript upgradeButton;

    public Transform towerParent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            CabbageCounter.cabbageAmount += 100;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Vector2 position = camera.ScreenToWorldPoint(Input.mousePosition);

            GameObject tower = GetTower(position);

            if (tower != null)
            {
                towerInfo.SetActive(true);

                SetTowerInfo(tower);
                upgradeButton.selectedTower = tower.GetComponent<Tower>();
                tower.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;
            }
            else
            {
                for(int i = 0; i < towerParent.childCount; i++)
                {
                    towerParent.GetChild(i).GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
                }
                towerInfo.SetActive(false);
            }
        }
    }
    GameObject GetTower(Vector2 pos)
    {
        RaycastHit2D ray = Physics2D.Raycast(pos, Vector2.zero);
        if (ray.collider != null)
        {
            if (ray.collider.gameObject.tag == "TowerSelect")
            {
                return ray.collider.transform.parent.gameObject;
            }
        }
        return null;
    }

    public void SetTowerInfo(GameObject tower)
    {
        towerInfo.transform.position = new Vector3(tower.transform.position.x, tower.transform.position.y + 2.4f, 0);

        Tower towerScript = tower.GetComponent<Tower>();
        towerInfo.transform.GetChild(0).GetComponent<TextMeshPro>().text = towerScript.towerName;
        towerInfo.transform.GetChild(1).GetComponent<TextMeshPro>().text = "Damage: " + towerScript.shootingDamage;
        towerInfo.transform.GetChild(2).GetComponent<TextMeshPro>().text = "Range: " + towerScript.range;
        towerInfo.transform.GetChild(3).GetComponent<TextMeshPro>().text = "Speed: "+towerScript.shootingSpeed;
        if (towerScript.nextStage != null)
        {
            print("set");
            towerInfo.transform.GetChild(4).GetChild(1).GetComponent<TextMeshPro>().text = "Upgrade: " + towerScript.nextStage.GetComponent<Tower>().actualCost;
        }
        else
        {
            towerInfo.transform.GetChild(4).GetChild(1).GetComponent<TextMeshPro>().text = "No More";
        }
    }

    public void SetTowerInfo(GameObject tower, Vector2 position)
    {
        towerInfo.transform.position = new Vector3(position.x, position.y + 2.4f, 0);

        Tower towerScript = tower.GetComponent<Tower>();
        towerInfo.transform.GetChild(0).GetComponent<TextMeshPro>().text = towerScript.towerName;
        towerInfo.transform.GetChild(1).GetComponent<TextMeshPro>().text = "Damage: " + towerScript.shootingDamage;
        towerInfo.transform.GetChild(2).GetComponent<TextMeshPro>().text = "Range: " + towerScript.range;
        towerInfo.transform.GetChild(3).GetComponent<TextMeshPro>().text = "Speed: " + towerScript.shootingSpeed;

        if (towerScript.nextStage != null)
        {
            print("set");
            towerInfo.transform.GetChild(4).GetChild(1).GetComponent<TextMeshPro>().text = "Upgrade: " + towerScript.nextStage.GetComponent<Tower>().actualCost;
        }
        else
        {
            towerInfo.transform.GetChild(4).GetChild(1).GetComponent<TextMeshPro>().text = "No More";
        }
    }
}
