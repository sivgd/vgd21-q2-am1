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

        print(data[11].Count);
        //Towers

        for(int i = 0; i < towers.Length; i++)
        {
            SetDataForTower(i);
        }

        /*for(int r = 0; r < data.Count; r++)
        {
            if (rawData.values[r].Count > 0)
            {
                List<string> column = data[r];
                for (int c = 0; c < column.Count; c++)
                {
                    print("Row: " + r + "; Col: " + c + "; Data: " + data[r][c]);
                }
            }
        }*/
    }

    void SetDataForTower(int tower)
    {
        print("Tower: " + towerCellStarts[tower]);
        int colOffset = 1;
        
        towers[tower].GetComponent<Tower>().range = float.Parse(rawData.values[towerCellStarts[tower] - 1][colOffset]);
        towers[tower].GetComponent<Tower>().shootingDamage = float.Parse(rawData.values[towerCellStarts[tower] - 1][colOffset + 1]);
        towers[tower].GetComponent<Tower>().shootingSpeed = float.Parse(rawData.values[towerCellStarts[tower] - 1][colOffset + 2]);
        towers[tower].GetComponent<Tower>().cost = int.Parse(rawData.values[towerCellStarts[tower] - 1][colOffset + 3]);
    }
}
