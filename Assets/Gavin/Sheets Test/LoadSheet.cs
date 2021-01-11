using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleSheetsToUnity;
using System.Text.RegularExpressions;

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

    bool isLoaded;

    public GameObject waveHandler;//Prefab
    public GameObject currentWaveHandler;//In scene
    public int wave1Start;
    public int waveSpot;

    // Start is called before the first frame update
    void Awake()
    {
        if (updateOnLoad)
        {
            isLoaded = false;
            UpdateStats();

        }
    }

    // Update is called once per frame
    void Update()
    {
        if(rawData != null && !isLoaded)
        {
            UpdateEverything(null);
            isLoaded = true;
        }
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
        
        waveHandler.GetComponent<Waves>().wavesVar = new WaveHandler[10];
        for(int i = 0; i < 10; i++)
        {
            waveHandler.GetComponent<Waves>().wavesVar[i] = new WaveHandler();
        }
        for(int i = 1; i <= int.Parse(rawData.values[waveSpot-1][0]); i++)
        {
            SetDataForWave(i);
        }
        
    }

    void SetDataForTower(int tower)
    {
        //print("Tower: " + towerCellStarts[tower]);
        int colOffset = 1;
        
        towers[tower].GetComponent<Tower>().range = float.Parse(rawData.values[towerCellStarts[tower] - 1][colOffset]);
        towers[tower].GetComponent<Tower>().shootingDamage = float.Parse(rawData.values[towerCellStarts[tower] - 1][colOffset + 1]);
        towers[tower].GetComponent<Tower>().shootingSpeed = float.Parse(rawData.values[towerCellStarts[tower] - 1][colOffset + 2]);
        towers[tower].GetComponent<Tower>().actualCost = int.Parse(rawData.values[towerCellStarts[tower] - 1][colOffset + 3]);
    }

    void SetDataForEnemy(int enemy)
    {
        
        int colOffset = 1;

        enemies[enemy].GetComponent<EnemyHealth>().health = float.Parse(rawData.values[enemyCellStarts[enemy] - 1][colOffset]);
        enemies[enemy].GetComponent<EnemyHealth>().damage = int.Parse(rawData.values[enemyCellStarts[enemy] - 1][colOffset + 1]);
        enemies[enemy].GetComponent<PathCreation.Examples.PathFollower>().speed = float.Parse(rawData.values[enemyCellStarts[enemy] - 1][colOffset + 2]);
        enemies[enemy].GetComponent<EnemyHealth>().money = int.Parse(rawData.values[enemyCellStarts[enemy] - 1][colOffset + 3]);
    }

    void SetDataForWave(int wave)
    {
        print("Set for wave: " + wave);

        WaveHandler waveH = waveHandler.GetComponent<Waves>().wavesVar[wave - 1];
        string[] groupsString;

        //Getting the amount of groups
        int howManyGroups = rawData.values[wave1Start + wave - 2].Count;

        //Putting all the groups in one place
        groupsString = new string[howManyGroups];
        for(int i = 0; i < howManyGroups - 1; i++)
        {
            groupsString[i] = rawData.values[wave1Start + wave - 2][i + 1];
        }

        waveH.groups = new Group[howManyGroups];
        for (int i = 0; i < howManyGroups - 1; i++)
        {
            waveH.groups[i] = new Group();
        }


        //Getting the information from those groups
        for (int i = 0; i < howManyGroups - 1; i++)
        {

            string[] groupSplit = groupsString[i].Split(',');
            GameObject typeOfEnemy = null;
            int numberOfEnemies;
            float rate;
            float delay;

            //Getting the type of enemy
            if(Regex.IsMatch(groupSplit[0], @"\dS$"))
            {
                print("S");
                typeOfEnemy = enemies[0];
            }
            else if (Regex.IsMatch(groupSplit[0], @"\dSS$"))
            {
                print("SS");
                typeOfEnemy = enemies[1];
            }
            else if (Regex.IsMatch(groupSplit[0], @"\dSSS$"))
            {
                typeOfEnemy = enemies[2];
            }

            else if (Regex.IsMatch(groupSplit[0], @"\ds$"))
            {
                typeOfEnemy = enemies[3];
            }
            else if (Regex.IsMatch(groupSplit[0], @"\dss$"))
            {
                typeOfEnemy = enemies[4];
            }
            else if (Regex.IsMatch(groupSplit[0], @"\dsss$"))
            {
                typeOfEnemy = enemies[5];
            }

            else if (Regex.IsMatch(groupSplit[0], @"\dT$"))
            {
                typeOfEnemy = enemies[6];
            }
            else if (Regex.IsMatch(groupSplit[0], @"\dTT$"))
            {
                typeOfEnemy = enemies[7];
            }
            else if (Regex.IsMatch(groupSplit[0], @"\dTTT$"))
            {
                typeOfEnemy = enemies[8];
            }
            print("Group: " + i);
            print(Regex.Replace(groupSplit[0], "[a-zA-Z]", ""));
            numberOfEnemies = int.Parse(Regex.Replace(groupSplit[0], "[a-zA-Z]", ""));
            rate = float.Parse(groupSplit[1]);
            delay = float.Parse(groupSplit[2]);

            
            waveH.groups[i].enemyCount = numberOfEnemies;
            waveH.groups[i].enemyPrefab = typeOfEnemy;
            waveH.groups[i].rate = rate;
            waveH.groups[i].delay = delay;

        }
        
    }
}
