using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerSelectUI : MonoBehaviour
{
    public new Camera camera;
    public Transform towerSelect;
    public Transform towerSelections;

    public Transform towerParent;

    public Button upgradeButton;
    // Start is called before the first frame update
    void Start()
    {
        Tower.gameMaster = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        


        //FOR DEBUGGING ADDS MONEY
        if (Input.GetKeyDown(KeyCode.O))
        {
            CabbageCounter.cabbageAmount += 100;

            print(CabbageCounter.cabbageAmount);
        }




        if (Input.GetMouseButtonDown(0))
        {
            

            Vector2 position = camera.ScreenToWorldPoint(Input.mousePosition);

            GameObject tower = GetTower(position);
            if(tower != null){

                if (tower.tag == "Tower")
                {

                    tower.GetComponent<Tower>().SetRangeUI();


                    //Setting tower UI to be invisible
                    for (int i = 0; i < towerParent.childCount; i++)
                    {
                        towerParent.transform.GetChild(i).GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
                    }


                    towerSelect.gameObject.SetActive(true);
                    towerSelections.gameObject.SetActive(false);

                    //Setting the rangeUI to be visible
                    tower.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;

                    Tower towerScript = tower.GetComponent<Tower>();


                    //Got the tower now going to set the UI to match what the tower is
                    //Set the name of the tower
                    towerSelect.GetChild(0).GetComponent<Text>().text = towerScript.towerName;
                    //Set the damage of the tower
                    towerSelect.GetChild(2).GetComponent<Text>().text = towerScript.shootingDamage.ToString();
                    //Set the shooting speed of the tower
                    towerSelect.GetChild(3).GetComponent<Text>().text = "Shooting Speed: " + towerScript.shootingSpeed.ToString();
                    //Set the range of the tower
                    towerSelect.GetChild(4).GetComponent<Text>().text = "Range: " + towerScript.range.ToString();

                    /*if(towerScript.universalRangeMultiplier != 1)
                    {
                        towerSelect.GetChild(4).GetComponent<Text>().text += "; Snow storm active: " + towerScript.universalRangeMultiplier;
                    }*/

                    //Set the Stage of the tower
                    towerSelect.GetChild(5).GetComponent<Text>().text = "Current Stage: " + towerScript.stage.ToString();
                    //Upgrade stuff
                    if(towerScript.nextStage != null)
                    {
                        //Set the Cost of the Upgrade
                        towerSelect.GetChild(6).GetComponent<Text>().text = "Cost of Upgrade: " + towerScript.nextStage.GetComponent<Tower>().cost.ToString();
                    }
                    else
                    {
                        //There is no more upgrades
                        towerSelect.GetChild(6).GetComponent<Text>().text = "No more Upgrades";
                    }
                    

                    //Set the UpgradeButton button's game object to the selected tower
                    upgradeButton.onClick.RemoveAllListeners();//Removing all the other upgradebutton listeners
                    UnityEngine.Events.UnityAction upgradeEvent = new UnityEngine.Events.UnityAction(tower.GetComponent<Tower>().Upgrade);
                    UnityEngine.Events.UnityAction closeTowerSelectUI = new UnityEngine.Events.UnityAction(CloseTowerSelectUI);
                    upgradeButton.onClick.AddListener(upgradeEvent);
                    upgradeButton.onClick.AddListener(closeTowerSelectUI);
                }


            }
            else
            {
                //Setting tower UI to be invisible
                for(int i = 0; i < towerParent.childCount; i++)
                {
                    towerParent.transform.GetChild(i).GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
                }
                

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
            print("1");
            if (ray.collider.gameObject.tag == "TowerSelect" || ray.collider.gameObject.tag == "UI")
            {
                print("2");
                return ray.collider.transform.parent.gameObject;
            }
            print(ray.collider.gameObject.name);
        }
        return null;
    }

    public void ChangeUpgradeMenu()
    {

    }

    public void CloseTowerSelectUI()
    {
        //Setting tower UI to be invisible
        for (int i = 0; i < towerParent.childCount; i++)
        {
            towerParent.transform.GetChild(i).GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
        }


        towerSelect.gameObject.SetActive(false);
        towerSelections.gameObject.SetActive(true);
    }
}
