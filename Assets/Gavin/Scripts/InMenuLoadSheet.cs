using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GoogleSheetsToUnity;
using System.Text.RegularExpressions;
public class InMenuLoadSheet : ScriptableObject
{
    public string associatedSheet = "18DPMB5cRVUB1-mDtefVJrwZbdINrP7lUDN3XpPA4HuM";
    public string associatedWorksheet = "Sheet1";

    public static ValueRange rawData;

    [SerializeField]
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

    public int numberOfWaves;

    public void Init()
    {

    }

    
    
}
