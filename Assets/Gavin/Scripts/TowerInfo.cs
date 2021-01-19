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
                if (tower.tag == "Tower")
                {
                    for (int i = 0; i < towerParent.childCount; i++)
                    {
                        towerParent.GetChild(i).GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
                    }

                    towerInfo.SetActive(true);
                    UpdateTowerSelection(tower);
                    SetTowerInfo(tower);
                    upgradeButton.selectedTower = tower.GetComponent<Tower>();
                    tower.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;
                }else if(tower.tag == "UI")
                {

                }
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
            if (ray.collider.gameObject.tag == "Tower")
            {
                if (ray.collider.gameObject.GetComponent<Tower>().enabled)
                {
                    print("GetTower");
                    return ray.collider.transform.gameObject;
                }
            }
            if(ray.collider.gameObject.tag == "UI")
            {
                return ray.collider.transform.gameObject;
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
        towerInfo.transform.GetChild(2).GetComponent<TextMeshPro>().text = "Range: " + (towerScript.range * Tower.universalRangeMultiplier);
        towerInfo.transform.GetChild(3).GetComponent<TextMeshPro>().text = "Speed: "+towerScript.shootingSpeed;
        if (towerScript.nextStage != null)
        {
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
            towerInfo.transform.GetChild(4).GetChild(1).GetComponent<TextMeshPro>().text = "Upgrade: " + towerScript.nextStage.GetComponent<Tower>().actualCost;
        }
        else
        {
            towerInfo.transform.GetChild(4).GetChild(1).GetComponent<TextMeshPro>().text = "No More";
        }
    }

    public void NextTowerSelection(bool isLeft)
    {
        int length = upgradeButton.selectedTower.targetModes.Length;
        int mode = upgradeButton.selectedTower.targetMode;
        int dir = isLeft ? -1 : 1;


        if(mode + dir >= length || mode + dir < 0)
        {
            if (isLeft)
            {
                mode = length - 1;
            }
            else
            {
                mode = 0;
            }
        }
        else
        {
            mode += dir;
            print("Mode: " + mode);
        }
        upgradeButton.selectedTower.targetMode = mode;
        UpdateTowerSelection(upgradeButton.selectedTower.gameObject);
    }
    public void UpdateTowerSelection(GameObject tower)
    {
        Tower towerS = tower.GetComponent<Tower>();
        towerInfo.transform.GetChild(5).GetComponent<TextMeshPro>().text = towerS.targetModesNames[towerS.targetMode];
    }
}
