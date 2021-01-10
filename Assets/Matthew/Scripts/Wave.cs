using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WaveHandler
{
    public Group[] groups;
    //public float rate;//Time between each group
}

[System.Serializable]
public class Group
{
    public GameObject enemyPrefab;
    public int enemyCount;
    public float rate;//Time between each enemy
    public float delay;//Until the next group
}
