using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Warning : MonoBehaviour
{
    public TextMeshProUGUI warningText;
    public float upTime;
    public static int checkButton;
    public float ogUpTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Hazards.snowstorm == true)
        {
            Event("Snowstorm");
        }
        if(Hazards.avalanche == true)
        {
            Event("Avalanche");
        }
        if(checkButton == 1)
        {
            Event("Enemies");
            checkButton--;
        }
        if(upTime < 0)
        {
            warningText.text = "Normal";
        }

        upTime -= Time.deltaTime;
    }


    public void Event(string eventName)
    {
        if(eventName == "Snowstorm")
        {
            upTime = Hazards.stormTime;
            warningText.text = "Warning: Currently Storming";
        }
        else if(eventName == "Avalanche")
        {
            upTime = ogUpTime;
            warningText.text = "Warning: Watch Out for Giant Snowballs";
        }
        else if(eventName == "Enemies")
        {
            upTime = ogUpTime;
            warningText.text = "You cannot go to the next wave if there are enemies remaining";
        }
    }
}
