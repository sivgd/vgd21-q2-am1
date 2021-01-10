using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleSheetsToUnity;


public class LoadSheet : MonoBehaviour
{
    public string associatedSheet = "18DPMB5cRVUB1-mDtefVJrwZbdINrP7lUDN3XpPA4HuM";
    public string associatedWorksheet = "Sheet1";

    public static ValueRange rawData;

    public bool updateOnLoad;
    public GameObject[] towers;
    public int[] towerCellStarts;

    public GameObject[] enemies;
    public int[] enemyCellStarts;
    // Start is called before the first frame update
    void Start()
    {
        if (updateOnLoad)
        {
            UpdateStats();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateStats()
    {
        SpreadsheetManager spreadsheetManager = new SpreadsheetManager();
        SpreadsheetManager.Read(new GSTU_Search(associatedSheet, associatedWorksheet), UpdateEverything, false);
        
    }

    void UpdateEverything(GstuSpreadSheet ss)
    {
        //First number is the row second is the column

        List<List<string>> data = rawData.values;

        //Towers

        for(int i = 0; i < towers.Length; i++)
        {
           
            SetDataForTower(i);
        }

        for (int i = 0; i < enemies.Length; i++)
        {
            SetDataForEnemy(i);
        }
    }

    void SetDataForTower(int tower)
    {
        //print("Tower: " + towerCellStarts[tower]);
        int colOffset = 1;
        
        towers[tower].GetComponent<Tower>().range = float.Parse(rawData.values[towerCellStarts[tower] - 1][colOffset]);
        towers[tower].GetComponent<Tower>().shootingDamage = float.Parse(rawData.values[towerCellStarts[tower] - 1][colOffset + 1]);
        towers[tower].GetComponent<Tower>().shootingSpeed = float.Parse(rawData.values[towerCellStarts[tower] - 1][colOffset + 2]);
        towers[tower].GetComponent<Tower>().cost = int.Parse(rawData.values[towerCellStarts[tower] - 1][colOffset + 3]);
    }

    void SetDataForEnemy(int enemy)
    {
        
        int colOffset = 1;

        enemies[enemy].GetComponent<EnemyHealth>().health = float.Parse(rawData.values[enemyCellStarts[enemy] - 1][colOffset]);
        enemies[enemy].GetComponent<EnemyHealth>().damage = int.Parse(rawData.values[enemyCellStarts[enemy] - 1][colOffset + 1]);
        enemies[enemy].GetComponent<PathCreation.Examples.PathFollower>().speed = float.Parse(rawData.values[enemyCellStarts[enemy] - 1][colOffset + 2]);
        enemies[enemy].GetComponent<EnemyHealth>().money = int.Parse(rawData.values[enemyCellStarts[enemy] - 1][colOffset + 3]);
    }
}
