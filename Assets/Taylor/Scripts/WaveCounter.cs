using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WaveCounter : MonoBehaviour
{
    public static int waveNumber = 0;
    private int addCabbage = 0;
    Text score;
    public static int[] money;//The money you get per round 
    public int[] moneyPerTurn;
    // Use this for initialization
    void Start()
    {
        score = GetComponent<Text>();
        money = moneyPerTurn;
    }
    // Update is called once per frame
    void Update()
    {

    }

    public void CheckWave()
    {
        score.text = "Wave: " + (waveNumber + 1);
        if (money == null)
        {
            return;
        }

        for (int i = 0; i < money.Length; i++)
        {
            if (WaveCounter.waveNumber == i && addCabbage == i)
            {
                CabbageCounter.cabbageAmount += money[i];
                addCabbage++;
            }

            if (WaveCounter.waveNumber == 11)
            {
                SceneManager.LoadScene("VictoryScreen");
            }

        }
        if (false)
        {

        }
        else if (true)
        {

        }

    }
}