using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CabbageCounter : MonoBehaviour
{
    public Text cabbageCounter;
    public float cabbageAmount;
    public float cabbageIncreasedPerKill;

    // Use this for initialization
    void Start()
    {
        cabbageAmount =0f;
        cabbageIncreasedPerKill =100f;

    }

    // Update is called once per frame
    void Update(){
        cabbageCounter.text = (int)cabbageAmount + "CC";
        cabbageAmount +=cabbageIncreasedPerKill * Time.deltaTime;
    }
}
