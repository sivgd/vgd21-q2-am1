using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ButtonFunctions : MonoBehaviour
{
    public TextMeshProUGUI currentSpeed;
    public TextMeshProUGUI waveText;
    public float buttonTime;
    public float ogButtonTime;
    public GameObject enemyParent;

    private void Start()
    {
        buttonTime = ogButtonTime;
    }

    private void Update()
    {
        buttonTime -= Time.deltaTime;
        if (buttonTime < 0f)
        {
            buttonTime = 0f;
        }
        waveText.text = "Next Wave " + Mathf.Round(buttonTime);
    }
    public void NextWave()
    {
        if (enemyParent.transform.childCount == 0 && buttonTime <= 0)
        {
            Waves.waveNumber++;
            buttonTime = ogButtonTime;
            
        }
        else if(enemyParent.transform.childCount > 0)
        {
            Warning.checkButton++;
            
            
        }
        
    }
    
    public void SpeedControl()
    {
        if (Time.timeScale == 0.5f)
        {
            Time.timeScale = 1f;
            currentSpeed.text = "Current Speed: Single";
        }
        else if (Time.timeScale == 1f)
        {
            Time.timeScale = 2f;
            currentSpeed.text = "Current Speed: Double";
        }
        else if (Time.timeScale == 2f)
        {
            Time.timeScale = 0.5f;
            currentSpeed.text = "Current Speed: Half";
        }

        
    }
}
