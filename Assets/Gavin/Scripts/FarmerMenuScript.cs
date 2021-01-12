using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FarmerMenuScript : MonoBehaviour
{
    public GameObject farmerMenu;
    public GameObject farmerMenuButton;

    public GameObject TowerInfoUI;

    public GameObject selectedTower;

    public Transform towerParent;
    public Transform enemyParent;
    public Transform ammunitionParent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClickedClosedBook()
    {
        if (farmerMenu.activeSelf)
        {
            farmerMenu.SetActive(false);
        }
        else
        {
            farmerMenu.SetActive(true);
            selectedTower = null;
        }
        
    } 

    public void SelectTower(GameObject selectedTower)
    {
        this.selectedTower = selectedTower;
        TowerInfoUI.SetActive(true);

        Tower towerScript = selectedTower.GetComponent<Tower>();


        TowerInfoUI.transform.GetChild(0).GetComponent<Text>().text = towerScript.towerName;
        //Set the range of the tower
        TowerInfoUI.transform.GetChild(1).GetComponent<Text>().text = "Range: " + towerScript.range.ToString();
        //Set the damage of the tower
        TowerInfoUI.transform.GetChild(2).GetComponent<Text>().text = "Shooting Damage: " + towerScript.shootingDamage.ToString();
        //Set the shooting speed of the tower
        TowerInfoUI.transform.GetChild(3).GetComponent<Text>().text = "Shooting Speed: " + towerScript.shootingSpeed.ToString();

        print("FMS AC: " + towerScript.actualCost);
        towerScript.SetActualCost();
        //Set the cost of the tower
        TowerInfoUI.transform.GetChild(4).GetComponent<Text>().text = "Cost: " + towerScript.actualCost.ToString();
    }

    public void ClickedBuyTower()
    {
        farmerMenu.SetActive(false);


        GameObject tower = Instantiate(selectedTower, Vector3.zero, new Quaternion(), towerParent);
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

        gameObject.GetComponent<TowerPlace>().towerBeingPlaced = tower;
    }
}
