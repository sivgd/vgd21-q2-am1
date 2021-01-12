using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ButtonFunctions : MonoBehaviour
{
    public TextMeshProUGUI currentSpeed;
    public void NextWave()
    {
        if (Waves.enemiesAlive == 0)
        {
            Waves.waveNumber++;
        }
        else if(Waves.enemiesAlive > 0)
        {
            Warning.checkButton++;
        }
    }
    
    public void SpeedControl()
    {
        if (Time.timeScale == 1f)
        {
            Time.timeScale = 2f;
            currentSpeed.text = "Current Speed: Double";
        }
        else if (Time.timeScale == 2f)
        {
            Time.timeScale = 1f;
            currentSpeed.text = "Current Speed: Single";
        }
    }
}
