using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CabbageCounter : MonoBehaviour
{
    public Text cabbageCounter;
    public float cabbageAmount;
    public float cabbageIncreasedPerSecond;

    // Use this for initialization
    void Start()
    {
        cabbageAmount =1f;
        cabbageIncreasedPerSecond =1f;

    }

    // Update is called once per frame
    void Update(){
        cabbageCounter.text = (int)cabbageAmount + "00 C";
        cabbageAmount +=cabbageIncreasedPerSecond * Time.deltaTime;
    }
}
